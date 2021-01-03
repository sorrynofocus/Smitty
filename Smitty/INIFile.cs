using System.Runtime.InteropServices;
using System.Text;

namespace Smitty
{
    //Here, we import a function from dll to use some win32 APIs.
    //Included is doc summary. We only need two function to do four things. 
    // Anyway.... My therapy session is on Friday.
    // Before coding:
    //
    //  ( ͡° ͜ʖ ͡°)
    //
    // After coding:
    //
    //  ( ͡⊙ ͜ʖ ͡⊙)

    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string sFilePath;
        int iBufferSize = 1024;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sSection, string sKey, string sKeyVal, string sFilePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sSection, string sKey, string sDefault, StringBuilder sRetVals, int iSize, string sFilePath);

        /// <summary>
        /// INIFile Constructor. IniWrite/Read isn't thread safe, but then again, INI file calls are quite fast enough dll importing.
        /// </summary>
        /// <PARAM name="sINIFilePath">The full path to the config file.</PARAM>
        public IniFile(string sINIFilePath)
        {
            sFilePath = sINIFilePath;
        }


        /// <summary>
        /// Write configurations to an INI
        /// </summary>
        /// <PARAM name="sSection">The section key of the config file</PARAM>
        /// <PARAM name="sKey">The key variable of the config</PARAM>
        /// <PARAM name="sValue">the value representation for the sKey value</PARAM>
        public void IniWrite(string sSection, string sKey, string sValue)
        {
            WritePrivateProfileString(sSection, sKey, sValue, this.sFilePath);
        }


        /// <summary>
        /// Clear a value within a key under a section of INI file.
        /// </summary>
        /// <PARAM name="sSection">The section of the config to read from</PARAM>
        /// <PARAM name="sKey">The key variable to get the value from</PARAM>
        public void IniClearKeyVal(string sSection, string sKey)
        {
            WritePrivateProfileString(sSection, sKey, null, this.sFilePath);
        }


        /// <summary>
        /// Clear a section within the INI file
        /// </summary>
        /// <PARAM name="sSection">The section area of the config file</PARAM>
        /// <returns>none</returns>
        public void IniClearSecton(string sSection)
        {
            WritePrivateProfileString(sSection, null, null, this.sFilePath);
        }


        /// <summary>
        /// Read configurqation from an INI file
        /// </summary>
        /// <PARAM name="sSection">The section of the config to read from</PARAM>
        /// <PARAM name="sKey">The key variable to get the value from</PARAM>
        /// <returns>the value from the key located in the section</returns>
        public string IniRead(string sSection, string sKey)
        {
            StringBuilder sBuffer = new StringBuilder(this.iBufferSize);
            int iNumCharsinBuffer = GetPrivateProfileString(sSection, sKey, "", sBuffer, this.iBufferSize, this.sFilePath);
            return (sBuffer.ToString());
        }
    }
}
