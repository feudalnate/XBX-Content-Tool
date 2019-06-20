using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Linq;
using System.Globalization;

namespace XBXContentTool
{

    namespace UI
    {

        public class Keys : IDisposable
        {
            private List<Key> keys;

            public Keys()
            {
                keys = new List<Key>();
            }

            public Key this[int i] { get { return keys[i]; } }

            public int Count { get { return keys.Count; } }

            public Key[] ToArray()
            {
                return keys.ToArray();
            }

            public void Add(Key key)
            {
                if (!keys.Contains(key)) keys.Add(key);
            }

            public byte[] GetKey(string alias, out bool exists)
            {
                exists = false;
                if (keys.Count == 0) return null;
                byte[] buffer = null;
                foreach(Key key in keys)
                {
                    if (key.alias == alias)
                    {
                        exists = true;
                        buffer = key.key;
                    }
                }
                return buffer;
            }

            public void Remove(string alias, byte[] xboxhdkey)
            {
                if (keys.Count == 0) return;
                for(int i = 0; i < keys.Count; i++)
                {
                    if (keys[i].alias == alias && keys[i].key.CompareTo(xboxhdkey))
                    {
                        keys.RemoveAt(i);
                        return;
                    }
                }
            }

            public void Remove(int i)
            {
                if (!((keys.Count - 1) < i)) keys.RemoveAt(i);
            }

            public bool Contains(string alias)
            {
                if (keys.Count == 0) return false;
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i].alias == alias) return true;
                }
                return false;
            }

            public bool Contains(byte[] xboxhdkey)
            {
                if (keys.Count == 0) return false;
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i].key.CompareTo(xboxhdkey)) return true;
                }
                return false;
            }

            public bool Load(string file)
            {
                try
                {
                    if (!File.Exists(file)) return false;
                    if (new FileInfo(file).Length == 0) return false;
                    string data = File.ReadAllText(file, Encoding.UTF8);
                    keys = new JavaScriptSerializer().Deserialize<List<Key>>(data);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public bool Save(string file)
            {
                try
                {
                    string data = new JavaScriptSerializer().Serialize(keys);
                    File.WriteAllText(file, data, Encoding.UTF8);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public void Dispose()
            {
                keys.Clear();
            }

            public class Key
            {
                public string alias;
                public byte[] key;
            }

        }

        static class Win32
        {
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

            private const int WM_SETREDRAW = 11;

            public static void SuspendDrawing(System.Windows.Forms.Control parent)
            {
                SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
            }

            public static void ResumeDrawing(System.Windows.Forms.Control parent)
            {
                SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
                parent.Refresh();
            }

        }

    }

    namespace Xbox
    {

        /// <summary>
        /// Methods for calculating Xbox content signatures
        /// </summary>
        static class XCalcSig
        {
            //------------------------------
            //Roamable Signatures
            //------------------------------
            //Content signed with a roamable signature can be loaded and authenticated on any Xbox console.
            //The only content that is permitted to be signed with roamable signatures is user data (save games and profiles).
            //The key used to generate a roamable signature is a game-specific key that resides on the game disc.
            //------------------------------

            //------------------------------
            //Non-roamable Signatures
            //------------------------------
            //Content signed with a non-roamable signature can be authenticated only on the Xbox console that originally signed the content.
            //Non-roamable signatures lock content to a single console.
            //The only content that is permitted to be signed with non-roamable signatures is title data (downloadable content and cache).
            //The key used to generate a non-roamable signature is a combination of a game-specific key and a per-Xbox key that's different on every Xbox console.
            //------------------------------

            /// <summary>
            /// Used to compute SHA1 of ContentMeta.xbx sections and external file content. Generally for integrity checks not authentication.
            /// </summary>
            /// <param name="data">Data to be hashed</param>
            /// <returns></returns>
            public static byte[] CalculateDigest(byte[] data)
            {
                return XcSHA(data, 0, data.Length);
            }

            public static byte[] CalculateDigest(byte[] data, int offset, int length)
            {
                return XcSHA(data, offset, length);
            }

            /// <summary>
            /// Used to compute HMAC-SHA1 of user data (game saves, profiles, etc.)
            /// 
            /// Roamable refers to content that can be transfered between consoles and still be validated
            /// </summary>
            /// <param name="XboxSignatureKey">A unique key assosiated with a game title. This key is stored in the default.xbe for the game (SignatureKey/AlternateSignatureKey)</param>
            /// <param name="data">Data to be hashed</param>
            public static byte[] CalculateRoamable(byte[] XboxSignatureKey, byte[] data)
            {
                return XCryptHMAC(XboxSignatureKey, data);
            }

            /// <summary>
            /// Used to compute HMAC-SHA1 of title data (downloaded content, demos, cache, etc.)
            /// 
            /// Non-roamable refers to content that is only valid for the console it was 'signed' for and cannot be validated by another console
            /// </summary>
            /// <param name="titleId">Unique identifier for the game title</param>
            /// <param name="XboxHDKey">Unique key for the console. This key is generated during manufacturing and stored in the EEPROM</param>
            /// <param name="data">Data to be hashed</param>
            /// <returns></returns>
            public static byte[] CalculateNonRoamable(byte[] titleId, byte[] XboxHDKey, byte[] data)
            {

                return XCryptHMAC(XComputeContentSignatureKey(titleId, XboxHDKey), data);
            }

            /// <summary>
            /// Generate an XboxHDKey from Xbox 360 console serial number/motherboard serial number
            /// </summary>
            /// <param name="consoleSerial">
            /// Serial number of the console. Found on the back of the Xbox 360
            /// 
            /// This is a 12 digit number
            /// </param>
            /// <param name="motherboardSerial">
            /// Serial number of the motherboard. Found on a sticker that is stuck to the top of the motherboard
            /// 
            /// This is a 16 character hexadecimal string (8 bytes)
            /// </param>
            /// <returns></returns>
            public static byte[] MakeXboxHDKey(string consoleSerial, string motherboardSerial)
            {
                //the XboxHDKey for xbox 360 is generated by combining the following:

                //null (4 bytes)
                //the motherboard serial (8 bytes) (convert hex->bytes)
                //the first 4 digits of the console serial (4 bytes) (convert utf8->bytes)

                //Z = null, M = mobo serial, C = console serial
                //0xZZZZZZZZMMMMMMMMMMMMMMMMCCCCCCCC

                byte[] result = new byte[0x10]; //16 byte key, first 4 bytes always zeroed

                //convert hex string to bytes, copy first 8 bytes to key
                Array.Copy(motherboardSerial.ToBytes(true), 0, result, 4, 8);

                //convert ascii string to bytes, copy first 4 bytes to key
                Array.Copy(consoleSerial.ToBytes(false), 0, result, 12, 4); 
                return result;
            }

            /// <summary>
            /// Reads console and motherboard serial numbers from Xbox 360 KV.bin
            /// </summary>
            /// <param name="file">KV.bin</param>
            public static bool FromKV(string file, out string consoleSerial, out string motherboardSerial)
            {
                consoleSerial = null;
                motherboardSerial = null;
                if (Equals(null, file) || !File.Exists(file)) return false;
                int size = (int)new FileInfo(file).Length;
                if (size != 0x3FF0 && size != 0x4000) return false;
                int offset = (size == 0x3FF0 ? 0xA0 : 0xB0);
                byte[] buffer = new byte[0x18];
                using (FileStream IO = new FileStream(file, FileMode.Open))
                {
                    IO.Position = offset;
                    IO.Read(buffer, 0, 0x18);
                }
                consoleSerial = Encoding.UTF8.GetString(buffer, 0, 0xC);
                motherboardSerial = BitConverter.ToString(buffer, 0x10, 8).Replace("-", "");
                buffer = null;
                return true;
            }

            private static byte[] XComputeContentSignatureKey(byte[] titleId, byte[] XboxHDKey)
            {
                return XCryptHMAC(XboxHDKey, titleId);
            }

            private static byte[] XcSHA(byte[] pbData, int pOffset, int cbLength)
            {
                byte[] result = null;
                using (SHA1Managed SHA = new SHA1Managed())
                {
                    result = SHA.ComputeHash(pbData, pOffset, cbLength);
                }
                return result;
            }

            private static byte[] XCryptHMAC(byte[] pbKeyMaterial, byte[] pbData)
            {
                byte[] result = null;
                using (HMACSHA1 HMAC = new HMACSHA1(pbKeyMaterial, true))
                {
                    result = HMAC.ComputeHash(pbData);
                }
                return result;
            }

        }

        /// <summary>
        /// Handler for ContentMeta.xbx files
        /// </summary>
        public class ContentMeta : IDisposable
        {
            public string FilePath { get; private set; }
            FileStream IO;

            /// <summary>
            /// Parses ContentMeta.xbx files
            /// </summary>
            /// <param name="stream">FileStream or MemoryStream to the ContentMeta.xbx data</param>
            /// <param name="success">Whether parse was successful</param>
            public ContentMeta(string file, out bool success)
            {
                if (string.IsNullOrEmpty(file) || !File.Exists(file) || new FileInfo(file).Length <= 0x88) //check file
                {
                    success = false;
                    return;
                }

                FilePath = file;
                IO = new FileStream(file, FileMode.Open);
                byte[] buffer = new byte[4];

                IO.Position = 0x14;
                IO.Read(buffer, 0, 4);
                if (buffer.ToUInt32(false) != 0x46534358) //check magic "XCSF"
                {
                    IO.Dispose();
                    IO = null;
                    buffer = null;
                    success = false;
                    return;
                }

                IO.Read(buffer, 0, 4);
                uint headerSize = buffer.ToUInt32(false);

                if (headerSize != 0x88 && headerSize != 0x6C) //check header size
                {
                    IO.Dispose();
                    IO = null;
                    buffer = null;
                    success = false;
                    return;
                }
                buffer = null;
                success = Read();
            }

            bool Read()
            {
                Types.Header header = new Types.Header();

                byte[] buffer = new byte[4];
                IO.Position = 0;

                header.headerHash = new byte[0x14];
                IO.Read(header.headerHash, 0, 0x14);

                IO.Read(buffer, 0, 4);
                header.magic = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.headerSize = buffer.ToUInt32(false);
                header.headerType = (Types.HeaderType)header.headerSize;

                IO.Read(buffer, 0, 4);
                header.contentType = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.contentFlags = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.titleId = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.offerId = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.offerTitleId = buffer.ToUInt32(false);

                IO.Read(buffer, 0, 4);
                header.publisherFlags = buffer.ToUInt32(false);

                Header = header;

                uint sectionCount = ((header.headerSize - 0x34) / 0x1C);
                if (sectionCount < 2)
                {
                    buffer = null;
                    IO.Dispose();
                    IO = null;
                    return false;
                }

                Sections = new Types.Section[sectionCount];

                for (int i = 0; i < sectionCount; i++)
                {
                    Types.Section section = new Types.Section();

                    IO.Read(buffer, 0, 4);
                    section.sectionOffset = buffer.ToUInt32(false);

                    IO.Read(buffer, 0, 4);
                    section.sectionLength = buffer.ToUInt32(false);

                    section.hashOffset = (uint)IO.Position; //for convenience when signing
                    section.sectionHash = new byte[0x14];
                    IO.Read(section.sectionHash, 0, 0x14);

                    Sections[i] = section;
                }

                for (int i = 0; i < sectionCount; i++)
                {
                    IO.Position = Sections[i].sectionOffset;
                    Sections[i].sectionData = new byte[Sections[i].sectionLength];
                    IO.Read(Sections[i].sectionData, 0, (int)Sections[i].sectionLength);
                }

                buffer = null;

                //section types always in the same order depending on header size
                if (header.headerType == Types.HeaderType.Content) //0x88 = content
                {
                    Sections[0].sectionType = Types.SectionType.Language;
                    Sections[1].sectionType = Types.SectionType.TableOfContents;
                    Sections[2].sectionType = Types.SectionType.Optional;
                }
                if (header.headerType == Types.HeaderType.Update) //0x6C = update
                {
                    Sections[0].sectionType = Types.SectionType.Unknown;
                    Sections[1].sectionType = Types.SectionType.TableOfContents;
                }

                return true;
            }

            /// <summary>
            /// Parses and returns a section
            /// </summary>
            /// <param name="type">Section type to parse</param>
            /// <param name="result">Contains parsed section type. Must be casted to proper type</param>
            /// <returns>Whether parse was successful</returns>
            public bool GetSection(Types.SectionType type, out object result)
            {
                result = null;
                if (Header.headerType == Types.HeaderType.Content && type == Types.SectionType.Unknown) return false;
                if (Header.headerType == Types.HeaderType.Update)
                {
                    if (type == Types.SectionType.Language || type == Types.SectionType.Optional) return false;
                }

                byte[] sectionData = null; //buffer to hold section data
                foreach (Types.Section section in Sections)
                {
                    if (section.sectionType == type)
                    {
                        sectionData = section.sectionData;
                        break;
                    }
                }

                if (Equals(sectionData, null) || sectionData.Length == 0 && type != Types.SectionType.Optional) return false;

                if (type == Types.SectionType.Optional || type == Types.SectionType.Unknown)
                {
                    result = sectionData;
                    return true;
                }

                if (type == Types.SectionType.Language)
                {
                    result = sectionData.ToUnicode().ToString(CultureInfo.InvariantCulture);
                    return true;
                }

                if (type == Types.SectionType.TableOfContents)
                {
                    Types.TableOfContents toc = new Types.TableOfContents();

                    using (Stream stream = new MemoryStream(sectionData))
                    {
                        byte[] buffer = new byte[0x4];

                        stream.Read(buffer, 0, 4);
                        toc.entryCount = buffer.ToUInt32(false);

                        stream.Read(buffer, 0, 4);
                        toc.unknown_0 = buffer.ToUInt32(false);

                        stream.Read(buffer, 0, 4);
                        toc.entryTableOffset = buffer.ToUInt32(false);

                        List<ushort> chain = new List<ushort>();
                        chain.Add(0); //always exists
                        ushort a, b;
                        while (chain.Count < toc.entryCount) //i doubt this is the proper way to parse the entry chain but this works
                        {
                            for (int i = 0; i < chain.Count; i++)
                            {
                                stream.Position = (toc.entryTableOffset + chain[i]);

                                stream.Read(buffer, 0, 2);
                                a = buffer.ToUInt16(false); //entry pointer a

                                stream.Read(buffer, 0, 2);
                                b = buffer.ToUInt16(false); //entry pointer b

                                if (a != 0 && !chain.Contains(a)) chain.Add(a);
                                if (b != 0 && !chain.Contains(b)) chain.Add(b);
                            }
                        }
                        toc.entryChain = chain.ToArray();

                        List<Types.TableEntry> entries = new List<Types.TableEntry>();
                        Types.TableEntry entry;
                        foreach (ushort offset in toc.entryChain)
                        {
                            stream.Position = ((toc.entryTableOffset + offset) + 0x4);
                            entry = new Types.TableEntry();

                            entry.entryOffset = offset;

                            Array.Resize<byte>(ref buffer, 4);

                            stream.Read(buffer, 0, 2);
                            entry.unk_0 = buffer.ToUInt16(false);

                            stream.Read(buffer, 0, 2);
                            entry.filenameLength = buffer.ToUInt16(false);

                            stream.Read(buffer, 0, 4);
                            entry.fileSize = buffer.ToUInt32(false);

                            stream.Read(buffer, 0, 4);
                            entry.fileHashOffset = buffer.ToUInt32(false);

                            stream.Read(buffer, 0, 4);
                            entry.fileHashLength = buffer.ToUInt32(false);

                            stream.Read(buffer, 0, 2);
                            entry.fileHashIndex = buffer.ToUInt16(false);

                            Array.Resize<byte>(ref buffer, entry.filenameLength);

                            stream.Read(buffer, 0, entry.filenameLength);
                            entry.fileName = buffer.ToUTF8();

                            stream.Position = ((entry.fileHashIndex * 0x14) + 0xC);
                            entry.fileHash = new byte[0x14];
                            stream.Read(entry.fileHash, 0, 0x14);

                            entries.Add(entry);
                        }
                        toc.entries = entries.ToArray();
                    }
                    result = toc;
                    return true;
                }

                return false;
            }

            public bool Sign(byte[] XboxHDKey, bool skipContentHashing, out string errorMessage)
            {
                if (Equals(null, XboxHDKey) || XboxHDKey.Length != 0x10)
                {
                    errorMessage = "Bad key";
                    return false;
                }

                byte[] buffer, hash;

                //calculate content hashes
                if (!skipContentHashing)
                {
                    object result;
                    if (!GetSection(Types.SectionType.TableOfContents, out result))
                    {
                        errorMessage = "Failed to parse section data";
                        return false;
                    }

                    Types.Section section = Sections[1];
                    Types.TableOfContents fileTable = (Types.TableOfContents)result; //parsed toc data
                    foreach (Types.TableEntry file in fileTable.entries)
                    {
                        if (!file.Exists(Path.GetDirectoryName(FilePath)))
                        {
                            errorMessage = string.Format("Content file not found: {0}", file.fileName);
                            return false;
                        }

                        uint hashStartOffset = file.fileHashOffset;
                        uint hashLength = file.fileHashLength;
                        uint size = (uint)new FileInfo(Path.Combine(Path.GetDirectoryName(FilePath), file.fileName)).Length;
                        if (size != file.fileSize)
                        {
                            //errorMessage = string.Format("The size of the file \"{0}\" is invalid\n\nExpected size: {1} ({2} bytes)\nActual size: {3} ({4} bytes)", file.fileName, file.fileSize.RoundBytes(), file.fileSize, size.RoundBytes(), size);
                            //return false;

                            //instead of returning an error here I decided to correct the file size, in case of modders :)
                            buffer = BitConverter.GetBytes(size);
                            IO.Position = (((section.sectionOffset + fileTable.entryTableOffset) + file.entryOffset) + 0x8); 
                            IO.Write(buffer, 0, 4); //file size

                            //set hash to cover entire file
                            IO.Write(new byte[4], 0, 4); //hash start offset
                            IO.Write(buffer, 0, 4);  //hash length

                            hashStartOffset = 0;
                            hashLength = size;
                        }

                        buffer = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(FilePath), file.fileName));
                        hash = XCalcSig.CalculateDigest(buffer, (int)hashStartOffset, (int)hashLength);

                        IO.Position = ((section.sectionOffset + 0xC) + (file.fileHashIndex * 0x14));
                        IO.Write(hash, 0, 0x14);
                    }
                    IO.Flush();
                }

                //calculate section hashes
                foreach (Types.Section section in Sections)
                {
                    if (!section.IsAllocated) continue;
                    buffer = new byte[section.sectionLength];
                    IO.Position = section.sectionOffset;
                    IO.Read(buffer, 0, (int)section.sectionLength);
                    hash = XCalcSig.CalculateDigest(buffer);
                    IO.Position = section.hashOffset;
                    IO.Write(hash, 0, 0x14);
                }
                IO.Flush();

                //calculate header "signature"
                buffer = new byte[(Header.headerSize - 0x14)];
                IO.Position = 0x14;
                IO.Read(buffer, 0, (int)(Header.headerSize - 0x14));
                hash = XCalcSig.CalculateNonRoamable(BitConverter.GetBytes(Header.titleId), XboxHDKey, buffer);
                IO.Position = 0;
                IO.Write(hash, 0, 0x14);
                IO.Flush();

                buffer = null;
                hash = null;

                errorMessage = null;
                return true;
            }

            public Types.Header Header { get; private set; }

            public Types.Section[] Sections { get; private set; }

            /// <summary>
            /// Xbox content path
            /// </summary>
            public string RelativePath
            {
                get
                {
                    string titleId = Header.titleId.ToString("X2");
                    string contentType = "$C";
                    if (Header.headerType == Types.HeaderType.Update) contentType = "$U";
                    string contentId = "";
                    if (Header.headerType == Types.HeaderType.Content)
                    {
                        if (Header.offerTitleId == 0) contentId = string.Format(@"{0}\", Header.offerId.ToString("X2").PadLeft(8, '0'));
                        else contentId = string.Format(@"{0}{1}\", Header.offerTitleId.ToString("X2"), Header.offerId.ToString("X2").PadLeft(8, '0'));
                    }
                    return string.Format(@"\TDATA\{0}\{1}\{2}", titleId, contentType, contentId);
                }
            }

            public void Dispose()
            {
                if (!Equals(null, IO)) IO.Dispose();
                if (!Equals(null, Sections) && Sections.Length > 0) Array.Clear(Sections, 0, Sections.Length);
                Sections = null;
                Header = default(Types.Header);
            }

            public static class Types
            {

                public struct Header
                {
                    public HeaderType headerType;
                    public byte[] headerHash;
                    public uint magic;
                    public uint headerSize;
                    public uint contentType; // ?
                    public uint contentFlags; // ?
                    public uint titleId;
                    public uint offerId;
                    public uint offerTitleId; // ?
                    public uint publisherFlags;
                }

                public struct Section
                {
                    public SectionType sectionType;
                    public bool IsAllocated { get { return (sectionLength > 0); } }
                    public bool IsValid
                    {
                        get
                        {
                            if (!IsAllocated) return false;
                            return XCalcSig.CalculateDigest(sectionData).CompareTo(sectionHash);
                        }
                    }
                    public uint sectionOffset;
                    public uint sectionLength;
                    public byte[] sectionHash;
                    public byte[] sectionData;
                    public uint hashOffset;
                }

                public enum HeaderType : uint
                {
                    Content = 0x88,
                    Update = 0x6C
                }

                public enum SectionType
                {
                    Language,
                    TableOfContents,
                    Optional,
                    Unknown
                }

                public struct TableOfContents
                {
                    public uint entryCount;
                    public uint unknown_0;
                    public uint entryTableOffset;
                    public ushort[] entryChain;
                    public TableEntry[] entries;
                }

                public struct TableEntry
                {
                    public ushort entryOffset;
                    public ushort unk_0;
                    public ushort filenameLength;
                    public uint fileSize;
                    public uint fileHashOffset;
                    public uint fileHashLength;
                    public ushort fileHashIndex;
                    public string fileName;
                    public byte[] fileHash;

                    public bool Exists(string rootFolder)
                    {
                        return File.Exists(Path.Combine(rootFolder, fileName));
                    }

                    public bool IsValid(string rootFolder)
                    {
                        if (Exists(rootFolder))
                        {
                            int size = (int)new FileInfo(Path.Combine(rootFolder, fileName)).Length;
                            if (size == fileSize)
                            {
                                byte[] buffer = File.ReadAllBytes(Path.Combine(rootFolder, fileName));
                                byte[] hash = XCalcSig.CalculateDigest(buffer, (int)fileHashOffset, (int)fileHashLength);
                                buffer = null;
                                bool result = hash.CompareTo(fileHash);
                                hash = null;
                                return result;
                            }
                        }
                        return false;
                    }

                }

            }

        }

    }

    static class Extensions
    {

        public static string RoundBytes(this uint a)
        {
            if (a < 1024) return a.ToString();
            string[] metrics = new string[] { "KB", "MB", "GB" };
            int i = 0;
            double result = Convert.ToDouble(a);
            while ((result /= 1024) > 1024) i++;
            return string.Format("{0} {1}", Math.Round(result, 2), metrics[i]);
        }

        public static object ToStruct(this byte[] a, Type structType)
        {
            int size = Marshal.SizeOf(structType);
            IntPtr pbBuffer = Marshal.AllocHGlobal(size);
            Marshal.Copy(a, 0, pbBuffer, size);
            object result = Marshal.PtrToStructure(pbBuffer, structType);
            Marshal.FreeHGlobal(pbBuffer);
            return result;
        }

        public static T FromJSON<T>(this T a, string b)
        {
            return new JavaScriptSerializer().Deserialize<T>(b);
        }

        public static string ToJSON<T>(this T a)
        {
            return new JavaScriptSerializer().Serialize(a);
        }

        public static bool CompareTo(this byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
            return true;
        }

        public static bool IsHex(this string a)
        {
            if (string.IsNullOrEmpty(a)) return false; 
            a = a.Replace("\0", "").Replace(":", "").Replace("-", "").Replace("\r\n", "").Replace("\n", "").Replace(" ", "");
            if (a.Length % 2 != 0) return false;
            char[] valid = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            foreach(char c in a)
            {
                if (!valid.Contains(c)) return false;
            }
            return true;
        }

        public static string ToHex(this byte[] a)
        {
            return BitConverter.ToString(a).Replace("-", "");
        }

        public static string ToUTF8(this byte[] a)
        {
            return Encoding.UTF8.GetString(a);
        }

        public static string ToUnicode(this byte[] a)
        {
            return Encoding.Unicode.GetString(a);
        }

        public static byte[] ToBytes(this string a, bool isHex)
        {
            if (isHex)
            {
                return Enumerable.Range(0, a.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(a.Substring(x, 2), 16)).ToArray();
            }
            return Encoding.UTF8.GetBytes(a);
        }

        public static ushort ToUInt16(this byte[] a, bool returnBigEndian)
        {
            if (returnBigEndian) Array.Reverse(a);
            return BitConverter.ToUInt16(a, 0);
        }

        public static short ToInt16(this byte[] a, bool returnBigEndian)
        {
            if (returnBigEndian) Array.Reverse(a);
            return BitConverter.ToInt16(a, 0);
        }

        public static uint ToUInt32(this byte[] a, bool returnBigEndian)
        {
            if (returnBigEndian) Array.Reverse(a);
            return BitConverter.ToUInt32(a, 0);
        }

        public static int ToInt32(this byte[] a, bool returnBigEndian)
        {
            if (returnBigEndian) Array.Reverse(a);
            return BitConverter.ToInt32(a, 0);
        }

    }

}
