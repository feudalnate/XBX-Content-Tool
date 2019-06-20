using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using PeekPoker.Interface;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace Plugin
{

    public partial class mainForm : Form
    {
        string consoleSerial, motherboardSerial, macAddress, videoStandard, XboxHDKey;
        const int EEPROM_SIZE = 0x100;
        const int XBOXHDKEY_SIZE = 0x10;
        const int DUMP_SIZE = 0x130;
        bool readSuccess = false;

        public mainForm()
        {
            InitializeComponent();
            centerFormTitle();

            Shown += (s, e) =>
            {
                if (!EntryPoint.Rtm.Connect())
                {
                    MessageBox.Show("Failed to connect to Xbox");
                    Close();
                    Dispose();
                }
            };

            readSaveButton.Click += (s, e) =>
            {
                if (!readSuccess)
                {
                    if ((readSuccess = readXboxMemory()))
                    {
                        Win32.SuspendDrawing(this);
                        consoleLabel.Text = string.Format("Console serial: {0}", consoleSerial);
                        motherboardLabel.Text = string.Format("Motherboard serial: {0}", motherboardSerial);
                        macLabel.Text = string.Format("MAC address: {0}", macAddress);
                        videoLabel.Text = string.Format("Video standard: {0}", videoStandard);
                        xboxhdkeyBox.Text = XboxHDKey;
                        readSaveButton.Text = "Save";
                        Win32.ResumeDrawing(this);
                    }
                }
                else
                {
                    using (SaveFileDialog save = new SaveFileDialog())
                    {
                        save.Filter = "INI File (*.ini)|*.ini";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            using (StreamWriter writer = new StreamWriter(save.FileName, false, Encoding.UTF8))
                            {
                                writer.WriteLine("[XBX Content Tool]");
                                writer.WriteLine("Console serial={0}", consoleSerial);
                                writer.WriteLine("Motherboard serial={0}", motherboardSerial);
                                writer.WriteLine("MAC Address={0}", macAddress);
                                writer.WriteLine("Video standard={0}", videoStandard);
                                writer.WriteLine("XboxHDKey={0}", XboxHDKey);
                                writer.Flush();
                                writer.Close();
                            }
                            MessageBox.Show("Saved");
                        }
                    }
                }
            };

        }

        bool readXboxMemory()
        {
            //eeprom can move around from game to game but its usually within range of 0xD0030000-0xD0031000
            EntryPoint.Rtm.DumpLength = 0x1000;
            EntryPoint.Rtm.DumpOffset = 0xD0030000;

            //check if an original xbox game is mounted so we know the eeprom is in memory
            // \Device\CdRom0\default.xbe
            BindingList<SearchResults> offsets = EntryPoint.Rtm.FindHexOffset("5C4465766963655C4364526F6D305C64656661756C742E786265000000000000");
            if (Equals(offsets, null) || offsets.Count == 0)
            {
                MessageBox.Show("An original Xbox game must be running");
                return false;
            }

            //eeprom is always 0x108 bytes away from \Device\CdRom0\default.xbe
            uint EEPROM_OFFSET = uint.Parse(offsets[0].Offset, NumberStyles.HexNumber) + 0x108;
            string offset = Functions.ToHexString(EEPROM_OFFSET);
            string size = Functions.ToHexString(DUMP_SIZE);

            string result = EntryPoint.Rtm.Peek(offset, size, offset, size);
            byte[] buffer = Functions.HexToBytes(result);
            result = null;

            byte[] pbEEPROM = new byte[EEPROM_SIZE];
            byte[] pbXboxHDKey = new byte[XBOXHDKEY_SIZE];

            Array.Copy(buffer, 0, pbEEPROM, 0, EEPROM_SIZE);
            Array.Copy(buffer, (EEPROM_SIZE + 0x20), pbXboxHDKey, 0, XBOXHDKEY_SIZE);
            buffer = null;

            //check if bytes are actually eeprom data so we know the xboxhdkey below it is real
            XboxEEPROM EEPROM = new XboxEEPROM(pbEEPROM);
            pbEEPROM = null;
            if (!EEPROM.IsValid)
            {
                EEPROM = null;
                pbXboxHDKey = null;
                MessageBox.Show("Failed to validate EEPROM data");
                return false;
            }

            consoleSerial= EEPROM.SerialNumber;
            motherboardSerial= BitConverter.ToString(pbXboxHDKey, 4, 8).Replace("-", "");
            macAddress = EEPROM.MACAddress;
            videoStandard = EEPROM.VideoStandard;
            XboxHDKey = Functions.ToHexString(pbXboxHDKey);

            EEPROM = null;
            pbXboxHDKey = null;
            return true;
        }

        void centerFormTitle()
        {
            Graphics g = CreateGraphics();
            double start = ((Width / 2) - (g.MeasureString(Text, Font).Width / 2));
            double widthSpace = g.MeasureString(" ", Font).Width;
            string spaces = "";
            double i = 0;
            while ((i + widthSpace) < start)
            {
                spaces += " ";
                i += widthSpace;
            }
            Text = string.Format("{0}{1}", spaces, Text);
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

    public class EntryPoint : AbstractPlugin
    {
        internal static RealTimeMemory Rtm;

        public EntryPoint()
        {
            Assembly @this = Assembly.GetExecutingAssembly();
            ApplicationName = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(@this, typeof(AssemblyTitleAttribute))).Title;
            Description = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(@this, typeof(AssemblyDescriptionAttribute))).Description;
            Version = ((AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(@this, typeof(AssemblyFileVersionAttribute))).Version;
            Author = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(@this, typeof(AssemblyCompanyAttribute))).Company;
            Icon = Properties.Resources.icon;   
        }

        public override void Display(Form parent)
        {
            Rtm = APRtm;
            mainForm form = new mainForm();
            if (IsMdiChild) form.MdiParent = parent;
            form.Show();
        }
    }

    class XboxEEPROM
    {
        private readonly int EEPROM_SIZE = 0x100;
        private EEPROM e;

        public XboxEEPROM(byte[] pbEEPROM)
        {
            if (Equals(null, pbEEPROM) || pbEEPROM.Length != EEPROM_SIZE)
            {
                IsValid = false;
                return;
            }

            //bring data into struct
            e = (EEPROM)ToStruct(pbEEPROM, typeof(EEPROM));

            //validate factory settings
            byte[] buffer = new byte[0x2C];
            Array.Copy(e.SerialNumber, 0, buffer, 0, 0xC);
            Array.Copy(e.MAC_Address, 0, buffer, 0xC, 0x6);
            Array.Copy(e.Unk_1, 0, buffer, 0x12, 0x2);
            Array.Copy(e.OnlineKey, 0, buffer, 0x14, 0x10);
            Array.Copy(e.VideoStandard, 0, buffer, 0x24, 0x4);
            Array.Copy(e.Unk_2, 0, buffer, 0x28, 0x2);

            byte[] result;
            CRC(out result, buffer, 0x2C);
            if (!CompareTo(e.CRC_MFR_Data, result)) //invalid factory settings CRC - should never happen unless bad eeprom image
            {
                IsValid = false;
                return;
            }

            //validate user settings
            CRC(out result, e.User_Data, 0x9C);

            //invalid user settings CRC - could happen if suddenly lost power during writing settings, in this case the crc would be set to 0xFFFFFFFF and user data zeroed to reset settings
            if (!CompareTo(e.CRC_User_Data, result))
            {
                IsValid = false;
                return;
            }

            IsValid = true;
        }

        /// <summary>
        /// Whether factory and user sections in the EEPROM are valid
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Whether EEPROM is an original xbox eeprom or virtual xbox 360 eeprom
        /// </summary>
        public bool IsVirtual
        {
            get
            {
                //original xbox EEPROM's will always have an online session key
                //virtual xbox 360 EEPROM's have no need for an online session key and it will always be null
                return CompareTo(e.OnlineKey, new byte[0x10]);
            }
        }

        /// <summary>
        /// Console serial number
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return Encoding.UTF8.GetString(e.SerialNumber);
            }
        }

        /// <summary>
        /// MAC address of the consoles network adapter
        /// </summary>
        public string MACAddress
        {
            get
            {
                return BitConverter.ToString(e.MAC_Address).Replace("-", ":");
            }
        }

        /// <summary>
        /// Whether video output from the console is PAL or NTSC format
        /// </summary>
        public string VideoStandard
        {
            get
            {
                byte[] buffer = new byte[4];
                Array.Copy(e.VideoStandard, buffer, 4);
                Array.Reverse(buffer);
                string result = Enum.GetName(typeof(VideoType), BitConverter.ToUInt32(buffer, 0));
                buffer = null;
                return result;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct EEPROM
        {
            //Factory generated settings
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14, ArraySubType = UnmanagedType.U1)]
            public byte[] Hash;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x8, ArraySubType = UnmanagedType.U1)]
            public byte[] Confounder;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10, ArraySubType = UnmanagedType.U1)]
            public byte[] XboxHDKey;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4, ArraySubType = UnmanagedType.U1)]
            public byte[] XBE_Region;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4, ArraySubType = UnmanagedType.U1)]
            public byte[] CRC_MFR_Data;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0xC, ArraySubType = UnmanagedType.U1)]
            public byte[] SerialNumber;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x6, ArraySubType = UnmanagedType.U1)]
            public byte[] MAC_Address;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x2, ArraySubType = UnmanagedType.U1)]
            public byte[] Unk_1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10, ArraySubType = UnmanagedType.U1)]
            public byte[] OnlineKey;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4, ArraySubType = UnmanagedType.U1)]
            public byte[] VideoStandard;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4, ArraySubType = UnmanagedType.U1)]
            public byte[] Unk_2;

            //Stored user settings

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4, ArraySubType = UnmanagedType.U1)]
            public byte[] CRC_User_Data;

            //skip parsing the rest of the EEPROM, only user specific setting are stored here
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x9C, ArraySubType = UnmanagedType.U1)]
            public byte[] User_Data;


            //I could've wrote the rest of the structure here but I didn't have any need for anything from this section, only the CRC check
            //below is the rest of the structure in c++ format, the above structure was ported from the LiveInfo public source code

            //BYTE TimeZoneBias[4];           // 0x64 - 0x67   Zone Bias?
            //UCHAR TimeZoneStdName[4];       // 0x68 - 0x6B   Standard timezone
            //UCHAR TimeZoneDltName[4];       // 0x5C - 0x6F   Daylight timezone
            //BYTE UNKNOWN4[8];               // 0x70 - 0x77   Unknown Padding ?
            //BYTE TimeZoneStdDate[4];        // 0x78 - 0x7B   10-05-00-02 (Month-Day-DayOfWeek-Hour) 
            //BYTE TimeZoneDltDate[4];        // 0x7C - 0x7F   04-01-00-02 (Month-Day-DayOfWeek-Hour) 
            //BYTE UNKNOWN5[8];               // 0x80 - 0x87   Unknown Padding ?
            //BYTE TimeZoneStdBias[4];        // 0x88 - 0x8B   Standard Bias?
            //BYTE TimeZoneDltBias[4];        // 0x8C - 0x8F   Daylight Bias?
            //BYTE LanguageID[4];             // 0x90 - 0x93   Language ID
            //BYTE VideoFlags[4];             // 0x94 - 0x97   Video Settings
            //BYTE AudioFlags[4];             // 0x98 - 0x9B   Audio Settings
            //BYTE ParentalControlGames[4];   // 0x9C - 0x9F   0=MAX rating
            //BYTE ParentalControlPwd[4];     // 0xA0 - 0xA3   7=X, 8=Y, B=LTrigger, C=RTrigger, etc.
            //BYTE ParentalControlMovies[4];  // 0xA4 - 0xA7   0=Max rating
            //BYTE XBOXLiveIPAddress[4];      // 0xA8 - 0xAB   XBOX Live IP Address..
            //BYTE XBOXLiveDNS[4];            // 0xAC - 0xAF   XBOX Live DNS Server..
            //BYTE XBOXLiveGateWay[4];        // 0xB0 - 0xB3   XBOX Live Gateway Address..
            //BYTE XBOXLiveSubNetMask[4];     // 0xB4 - 0xB7   XBOX Live Subnet Mask..
            //BYTE OtherSettings[4];          // 0xA8 - 0xBB   Other XBLive settings ?
            //BYTE DVDPlaybackKitZone[4];     // 0xBC - 0xBF   DVD Playback Kit Zone
            //BYTE UNKNOWN6[64];			  // 0xC0 - 0xFF   Unknown Codes / History ?
        }

        private enum VideoType : uint
        {
            NTSC = 0x14000,
            PAL = 0x38000
        }

        private void CRC(out byte[] pbResult, byte[] pbData, int cbData)
        {
            //method ported from LiveInfo public source code

            byte[] buffer = new byte[cbData + 4];
            Array.Copy(pbData, 0, buffer, 1, (cbData - 1));
            Array.Copy(pbData, (cbData - 1), buffer, 0, 1);
            pbResult = new byte[4];
            ushort value;
            for (int a = 0; a < 4; a++)
            {
                value = 0xFFFF;
                for (int b = a; b < cbData; b += 4)
                {
                    value = (ushort)(value - BitConverter.ToUInt16(buffer, b));
                }
                pbResult[a] = (byte)((value & 0xFF00) >> 8);
            }
            buffer = null;
        }

        private object ToStruct(byte[] buffer, Type structType)
        {
            int size = Marshal.SizeOf(structType);
            IntPtr pbBuffer = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, 0, pbBuffer, size);
            object result = Marshal.PtrToStructure(pbBuffer, structType);
            Marshal.FreeHGlobal(pbBuffer);
            return result;
        }

        private bool CompareTo(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
            return true;
        }

    }

}
