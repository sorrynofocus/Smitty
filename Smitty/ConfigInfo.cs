using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smitty
{
    /*
      This class deals with the configuration info in smitty.ini. The ConfigInfo class handles all configurations. TheConfigInfo
      depends on the INIFile Class to read/write configuration data.
      
      Here's an example smitty.ini file:
        [application]
        DaysToRemove=599
        Destructive=false
        LastModified=true
        ClearUserTemp=false
        LastAccessed=true
        LogFile=FILEZ.log
        NoParentFiles=false


        [directories]
        CustomDirs=S:\output|//|*.*;c:\windows|//|*.*;C:\temp\YOU_CAN_REM|//|*.*;C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys|*.*;

        APPLICATION section applies to the applicationconfigration settings. The DIRECTORIES is the user configuration for directory seaches.
       
        TODO:
        - In the future, the smittty.ini will use XML to handle configurations.
        - The class will eventully use YIELD from IEnumerator to parse and handle the directory options. Currently, it's all handled
        through parsing. 

    */


    class ConfigInfo
    {

        public int iID;
        public string sDirName;
        public List<string> sPattern = new List<string>();
        public bool bEnabled = true;

        private string[] arRawData;

        public ConfigInfo()
        {

        }

        // This method will obtain the directory specification only.
        public string GetDirSpec(string sRawDir)
        {
            this.arRawData = sRawDir.Split('|');
            this.sDirName = this.arRawData[0];
            return (this.sDirName);
        }

        // This method is used to readon in config and obtain the search patterns to break it down into this.sPattern for future use.

        public List<string> GetPatternSpec(string sRawPattern)
        {
            string[] lRawData = sRawPattern.Split('|');
            //string sTMP = "";

            //We start at 1 because 0 contains the dirname, anything after that contains the specs.
            for (int iIndex = 1; iIndex < lRawData.Length; iIndex++)
            {
                //Does it contain a DISABLED mark? If so, disable in search
                if ((lRawData[iIndex] == "//"))
                    this.bEnabled = false;

                if ((lRawData[iIndex] != ""))
                {
                    //sTMP += lRawData[iIndex];
                    this.sPattern.Add(lRawData[iIndex]);

                }
            }
            return (sPattern);
        }

        // This method will return a list of search patterns that we've gathered from direct user input.
        public List<string> GetCustPatternSpec(string sRawPattern)
        {
            string[] lRawData = sRawPattern.Split(new char[] { '|', ',', ' ' });
            //string sTMP = "";

            for (int iIndex = 0; iIndex < lRawData.Length; iIndex++)
            {
                if ((lRawData[iIndex] != ""))
                {
                    //sTMP += lRawData[iIndex];
                    this.sPattern.Add(lRawData[iIndex]);
                }
            }

            return (sPattern);
        }

        //This ENABLES the user to include dirctory in search instead of removing it.
        // April 23 2019 -works
        public void EnableDirOption()
        {
            for (int iIndex = 0; iIndex < this.sPattern.Count; iIndex++)
            {
                if ((this.sPattern[iIndex] == "//"))
                {
                    this.sPattern.RemoveAt(iIndex);
                    this.bEnabled = true;
                }
            }


        }

        //This DISABLES the user to include dirctory in search instead of removing it.
        // NOT COMPLETE
        public void DisableDirOption(int iIndexPoint)
        {
            //                for (int iIndex = 0; iIndex < this.sPattern.Count; iIndex++)
            //                {
            //                    if ((this.sPattern[iIndex] == "//"))
            //                    {
            //this.sPattern.RemoveAt ( iIndex );
            this.bEnabled = false;
            //this.sDirName += "|//|";
            this.sPattern.Insert(0, "//");
            //                    }
            //                }


        }


        // This method will format the search patterns for the UI display only
        public string FormatDirPatternListUI()
        {
            string sTMP = "";
            string sRetData = this.sDirName + " ( ";

            for (int iIndex = 0; iIndex < this.sPattern.Count; iIndex++)
            {
                //If this has a DISABLED mark in config...
                if ((this.sPattern[iIndex] == "//"))
                {
                    sTMP += "[DISABLED] ";
                    continue;
                }

                sTMP += this.sPattern[iIndex];
                sTMP += " ";
            }
            sRetData += sTMP;
            sRetData += ")";
            return (sRetData);
        }

        // This method will format the search patterns to be saved or processed.
        // For example: c:\temp|*.txt,*.cpp;
        public string FormatDirPatternListConfig()
        {
            string sTMP = "";
            string sRetData = "";
            int iCount = this.sPattern.Count;

            //If no patterns, just return dirname option
            if (iCount == 0)
            {
                //sRetData = this.sDirName + ";";
                return (";");
            }

            for (int iIndex = 0; iIndex < iCount; iIndex++)
            {
                sTMP += "|";
                sTMP += this.sPattern[iIndex];
                //if (iCount <= 1)
                //  sTMP += ";";
            }
            sRetData += sTMP;
            sRetData += ";";
            return (sRetData);
        }


    }
}
