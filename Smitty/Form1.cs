/* Smitty
 * 
 * C. Winters / US / California / Culver City
 * May. 2018
 * 
 * Version: Beta/smitty
 * If it doesn't work, I didn't write it.
 * 
 * Purpose - machine system info/maint utility for windows. A nod to the AIX UNIX System Management Interface Tool
 * Smitty is defined as a utility to help automate configuration and updating machines. It is intended to:
 *
 * - Clean temporary files, including customised directories, on specific time periods  -COMPLETE
  * - Able to push software by FTP. - Library 96% complete. Need to test.
 * - Able to install pushed software
 * - Able to recognise custom install scripts and an internal command line interpreter (TinyMAN [tiny -mobil automation network) will aid in installation.
 * - Able to push commands to run or operate on machine as if the person was logged into it. The internal command line interpreter (TinyMAN) will aid in automating tasks.
 * - (Future R&D) Create a mobile app to use TinyMAN to perform automated tasks during after hours.
 * - (FUTURE R&D) synthetic intelligence to gather known troubleshooting issues in order to automate fixes instead of user repeating fixes. (Will use MySQL type database)
 * - Auto update when future releases are developed. 
 * - Able to configure auto-logins, registry tweaks, options and save options via INI, XML, or registry. Currently, INI is used but will switch to XML based on user experience.
 * - Able to gather inventory of machine and generate report to send to end users. The inventory will be software versions, install locations, memory, CPU, etc. It can be transported using TinyMAN scripts and FTP.
 * - (FUTURE R&D) Able to detect some machine changes. Monitor registry dumps and certain directories for changes and generate reports.
 * - Display drive information and able to export to to a file. -COMPLETE
 * - Re-org this code! Messy! Prissy! Diva!
 * 
 * NOTES:
 * There's still a lot of work, but getting the temp dir/file removals are a priority. That's 95% complete. Testing has been successful. Bugs not tracked yet.
 * See TODOs for additional work on this rev.
 *
 * 
 * 
 * Example usage:
 * If not using UI, then it can be automated via command line.
 *
 * smitty /autoclean /cfg C:\source\repos\Smitty\Smitty-1.1.0.0\Smitty\bin\Debug\smitty.ini /log C:\source\repos\Smitty\Smitty-1.1.0.0\Smitty\bin\Debug\FIL2.txt
 * 
 * 

 * TODO: investigate this.TNANotify1.Icon = new Icon ( GetType (), "sleeping-pig.ico"); when moving ico to a folder, then how would you obtain resource? the resource (see properties on resource) are embedded but are not picked up 
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//For DllImport

using System.Xml;

// for Process.Start
using System.Diagnostics;


namespace Smitty
{

    public partial class frmMain : Form
    {
        #region GLOBALS - HEAP
        private string folderName, pItemIterator, 
                       sMessage, sConfigBuffer       = "";

        private bool    bExitApp, bIsCancelling,
                        bIsAutoClean, bIsLogging,
                        bNoParentFiles              = false;

        // iSelectedIndex -> selected index from lstUserDirectoryOptions directory listbox
        long lAmountDirsFound, lAmountFilesFound,
             iSelectedIndex                         = 0L;

        //Timer ticker value to refresh drives.
        int iRefreshDrives                          = 0;


        //3700000 isn't REALLY an hour, but we want to go a tad over.
        public static int GLOBAL_INT_HOUR = 3700000;

        //This is just testing the timer ticker during debug.
        //public static int GLOBAL_INT_HOUR = 5000;
        #endregion GLOBALS -HEAP

        #region STRINGTABLE
        public static string STRING_APPLICATION                         = "application";
        public static string STRING_INFO_OLDER                          = " - yes: older than ";
        public static string STRING_INFO_SEARCH_COMPLETE_DESTRUCTIVE    = "Finished cleaning. Sleeping for an hour...";
        public static string STRING_INFO_SEARCH_COMPLETE_NONDESTRUCTIVE = "Finished searching. Sleeping for an hour...";
        public static string STRING_INFO_DAYOLDERLABEL_001              = "day old";
        public static string STRING_INFO_DAYOLDERLABEL_002              = "days old";
        public static string STRING_INFO_DAYOLDERLABEL_003              = "months old";
        public static string STRING_INFO_DAYOLDERLABEL_004              = "month old";
        public static string STRING_INFO_YEAROLDERLABEL_001             = "year old";
        public static string STRING_INFO_YEAROLDERLABEL_002             = "years old";
        #endregion STRINGTABLE

        #region INIConfig, ConfigInfo, ConfigData, and Utility OBJ CREATE
        //TODO hard-coded INI file that is in same directory needs to be customised.
        IniFile pConfig = new IniFile(SmittyPRG.STRING_CONFIG_FILE);
        ConfigInfo configinfo = new ConfigInfo();
        List<ConfigInfo> ConfigData = new List<ConfigInfo>();
        Utility ut = new Utility();
        #endregion

        #region frmMain()  --- INIT --- 
        public frmMain()
        {
            InitializeComponent ();
        }
        #endregion

        // SEARCH  // // // // // // // // // // // // // // // // // // // // // //

        #region void ClearTempFiles()
        //Threaded func to clear temp files. 
        //TO PUT IN EXTRA TEMP CLEANING STUFF...
        /*
            for /D %%x in ("%SystemDrive%\Users\*") do (
                dir "%%x\*.blf" 
                dir  "%%x\*.regtrans-ms" 
                dir  "%%x\AppData\LocalLow\Sun\Java\*" 
                dir  "%%x\AppData\Local\Google\Chrome\User Data\Default\Cache\*" 
                dir  "%%x\AppData\Local\Google\Chrome\User Data\Default\JumpListIconsOld\*" 
                dir  "%%x\AppData\Local\Google\Chrome\User Data\Default\JumpListIcons\*" 
                dir  "%%x\AppData\Local\Google\Chrome\User Data\Default\Local Storage\http*.*" 
                dir  "%%x\AppData\Local\Google\Chrome\User Data\Default\Media Cache\*" 
                dir  "%%x\AppData\Local\Microsoft\Internet Explorer\Recovery\*" 
                dir  "%%x\AppData\Local\Microsoft\Terminal Server Client\Cache\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\Caches\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\Explorer\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\History\low\*" /AH 
                dir  "%%x\AppData\Local\Microsoft\Windows\INetCache\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\Temporary Internet Files\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\WER\ReportArchive\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\WER\ReportQueue\*" 
                dir  "%%x\AppData\Local\Microsoft\Windows\WebCache\*" 
                dir  "%%x\AppData\Local\Temp\*" 
                dir  "%%x\AppData\Roaming\Adobe\Flash Player\*" 
                dir  "%%x\AppData\Roaming\Macromedia\Flash Player\*" 
                dir  "%%x\AppData\Roaming\Microsoft\Windows\Recent\*" 
                dir  "%%x\Recent\*" 
                dir "%%x\Documents\*.tmp" 
            )
        */
        void ClearTempFiles()
        {
            //Clear the user temp first.
            if (cbClearUserTemp.Checked)
            {
                if (!cbHushOutput.Checked)
                {
                    lbFilesProcessed.Items.Add(" ");
                    lbFilesProcessed.Items.Add("Processing Temp files...");
                }

                if (cbDestructive.Checked)
                {
                    System.Threading.Thread threadDirSearch = new System.Threading.Thread(() =>
                    {
                        DirFileSearchOption(System.IO.Path.GetTempPath(), "*.*", true, true);
                    }
                    );
                    threadDirSearch.Start();
                }
                else
                {
                    System.Threading.Thread threadDirSearch = new System.Threading.Thread(() =>
                    {
                        DirFileSearchOption(System.IO.Path.GetTempPath(), "*.*", true, false);
                    }
                    );
                    threadDirSearch.Start();
                }
            }
        }
        #endregion

        #region private void PerformSearchOpUI(bool bFlag)
        //When search starts, modify UI. When it cancels or done, reset
        // true - search started
        // false - search has ended/canceled 
        private void PerformSearchOpUI(bool bFlag)
        {
            if (bFlag)
            {
                this.TNANotify1.Icon = new Icon(GetType(), "sleeping-pig.ico");

                lbFilesProcessed.Items.Clear();

                txtUserDirEntry.Enabled = false;
                btnSearch.Text = "Searching...";
                this.Cursor = Cursors.WaitCursor;
                lbFileAmountFound.Text = "";
                lbDirAmountFound.Text = "";
                lAmountDirsFound = 0;
                lAmountFilesFound = 0;
                //btnCancelSearch.Enabled = true;
                bIsCancelling = false;
                pictureBoxSearchStat.BackColor = Color.Red;

                Application.DoEvents();
            }
            else
            {
                Application.DoEvents();
                btnSearch.Text = "Search";
                this.Cursor = Cursors.Default;
                lstUserDirectoryOptions.Enabled = true;
                txtUserDirEntry.Enabled = true;
                this.TNANotify1.Icon = new Icon(GetType(), "sleeping-pig.ico");
                bIsCancelling = false;
                //btnCancelSearch.Enabled = false;
                pictureBoxSearchStat.BackColor = Color.LightGreen;
                Application.DoEvents();
            }
        }
        #endregion

        #region public bool PerformSearchOp()
        //Performs the search operation. Separate because command line and 
        //components use it.
        //April 23 2019 ~testicles!~ - works!
        public bool PerformSearchOp()
        {
            //Move this OUT of this function. Also at bottom. Not good on THREADING
            PerformSearchOpUI(true);
            //            if (! IsAutoClean)


            int iCustomDays = 0;
            //int.TryParse ( lblDaysToRemove.Text, out iCustomDays );
            //int.TryParse ( lblDaysToRemove.Text, out iCustomDays );

            //iCustomDays = trackbarDaysToOperate.Value;

            for (int iIndex = 0; iIndex < ConfigData.Count; iIndex++)
            {
                //string pItemFound = lstUserDirectoryOptions.Items[iIndex].ToString ();
                string pItemFound = ConfigData[iIndex].sDirName;


                //Did we disable this in search? If so, skip...
                if (!ConfigData[iIndex].bEnabled)
                {
                    if (!cbHushOutput.Checked)
                    {
                        lbFilesProcessed.Items.Add("DISABLED, skipping: " + pItemFound + " ");
                        lbFilesProcessed.Update();
                    }
                    continue;
                }


                if (!Directory.Exists(pItemFound))
                {
                    if (!cbHushOutput.Checked)
                    {

                        lbFilesProcessed.Items.Add("Not exist/not processing: " + pItemFound);
                        lbFilesProcessed.Update();
                    }
                    continue;
                }

                //Okay, we have the the directory specification to examine. Now iterate through the pattern(s)
                //for the directory specification and perform operations.
                string sIterPattern = "";

                for (int iPatternIndex = 0; iPatternIndex < ConfigData[iIndex].sPattern.Count; iPatternIndex++)
                {
                    sIterPattern = ConfigData[iIndex].sPattern[iPatternIndex];

                    if (!cbHushOutput.Checked)
                    {
                        lbFilesProcessed.Items.Add(" ");
                        lbFilesProcessed.Items.Add("Processing: " + pItemFound + " -> " + sIterPattern);
                    }

                    if (cbDestructive.Checked)
                    {
                        //THREADED!
                        System.Threading.Thread threadDirSearch = new System.Threading.Thread(() =>
                        {
                            DirFileSearchOption(pItemFound, sIterPattern, true, true);
                        }
                        );
                        threadDirSearch.Start();
                    } // if cbDestructive
                    else
                    {
                        //Just list directories and files. THREADED!
                        System.Threading.Thread threadDirSearch = new System.Threading.Thread(() =>
                        {
                            DirFileSearchOption(pItemFound, sIterPattern, true, false);
                        }
                        );
                        threadDirSearch.Start();
                    }
                }
            } //end of for (int i = 0; i < lstUserDirectoryOptions.

            PerformSearchOpUI(false);
            return (true);
        }
        #endregion

        #region void DirFileSearchOption(string sDir, string pParam, bool bRecursive, bool bDelete)
        /// <summary>
        /// This is used to find files/dirs with options. 
        /// This function is the function being used as main engine of finding files.
        /// Future: replace this using Win32 FindFirstFile() FindNextFile() because Directory.GetDirectory() is NOT thread safe, or threaded.
        /// Other areas to remove cached files:
        /// C:\Windows\SoftwareDistribution\Download - default location of Windows 10 update file
        /// NOTE: Use net stop wuauserv to stop service !
        ///
        /// C:\Windows\Prefetch - used to speed up the loading of boot files.
        /// The RegKey is under:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters
        /// Key: EnablePrefetcher
        /// 0 - Disabled : The prefetch system is turned off.
        ///
        /// 1 - Application : The prefetch only caches applications.
        ///
        /// 2 - Boot : The prefetch only caches boot system files.
        ///
        /// 3 - All : The prefetch caches boot, and application files.
        ///
        /// C:\Users\%username%\AppData\Local\Microsoft\Windows\Explorer - Iconcache/Thumbnail area, del iconcache_*.db, thumbcache_*.db 
        /// C:\Users\%username%\Downloads - downloads area.
        /// 
        /// </summary>
        /// <param name="sDir">The directory to search into</param>
        /// <param name="pParam">The directory search options</param>
        /// <param name="bRecursive">Set option o recurse into sub-directories</param>
        /// <param name="bDelete">Set option to delete file if found</param>
        void DirFileSearchOption(string sDir, string pParam, bool bRecursive, bool bDelete)
        {
            //Threading.. If user pressed cancel, init bool
            if (bIsCancelling)
                return;

            //If no params, then set default options.
            if (pParam == "")
                pParam = "*.*";

            //This will be the custom days to look for files. Example: Find file 90 days old.
            int iCustomDays = 0;


            //TODO Since threading, move to global var
            //int.TryParse(lblDaysToRemove.Text, out iCustomDays);

            //CHANGED to trackbaar because lbldaystoremove may contains years
            iCustomDays = trackbarDaysToOperate.Value;

            string sLastKnownDir = "";

            //Amount of days returned as array: created, lastwrite, and last access 
            double[] dSecondsDifference;
            //StringBuilder sbTemp = new StringBuilder ();

            //If recursive....
            if (bRecursive)
            {
                try
                { //Thread this

                    foreach (string pDirectory in Directory.GetDirectories(sDir))
                    {
                        if (bIsCancelling)
                            return;

                        lAmountDirsFound++;
                        lbDirAmountFound.Text = lAmountDirsFound.ToString();
                        pictureBoxSearchStat.BackColor = Color.Red;

                        Application.DoEvents();
                        lbDirAmountFound.Update();

                        lbFileAmountFound.Update();
                        sLastKnownDir = pDirectory;


                        //Get files would need a loop here to search for multiple extensions.
                        // Like this
                        //
                        // Create an array of filter string
                        //string[] MultipleFilters = Filter.Split ( '|' );
                        //
                        // for each filter find mathing file names
                        //foreach (string FileFilter in MultipleFilters)
                        //{
                        // add found file names to array list
                        //    alFiles.AddRange ( Directory.GetFiles ( SourceFolder, FileFilter, searchOption ) );
                        //}
                        //
                        foreach (string sFileName in Directory.GetFiles(pDirectory, pParam))
                        {
                            lAmountFilesFound++;
                            lbFileAmountFound.Text = lAmountFilesFound.ToString();
                            pictureBoxSearchStat.BackColor = Color.Yellow;
                            Application.DoEvents();
                            lbFileAmountFound.Update();

                            //Check to see if the file is older than the days we set to. If 0, then find all the files.
                            if (IsFileOlderThanCustomDays2(sFileName, iCustomDays, out dSecondsDifference))
                            {
                                if (bDelete)
                                {

                                    if (!cbHushOutput.Checked)
                                        lbFilesProcessed.Items.Add("Removing: " + sFileName);

                                    //sbTemp.AppendFormat ( "*** Different! *** creationdate: {0} lastwrite: {1} lastaccess: {2}", dSecondsDifference[0], dSecondsDifference[1], dSecondsDifference[2] );
                                    FileAttributes fileAttributes = File.GetAttributes(sFileName);
                                    try
                                    {
                                        File.SetAttributes(sFileName, FileAttributes.Normal);
                                        File.Delete(sFileName);
                                    } //Exception in case of access denied.
                                    catch (Exception ex)
                                    {
                                        //sbTemp.AppendFormat ( "*** ERROR *** {0}", ex.Message );
                                        //MessageBox.Show(ex.Message);
                                        if ((ex is System.IO.IOException) || ex.Message == "Access to the dir path is denied.")
                                        {
                                            if (!cbHushOutput.Checked)
                                                lbFilesProcessed.Items.Add("Access denied (security/directory used by another process): " + sFileName);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!cbHushOutput.Checked)
                                        lbFilesProcessed.Items.Add(sFileName);
                                }
                            }
                            else
                            {
                                //If the file isn't older than our custom days, then do not add.
                                pictureBoxSearchStat.BackColor = Color.Tomato; 
                            }

                            if (!cbHushOutput.Checked)
                                lbFilesProcessed.Update();
                        }

                        //If deleting option, then remove the file via recursive call.
                        if (bDelete)
                            DirFileSearchOption(pDirectory, pParam, bRecursive, bDelete);
                        else
                            DirFileSearchOption(pDirectory, pParam, bRecursive, false);

                        //Remove the last known directory since we came out of it...
                        if (bDelete)
                        {
                            bool IsEmptyDirectory = false;
                            IsEmptyDirectory = IsDirectoryEmpty(sLastKnownDir);

                            if (IsEmptyDirectory)
                            {
                                if (!cbHushOutput.Checked)
                                    lbFilesProcessed.Items.Add("Removing dir: " + sLastKnownDir);

                                try
                                {
                                    DirectoryInfo dirs = new DirectoryInfo(sLastKnownDir);
                                    dirs.Delete();
                                }
                                catch (Exception ex)
                                {
                                    ;
                                    if (!cbHushOutput.Checked)
                                        lbFilesProcessed.Items.Add("Could not remove: " + sLastKnownDir + " Error: " + ex.ToString());
                                }
                            }
                            //Means we did not find any files that match an older criteria.
                        }
                        //Means we did not find any files that match an older criteria.
                    } //foreach (string pDirectory in Directory.GetDirectories...
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }
            else
            {
                //If not recursive...
                try
                {
                    foreach (string sFileName in Directory.GetFiles(sDir, pParam))
                    {
                        lAmountFilesFound++;
                        lbFileAmountFound.Text = lAmountFilesFound.ToString();

                        if (!cbHushOutput.Checked)
                        {
                            lbFilesProcessed.Items.Add(". " + sFileName);
                            lbFilesProcessed.Update();
                        }
                    }
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }

            }

            if (bIsCancelling)
                return;

            //Do we look for files/folders in the parent starting directory? 
            //If bIsLNoParentFiles is false, then we include them. If true, do not include them
            if (bNoParentFiles != true)
            {
                //Do we check for files in parent directory here?
                //Added for files within parent dir. Look for files within parent first, then continue..
                foreach (string sFileName in Directory.GetFiles(sDir, pParam))
                {
                    FileAttributes fileAttributes = File.GetAttributes(sFileName);

                    if (fileAttributes.HasFlag(FileAttributes.Directory))
                    {
                        //It's a directory... 
                        ;
                    }
                    else
                    //It's a file..
                    {
                        try
                        {
                            if (IsFileOlderThanCustomDays2(sFileName, iCustomDays, out dSecondsDifference))
                            {
                                //
                                if (bDelete)
                                {
                                    try
                                    {
                                        FileInfo pFileInfo = new FileInfo(sFileName);
                                        pFileInfo.Attributes = ~FileAttributes.Hidden & ~FileAttributes.Archive & ~FileAttributes.ReadOnly;

                                        pFileInfo.Delete();
                                        //sbTemp.AppendFormat("*** Different! *** creationdate: {0} lastwrite: {1} lastaccess: {2}", dSecondsDifference[0], dSecondsDifference[1], dSecondsDifference[2]);
                                        if (!cbHushOutput.Checked)
                                            lbFilesProcessed.Items.Add("Removing file: " + sFileName);
                                    }
                                    //TODO catch exception Access Denied
                                    catch (Exception ex)
                                    {
                                        if ((ex is System.IO.IOException) || ex.Message == "Access to the path is denied.")
                                        {
                                            if (!cbHushOutput.Checked)
                                                lbFilesProcessed.Items.Add("Access denied (security/file used by another process): " + sFileName);
                                        }
                                    }
                                }
                                else
                                {

                                    if (!cbHushOutput.Checked)
                                        //if not deleting, just add file(s) to the list.
                                        lbFilesProcessed.Items.Add(sFileName);
                                }
                            }  //else didn't find any older criteria? Don't add filename to list.
                        }
                        //TODO catch exception Access Denied
                        catch (Exception ex)
                        {
                            ;
                            if ((ex is System.IO.IOException))
                            {
                                if (!cbHushOutput.Checked)
                                    lbFilesProcessed.Items.Add("Tracked error on: " + sFileName + " Error: " + ex.ToString());
                            }
                            //MessageBox.Show(ex.Message);
                        }
                    }
                }//End of newly added files only *******
            } // End of bParentFiles
            pictureBoxSearchStat.BackColor = Color.LightGreen;
        }
        #endregion


        // SUPPLEMENTAL // // // // // // // // // // // // // // // // // // // // // //
        #region public bool IsDirectoryEmpty(string sPath)
        /// <summary>
        /// Checks to see if a directory is empty, or not.
        /// </summary>
        /// <param name="sPath">The directory you want to evaluate</param>
        /// <returns>true if dir is empty, false otherwise</returns>
        public bool IsDirectoryEmpty(string sPath)
        {
            return !Directory.EnumerateFileSystemEntries ( sPath ).Any ();
        }
        #endregion

        #region public void ReadDirOptions()
        public void ReadDirOptions()
        {
            //TODO:
            //Patterns are implemented, but not used at this time. Component is invisible.
            txtFilePattern.Text = pConfig.IniRead ( "directories", "pattern" );

            //TODO: When adding any directory, we must check and see if it is VALID!
            //TODO: Convert to XML usage AND put config string in string table.
            sConfigBuffer = pConfig.IniRead ( "directories", "CustomDirs" );

            List<string> sConfigDir = sConfigBuffer.Split ( ';' ).ToList ();

            for (int iIndex = 0; iIndex < sConfigDir.Count; iIndex++)
            {
                if ((sConfigDir[iIndex] != ""))
                {
                    ConfigData.Add ( new ConfigInfo () );
                    ConfigData[iIndex].iID = iIndex;
                    ConfigData[iIndex].GetDirSpec ( sConfigDir[iIndex] );

                    //List<string> test = ConfigIterList2[iIndex].GetPatternSpec ( sConfigDir[1] ).ToList();
                    ConfigData[iIndex].GetPatternSpec ( sConfigDir[iIndex] );

                    lstUserDirectoryOptions.Items.Add ( ConfigData[iIndex].FormatDirPatternListUI () );
                }
            }
        }
        #endregion

        #region public void ReadConfigs()
        //Engine to gather configuration for application use.
        public void ReadConfigs()
        {
            // Read in the directory/pattern options.
            ReadDirOptions ();

            //Get the refresh drives to STAT. If the config doesn't exist, then create a default for ten seconds.
            // If it does exist, then set the user second amoutn
            int.TryParse(pConfig.IniRead("application", "RefreshDrives"), out iRefreshDrives);
            if (iRefreshDrives == 0)
            {
                iRefreshDrives = 300; //= 5 minutes
                TimerTicker_03_STATDrives.Interval = (iRefreshDrives * 1000);
                TimerTicker_03_STATDrives.Enabled = true;
                pConfig.IniWrite("application", "RefreshDrives", "300");
            }
            else
            {
                TimerTicker_03_STATDrives.Interval = (iRefreshDrives * 1000);
                TimerTicker_03_STATDrives.Enabled = true;
            }
            

            //let's get the sliderbar and custom days configured.                 
            int iDaystoRemove = 0;

            int.TryParse ( pConfig.IniRead ( "application", "DaysToRemove" ), out iDaystoRemove );

            trackbarDaysToOperate.Value = iDaystoRemove;
            AdjustTrackBarPositionRange();

            //lblDaysToRemove.Text = trackbarDaysToOperate.Value.ToString();
            //lblDaysToRemove.Text = numericUpDownDaysToOperate.Value.ToString();
            lblDaysToRemove.Update();

            Application.DoEvents();

            //if (trackbarDaysToOperate.Value > 1.00)
            //if (numericUpDownDaysToOperate.Value > 1)
            //{
            //    lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_002;
           //}
           // else
            //    lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_001;


            if (pConfig.IniRead ( "application", "LastModified" ) == "true")
                cbLastWriteCheck.Checked = true;
            else
                cbLastWriteCheck.Checked = false;

            if (pConfig.IniRead ( "application", "LastAccessed" ) == "true")
                cbLastAccessedCheck.Checked = true;
            else
                cbLastAccessedCheck.Checked = false;

            if (pConfig.IniRead ( "application", "Destructive" ) == "true")
                cbDestructive.Checked = true;
            else
                cbDestructive.Checked = false;

            if (pConfig.IniRead ( "application", "ClearUserTemp" ) == "true")
                cbClearUserTemp.Checked = true;
            else
                cbClearUserTemp.Checked = false;

            if (pConfig.IniRead("application", "NoParentFiles") == "true")
            {
                checkBoxDontProcessParentFolderFiles.Checked = true;
                bNoParentFiles = true;
            }
            else
            {
                checkBoxDontProcessParentFolderFiles.Checked = false;
                bNoParentFiles = false;
            }

            //Read in custom logfile via config. This will overrise the switch /log
            string sIsLogFile = pConfig.IniRead ( "application", "LogFile" );

            if (!System.String.IsNullOrEmpty ( sIsLogFile ))
            {
                bIsLogging = true;

                //If we haven't overridden it via commnad line, then set log.
                if (!SmittyPRG.bByCmdLine)
                    SmittyPRG.STRING_LOGGING_FILE = sIsLogFile;
            }
            else
                bIsLogging = false;
        }
        #endregion

        #region public void WriteLog(string sInfo = "")   TODO
        //Put this in thread and separate the listbox code and log stuff
        // Should be ListBox UI -> logging -> file.
        public void WriteLog(string sInfo = "")
        {
            StreamWriter pFile = new StreamWriter ( SmittyPRG.STRING_LOGGING_FILE, append: true );
            for (int i = 0; i < lbFilesProcessed.Items.Count; i++)
            {
                pItemIterator = lbFilesProcessed.Items[i].ToString ();
                if (sInfo != "")
                    pFile.WriteLine ( DateTime.Now.ToString () + ": " + pItemIterator + " -MSG: " + sInfo );
                else
                    pFile.WriteLine ( DateTime.Now.ToString () + ": " + pItemIterator );
            }
            pFile.Dispose ();
        }
        #endregion

        #region public string GetChosenDriveFromDriveInfo()
        public string GetChosenDriveFromDriveInfo()
        {
            //If there's noting in the list, just bail out..
            if (MainDriveListView.SelectedItems.Count == 0)
                return (null);

            //else... get the selected item.
            ListViewItem pLviItem = MainDriveListView.SelectedItems[0];
            string sCorrectDriveStr;
            string[] sRawDriveInfo;

            //MessageBox.Show( pLviItem.Text );
            //MessageBox.Show(pLviItem.SubItems[0].Text);
            sCorrectDriveStr = pLviItem.SubItems[0].Text;
            sRawDriveInfo = sCorrectDriveStr.Split ( ' ' );
            //MessageBox.Show(sCorrectDriveStr);
            //MessageBox.Show(pLviItem.SubItems[1].Text);
            //MessageBox.Show(pLviItem.SubItems[2].Text);
            //MessageBox.Show(pLviItem.SubItems[3].Text);
            return (sRawDriveInfo[0]);
        }
        #endregion

        #region public bool IsFileOlderThanCustomDays2(string sFileName, int iDays, out double[] iDDays)
        //determine the age of file/folder return true is older than amount of days, false if not older.
        public bool IsFileOlderThanCustomDays2(string sFileName, int iDays, out double[] iDDays)
        {
            FileInfo fileInfo = new FileInfo(sFileName);

            DateTime structCreationTime = fileInfo.CreationTime;
            DateTime structLastWriteTime = fileInfo.LastWriteTime;
            DateTime structLastAccessTime = fileInfo.LastAccessTime;

            var datetimeNow = DateTime.Now;

            TimeSpan timespanCustomTimeBomb = new TimeSpan(iDays, 0, 0, 0);

            TimeSpan datetimeCreationTimeDifference = datetimeNow - structCreationTime;
            TimeSpan datetimeLastWriteTimeDifference = datetimeNow - structLastWriteTime;
            TimeSpan datetimeLastAccessTimeDifference = datetimeNow - structLastAccessTime;

            iDDays = new double[3];

            iDDays[0] = datetimeCreationTimeDifference.TotalDays;
            iDDays[1] = datetimeLastWriteTimeDifference.TotalDays;
            iDDays[2] = datetimeLastAccessTimeDifference.TotalDays;

            //NOTE: Took out check datetimeLastWriteTimeDifference for "modified". This could be an option
            // UPDATE: complete.
            if (cbLastWriteCheck.Checked)
            {
                //If lastwrite checked and last accessed
                if (cbLastAccessedCheck.Checked)
                {
                    if (
                            (datetimeCreationTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                            ||
                            (datetimeLastWriteTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                            ||
                            (datetimeLastAccessTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                        )
                        return (true);
                    else
                        return (false);
                }
                else
                //If lastwrite checked and NOT last accessed
                {

                    if (
                        (datetimeCreationTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                        ||
                        (datetimeLastWriteTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                       )
                        return (true);
                    else
                        return (false);
                }

            }
            else
            {
                //If lastwrite NOT checked and last accessed
                if (cbLastAccessedCheck.Checked)
                {

                    if (
                        (datetimeCreationTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                        ||
                        (datetimeLastAccessTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                       )
                        return (true);
                    else
                        return (false);
                }
                else
                //If lastwrite NOT checked and NOT last accessed
                {

                    if (
                         (datetimeCreationTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                        )
                        return (true);
                    else
                        return (false);
                }
            }
        }
        #endregion

        #region private void exportThisDrivesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        private void exportThisDrivesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Implemented later. ALso will be used for command line automation");
            if (MainDriveListView.SelectedIndices.Count <= 0)
                return;

            foreach (ListViewItem item in MainDriveListView.SelectedItems)
            {
                //ReadRow ( item.Index, s1, s2, s3, s4 );  
                ListViewItem sListView = MainDriveListView.SelectedItems[0];
                string sDriveId = null;
                int iColumnIndex = 0;

                //Columns: Drive, Type, Total, Used / Free
                foreach (ColumnHeader chHeader in MainDriveListView.Columns)
                {
                    if (chHeader.Text == "Drive")
                    {
                        string sLvColText = "";
                        string[] sDriveSrc;

                        sDriveId = sListView.SubItems[iColumnIndex].Text;
                        //We have to split the sDriveId because it would look like this: C:\ ([Hard Drive Name]). We'll split at the space between C: and paranthesis.
                        //Also, above we could've used the sListView text, but this code would be useful in the future since we have columns.
                        sLvColText = sListView.SubItems[iColumnIndex].Text;
                        sDriveSrc = sLvColText.Split ( ' ' );
                        ut.GetDriveInfoStatus ( sDriveSrc[0] );
                        break;
                    }
                    iColumnIndex++;
                }
            }
        }
        #endregion
  
        #region public void UpdateConfigAfterAddRem ()
        //When adding by pressing (+) or key enter, then we automatically update config file.
        // April 4 2019 - works! -cW
        public void UpdateConfigAfterAddRem ()
        {
            sConfigBuffer = "";
            for (int iIndex = 0; iIndex < ConfigData.Count; iIndex++)
            {
                if (ConfigData[iIndex].sDirName.Length != 0)
                {
                    // MessageBox.Show ( ConfigData[iIndex].sDirName );
                    sConfigBuffer += ConfigData[iIndex].sDirName;
                    // MessageBox.Show ( ConfigData[iIndex].FormatDirPatternListConfig() );
                    sConfigBuffer += ConfigData[iIndex].FormatDirPatternListConfig ();

                    int iIndexofItem = ConfigData.IndexOf ( ConfigData[iIndex] );
                }
            }

            pConfig.IniWrite("directories", null, null);
            pConfig.IniClearSecton("directories");
            pConfig.IniWrite("directories", "CustomDirs", sConfigBuffer);
        }
        #endregion

        #region public void PerformAutoClean()
        public void PerformAutoClean()
        {
           //First - remove the logfile. We'll re-create it.
            File.Delete(SmittyPRG.STRING_LOGGING_FILE);

            string sWinDir;
            //taskkill /f /im explorer.exe first
            //thumbnail cache: %LocalAppData%\Microsoft\Windows\Explorer\thumbcache_ *.db
            //then renable explorer 
            //start explorer.exe
 
            //KNOWNFOLDERIDs
            //downloads: %USERPROFILE%\Downloads
            //search history: %LOCALAPPDATA%\Microsoft\Windows\ConnectedSearch\History

            //sWindir turns to drive:\windows\temp
            sWinDir = Directory.GetParent(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System)).FullName;
            sWinDir += "\\temp";

            //cleanmgr.exe /AUTOCLEAN
            //MessageBox.Show("Will now clean " + sWinDir);
            //Process.Start("cleanmgr.exe", " /AUTOCLEAN " + "/D " + GetChosenDriveFromDriveInfo());
            if (Directory.Exists(sWinDir))
            {
                if (cbDestructive.Checked)
                    DirFileSearchOption(sWinDir, "*.*", true, true);
                else
                    DirFileSearchOption(sWinDir, "*.*", true, false);
            }
            else
                MessageBox.Show(sWinDir + " doesn't exist. Cannot deterime windows temp source");

            //Do C:\Users\{user}\AppData\Local\Temp
            /*
            sWinDir = "";
            sWinDir = Directory.GetParent(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)).FullName;
            sWinDir += "\\Local\\Temp";
            if (Directory.Exists(sWinDir))
            {
                if (cbDestructive.Checked)
                    DirFileSearchOption(sWinDir, "*.*", true, true);
                else
                    DirFileSearchOption(sWinDir, "*.*", true, false);
            }
            else
                MessageBox.Show(sWinDir + " doesn't exist. Cannot deterime C:\\Users\\{user}\\AppData\\Local\\Temp source");
            */
            ClearTempFiles();

            //Now, reset and do the configured search/clean mechanism.
            PerformSearchOp();

            //below line is .net 4 and below. next line is .net 4 and above.
            if (bIsLogging) WriteLog ();
        }
        #endregion


        // EVENT HANDLERS // // // // // // // // // // // // // // // // // // // 
        #region private void frmMain_Load(object sender, EventArgs e)
        //Main form application load.
        //Load balloon tips
        //Get drive status and info. (NOTE: sometimes a /little/ slow on network drive detection. Should be threaded.)
        private void frmMain_Load(object sender, EventArgs e)
        {
            //TNANotify1.BalloonTipTitle = Application.ProductName;

            //Load embedded resource (pig.ico) and pass it
            //System.Reflection.Assembly assembly = this.GetType().Assembly;
            // assembly.GetManifestResourceStream(assembly.GetName().Name + "pig.ico");
            TNANotify1.BalloonTipText = Application.ProductName + " is starting...\nDouble-click on the pink pig in the taskbar tray to begin, right click to exit.";
            TNANotify1.ShowBalloonTip(3000);

            //TODO: Learned that if network drive that have been disconnnected and reconnected 
            // may have a "stale" connection. This is when explorer has trouble pinging it.
            // This should be put on a thread or catch exceptions.
            // bByCmdLine - means we ran it via command line. If we didn't, then get the drive info.
            //
            // NOTE NOTE NOTE NOTE NOTE:  IF YOU ARE DEBUGGING, then this thread might cause exception. Just comment out TimerTickerSTATDrives may need disabling too.
            //
            if (!SmittyPRG.bByCmdLine)
            {
                MainDriveListView.Items.Clear();
                //System.Threading.Thread threadDriveSTAT = new System.Threading.Thread(() =>
                //{
                //    ut.GetAllFreeSpaceDisk(MainDriveListView);
                //}
                //);
                //threadDriveSTAT.Start();
            }
                

            if (!SmittyPRG.bStartConfig)
            {
                //Read on custom directory configs
                ReadConfigs();

                if (SmittyPRG.bAutoClean == true)
                {
                    btnSearch_Click(this, EventArgs.Empty);

                    if (SmittyPRG.bByCmdLine)
                        exitToolStripMenuItem_Click(this, EventArgs.Empty);
                }
                else
                {
                    //Set the timer and go.
                    TimerTicker_01.Enabled = true;

                    //config the second timer. once timerticker_01 sets, then disable and timerticker_02 starts. 
                    // That resets timerticker_01 after hour. If we didn't do it, searching/ops will loop until
                    // timer interval has pased.
                    TimerTicker_02.Interval = GLOBAL_INT_HOUR; //1 hour to reset TimerTicker_01
                    TimerTicker_02.Enabled = false;
                }
            }
            else
            {
                //Disable EVERYTHING just for configuration.
                cbDestructive.Enabled = false;
                cbDestructive.Checked = false;
                lbIWIllCleanUpText.Visible = false;
                lbHoursLeft.Visible = false;
                tabControl1.SelectedIndex = 1;
                bExitApp = true;
                this.ShowInTaskbar = false;
                TNANotify1.Dispose();
            }
        }
        #endregion

        #region private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //Pressing enter on the txtUserDirEntry textbox control
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                lstUserDirectoryOptions.Items.Add(txtUserDirEntry.Text);
                txtUserDirEntry.Text = "";
            }
        }
        #endregion  

        #region private void btAddDirs_Click_1(object sender, EventArgs e)
        //Using the BROWSE button to browse for a directory
        private void btAddDirs_Click_1(object sender, EventArgs e)
        {
            DialogResult dwResult = dlg_BrowseFolder.ShowDialog();
            if (dwResult == DialogResult.OK)
            {
                try
                {
                    folderName = dlg_BrowseFolder.SelectedPath;
                    if (Directory.Exists(folderName))
                    {
                        //  lstUserDirectoryOptions.Items.Add(dlg_BrowseFolder.SelectedPath);
                        //Write config right after we grabbed a directory and confirmed.
                        //  txtUserDirEntry.Text = "";
                        //  UpdateConfigAfterAddRem();
                        txtUserDirEntry.Text = folderName;
                    }
                    else
                        MessageBox.Show("The directory" + folderName + "doesn't exist. Not adding.");
                }
                catch (System.Exception Eexp)
                {
                    MessageBox.Show("An error occurred:"
                                    + System.Environment.NewLine + Eexp.ToString() + System.Environment.NewLine);
                }
                Invalidate();
            }
        }
        #endregion

        #region private void txtUserDirEntry_KeyDown(object sender, KeyEventArgs e) 
        //Pressing enter on the txtUserDirEntry textbox control (not using the add or + button) will add a directory option to our config
        private void txtUserDirEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtUserDirEntry.Text))
                {
                    lstUserDirectoryOptions.Items.Add(txtUserDirEntry.Text);
                    txtUserDirEntry.Text = "";
                    UpdateConfigAfterAddRem();
                }
                else
                {
                    MessageBox.Show("The directory" + folderName + "doesn't exist. Not adding.");
                    txtUserDirEntry.Text = "";
                }
            }
        }
        #endregion

        #region private void lstFilesFound_KeyDown(object sender, KeyEventArgs e)
        // on the lstUserDirectoryOptions listview control keydown captures DELETE to remove
        private void lstFilesFound_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Delete):
                    {
                        if (lstUserDirectoryOptions.SelectedItems.Count != 0)
                        {
                            while (lstUserDirectoryOptions.SelectedIndex != -1)
                            {
                                lstUserDirectoryOptions.Items.RemoveAt(lstUserDirectoryOptions.SelectedIndex);
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region private void lstFilesFound_MouseDoubleClick(object sender, MouseEventArgs e)
        private void lstFilesFound_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

            MessageBox.Show(sItem + " - item selected");
        }
        #endregion

        #region private void AdjustTrackBarPositionRange()
        //TODO This logic is quick and meh... Redo when time permits.
        private void AdjustTrackBarPositionRange()
        {

            //If younger than a day - basically, NEW
            if (trackbarDaysToOperate.Value <= 1)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_001;
                lblDaysToRemove.Text = trackbarDaysToOperate.Value.ToString();
            }

            //If older or equal to a day
            if (trackbarDaysToOperate.Value > 1)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_002;
                lblDaysToRemove.Text = trackbarDaysToOperate.Value.ToString();
            }

            //1 month...
            if (trackbarDaysToOperate.Value >= 30)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_004;
                lblDaysToRemove.Text = "1";
            }

            //2 months...
            if (trackbarDaysToOperate.Value >= 60)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_003;
                lblDaysToRemove.Text = "2";
            }

            //3 months...
            if (trackbarDaysToOperate.Value >= 91)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_003;
                lblDaysToRemove.Text = "3";
            }

            //4 months...
            if (trackbarDaysToOperate.Value >= 122)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_003;
                lblDaysToRemove.Text = "4";
            }

            //5 months...
            if (trackbarDaysToOperate.Value >= 152)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_003;
                lblDaysToRemove.Text = "5";
            }

            //If older than 6 months
            //This works under search. Anything over doesn't yet.
            if (trackbarDaysToOperate.Value >= 182)
            {
                lbDaysOld.Text = STRING_INFO_DAYOLDERLABEL_003;
                lblDaysToRemove.Text = "6";
            }

            //If older than 365 days 1 year
            if (trackbarDaysToOperate.Value >= 365)
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_001;
                lblDaysToRemove.Text = "1";
            }


            //If older than 1.5 years...
            if (trackbarDaysToOperate.Value >= 548)
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "1 1/2";
            }

            // dominion village
            // 2856 Forehand Dr
            // Chesapeake, VA 23323 room 5 

            //If older than 2 years...
            if (trackbarDaysToOperate.Value >= 730)
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "2";
            }

            //If older than 2.5 years...
            if (trackbarDaysToOperate.Value >= 913)
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "2 1/2";
            }

            //If older than 3 years...
            if (trackbarDaysToOperate.Value >= (365 * 3))
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "3";
            }

            //If older than 3.5 years...
            if (trackbarDaysToOperate.Value >= (1277))
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "3 1/2";
            }

            //If older than 4 years...
            if (trackbarDaysToOperate.Value >= (365 * 4))
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "4";
            }


            //If older than 4.5 years...
            if (trackbarDaysToOperate.Value >= (1642))
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "4 1/2";
            }

            //If older than 5 years...
            if (trackbarDaysToOperate.Value >= (365 * 5))
            {
                lbDaysOld.Text = STRING_INFO_YEAROLDERLABEL_002;
                lblDaysToRemove.Text = "5";
            }

            System.Threading.Thread.Sleep(50);
            lblDaysToRemove.Update();
            lblDaysToRemove.Refresh();
            trackbarDaysToOperate.Update();
            Application.DoEvents();


        }
        #endregion

        #region private void trackbarDaysToOperate_Scroll(object sender, EventArgs e)
        private void trackbarDaysToOperate_Scroll(object sender, EventArgs e)
        {
            //lblDaysToRemove.Text = trackbarDaysToOperate.Value.ToString ();
            //lblDaysToRemove.Update();

            AdjustTrackBarPositionRange();

            pConfig.IniWrite("application", "DaysToRemove", trackbarDaysToOperate.Value.ToString());
        }
        #endregion

        #region private void btnClearFilesFound_Click(object sender, EventArgs e)
        //Claer out listbox files processed.
        private void btnClearFilesFound_Click(object sender, EventArgs e)
        {
            this.lbFilesProcessed.Items.Clear();
        }
        #endregion

        #region private void cbActionAfterSearch_CheckedChanged(object sender, EventArgs e)
        //LastModified option
        private void cbActionAfterSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLastWriteCheck.Checked)
                pConfig.IniWrite("application", "LastModified", "true");
            else
                pConfig.IniWrite("application", "LastModified", "false");
        }
        #endregion

        #region private void cbDestructive_CheckedChanged(object sender, EventArgs e)
        //Destructive option tickbox
        private void cbDestructive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDestructive.Checked == true)
                pConfig.IniWrite("application", "Destructive", "true");
            else
                pConfig.IniWrite("application", "Destructive", "false");
        }
        #endregion

        #region private void goHereToolStripMenuItem_Click(object sender, EventArgs e)
        private void goHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO Cheap way of getting there. We would need to add exceptrions here. 

            Process.Start("explorer.exe", GetChosenDriveFromDriveInfo());

        }
        #endregion

        #region private void aBoutToolStripMenuItem_Click(object sender, EventArgs e)
        //private About wAboutDialog;
        private void aBoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wAboutDialog == null)
            {
                wAboutDialog = new About();
                wAboutDialog.FormClosed += new FormClosedEventHandler(WAboutDialog_FormClosed);
                wAboutDialog.Owner = this;
                wAboutDialog.ShowDialog();
            }
            else
                wAboutDialog.Activate();

            // MessageBox.Show("About not finished, but designed by c. winters. SMITTy Version: " + Application.ProductVersion);
        }
        #endregion

        #region private void WAboutDialog_FormClosed(object sender, FormClosedEventArgs e)
        private void WAboutDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            wAboutDialog = null;
        }
        #endregion

        #region private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bExitApp = true;
            this.ShowInTaskbar = false;
            TNANotify1.Dispose();
            this.Close();
        }
        #endregion

        #region private void frmMain_Resize(object sender, EventArgs e)
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //TNANotify1.BalloonTipTitle = Application.ProductName;
                TNANotify1.BalloonTipText = "SMITTy working behind the scenes...";
                TNANotify1.ShowBalloonTip(3000);

                this.Hide();
                this.ShowInTaskbar = false;
                this.TNANotify1.Icon = new Icon(GetType(), "sleeping-pig.ico");
            }
        }
        #endregion

        #region private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //                TNANotify1.BalloonTipTitle = Application.ProductName;
            //                TNANotify1.BalloonTipText = "Waking up SMITTy... 4BC";
            //                TNANotify1.ShowBalloonTip(3000);
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.TNANotify1.Icon = new Icon(GetType(), "sleeping-pig.ico");
        }
        #endregion

        #region private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bExitApp)
            {
                //TNANotify1.BalloonTipTitle = Application.ProductName;
                TNANotify1.BalloonTipText = "SMITTy sleeping...";
                TNANotify1.ShowBalloonTip(3000);

                this.Hide();
                this.ShowInTaskbar = false;
                //TODO if we move the icon into a folder within project it will not pick up. Why? It's embedded resource (properties on ICO file)
                this.TNANotify1.Icon = new Icon(GetType(), "sleeping-pig.ico");
                //this.TNANotify1.Icon = new Icon(typeof(frmMain), "sleeping-pig.ico");

                //THIS event took time figuring out to disable the Application from closing. 
                //However, you MUST use the FormClosingEventArgs -> Cancel = true to cancel SC_CLOSE message.
                //Tested with ALT-F4 too. 
                e.Cancel = true;
            }
        }
        #endregion

        #region private void cbClearUserTemp_CheckedChanged(object sender, EventArgs e)
        private void cbClearUserTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClearUserTemp.Checked == true)
                pConfig.IniWrite("application", "ClearUserTemp", "true");
            else
                pConfig.IniWrite("application", "ClearUserTemp", "false");
        }
        #endregion

        #region private void autoCleanToolStripMenuItem_Click(object sender, EventArgs e)
        //context menu for "AutoClean" during drive info. (contextMenuDrives component)
        private void autoCleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bIsAutoClean = true;
            PerformAutoClean();
            bIsAutoClean = false;
        }
        #endregion

        #region private void cbLastAccessedCheck_CheckedChanged(object sender, EventArgs e)
        private void cbLastAccessedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLastAccessedCheck.Checked)
                pConfig.IniWrite("application", "LastAccessed", "true");
            else
                pConfig.IniWrite("application", "LastAccessed", "false");
        }
        #endregion

        #region private void MainDriveListView_MouseClick(object sender, MouseEventArgs e)
        private void MainDriveListView_MouseClick(object sender, MouseEventArgs e)
        {
            string sDriveSelected = MainDriveListView.SelectedItems[0].Text;
            //MessageBox.Show(sDriveSelected);
            if (sDriveSelected.Contains("C:"))
            {
                //Make "AutoClean visible
                autoCleanToolStripMenuItem.Visible = true;
            }
        }
        #endregion

        #region private void contextMenuDrives_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        //Hide the "AutoClean" text until we select C: again...
        private void contextMenuDrives_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            autoCleanToolStripMenuItem.Visible = false;
        }
        #endregion

        #region private void contextMenuDrives_Opening(object sender, CancelEventArgs e)
        //Cancel the context menu if you haven't selected /ANYTHING/ on the drive info listview
        private void contextMenuDrives_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = this.MainDriveListView.SelectedItems.Count <= 0;
        }
        #endregion

        #region private void btnCancelSearch_Click(object sender, EventArgs e)
        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            bIsCancelling = true;
            Application.DoEvents();
            EnableDisableDirOptionInputUI(true);
        }
        #endregion

        #region private void TimerTicker_01_Tick(object sender, EventArgs e)
        //This is where we sniff (24 hours later) to see if we need to clean.
        //If we do, remove files based on days old.
        private void TimerTicker_01_Tick(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddDays(1);

            double diff = dt2.Subtract(dt1).TotalMinutes;

            //            label14.Text = diff.ToString();
            //            label14.Update();

            //DateTime today = DateTime.Today;
            DateTime today = DateTime.Now;

            DateTime mid = today.AddDays(1).AddSeconds(-1);

            var dtCurrentHour = DateTime.Now.Hour;
            //Get the time/date for exactlyt 24 hours ago.
            TimeSpan timeBetween = (DateTime.Today.AddDays(1) - DateTime.Now);

            DateTime tNow = DateTime.Now;
            DateTime tMidnight = DateTime.Now.Date.AddDays(1);
            //TimeSpan tTimeSpan = tMidnight.Subtract(tNow);
            TimeSpan tTimeSpan = (DateTime.Today.AddDays(1) - DateTime.Now);

            //lbHoursLeft.Text = tTimeSpan.Days + "D " + tTimeSpan.Hours + "H";
            //lbTimeTickl.Text = tTimeSpan.Minutes + "M " + tTimeSpan.Seconds + "s";
            lbHoursLeft.Text = tTimeSpan.Hours + "h " + tTimeSpan.Minutes + "m " + tTimeSpan.Seconds + "s";

            //24 hour 
            if (tTimeSpan.Hours == 0)
            {
                //Boom!
                TimerTicker_01.Enabled = false;

                TimerTicker_02.Enabled = true;
                TimerTicker_02.Interval = GLOBAL_INT_HOUR; //1 hour to reset TimerTicker_01

                lbHoursLeft.Text = "";
                if (cbDestructive.Checked)
                    lbIWIllCleanUpText.Text = STRING_INFO_SEARCH_COMPLETE_DESTRUCTIVE;
                else
                    lbIWIllCleanUpText.Text = STRING_INFO_SEARCH_COMPLETE_NONDESTRUCTIVE;

                //Process the cleaning here...
                PerformSearchOp();

                ClearTempFiles();
            }
        }
        #endregion

        #region private void TimerTicker_02_Tick(object sender, EventArgs e)
        // Ticker to wait an hour after scheduled scan. If we didn't wait then we may go into a constant loop.
        private void TimerTicker_02_Tick(object sender, EventArgs e)
        {
            TimerTicker_01.Enabled = true;

            TimerTicker_02.Enabled = false;
            lbHoursLeft.Text = "????";
            lbIWIllCleanUpText.Text = "I will check in ";
        }
        #endregion

        #region private void EnableDisableDirOptionInputUI(bool bFlag)
        private void EnableDisableDirOptionInputUI(bool bFlag)
        {
            groupBox1.Enabled = bFlag;
            groupBox2.Enabled = bFlag;
            //txtUserDirEntry.Enabled = bFlag;
            //txtFilePattern.Enabled = bFlag;
            //btAddDirs.Enabled = bFlag;
            //btnAddItemFromDirEntry.Enabled = bFlag;
            //btnRemoveItemFromDirEntry.Enabled = bFlag;
            btnSearch.Enabled = bFlag;
        }
        #endregion

        #region private void btnSearch_Click(object sender, EventArgs e)
        //This is a manual approach to cleaning files. User clicks search and the files can be searched for
        //and removed with the "Destructive" option set.
        private void btnSearch_Click(object sender, EventArgs e)
        {

            // System.NullReferenceException: Object reference not set to an instance of an object.
            // at System.Windows.Forms.ListBox.ItemArray.GetItem(Int32 virtualIndex, Int32 stateMask)
            // at System.Windows.Forms.ListBox.ObjectCollection.ClearInternal()
            // at System.Windows.Forms.ListBox.ObjectCollection.Clear()
            // at Smitty.frmMain.btnSearch_Click(Object sender, EventArgs e)
            // at System.Windows.Forms.Control.OnClick(EventArgs e)
            // at System.Windows.Forms.Button.OnClick(EventArgs e)
            // at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
            // at System.Windows.Forms.Control.WmMouseUp(Message & m, MouseButtons button, Int32 clicks)
            // at System.Windows.Forms.Control.WndProc(Message & m)
            // at System.Windows.Forms.ButtonBase.WndProc(Message & m)
            // at System.Windows.Forms.Button.WndProc(Message & m)
            // at System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message & m)
            // at System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message & m)
            //at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)

            //First - remove the logfile. We'll re-create it.
            if (File.Exists (SmittyPRG.STRING_LOGGING_FILE) )
                File.Delete(SmittyPRG.STRING_LOGGING_FILE);

            //Disable user input 
            EnableDisableDirOptionInputUI(false);

            //Small delay
            System.Threading.Thread.Sleep(200);

            //Clear the items found list box
            //            if (lbFilesProcessed.SelectedItem != null)
            lbFilesProcessed.Items.Clear();

            //Small delay
            System.Threading.Thread.Sleep(200);

            // System.Threading.Thread threadDirSearch inside PerforSearchOp()
            PerformSearchOp();

            // System.Threading.Thread threadDirSearch inside ClearTempFiles()
            ClearTempFiles();

            //Finally, write everything to our logfile (files_processed.log)
            //April 22 - let's move this to a thread when listbox has activity.
            //
            //StreamWriter pFile = new StreamWriter(File.Create(SmittyPRG.STRING_LOGGING_FILE));
            if (bIsLogging) WriteLog();

            //Disable user input 
            EnableDisableDirOptionInputUI(true);
        }
        # endregion btnSearch_Click(object sender, EventArgs e)

        #region private void TimerTicker_03_STATDrives_Tick(object sender, EventArgs e)
        // Timer ticker to STAT the drives on the main list view. Refresh in case of dropped drives or non ready ones.
        private void TimerTicker_03_STATDrives_Tick(object sender, EventArgs e)
        {
            return;

            // TODO: A better validation scan to fresh the listview. Currently, it clears, then updates. This causes a few millisonceds delay.
            MainDriveListView.Items.Clear();

            System.Threading.Thread threadDirSearch = new System.Threading.Thread(() =>
                {
                    try
                    {
                        MainDriveListView.BeginUpdate();

                        //ut.GetAllFreeSpaceDisk(MainDriveListView);
                        System.Threading.Thread threadDriveSTATTick = new System.Threading.Thread(() =>
                        {
                            ut.GetAllFreeSpaceDisk(MainDriveListView);
                        }
                        );
                        threadDriveSTATTick.Start();
                    }
                    finally
                    {
                        MainDriveListView.EndUpdate();
                    }

                }
                );
                threadDirSearch.Start();



        }

        private void cbHushOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLastAccessedCheck.Checked)
                pConfig.IniWrite("application", "HushFileOutput", "true");
            else
                pConfig.IniWrite("application", "HushFileOutput", "false");
        }
        #endregion

        #region private void DisableDirOptionToolStripMenuItem_Click(object sender, EventArgs e)
        //Right clicking on UI brings up option to DISABLE this directory in current search
        // TODO: Later save the ability to enable/disable dir search option in config. -DONE
        private void DisableDirOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstUserDirectoryOptions.SelectedItems.Count == 0)
                return;

            string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

            //Split the string from the custom string that displays patterns next to it. Trim after.
            string[] sItemRaw = sItem.Split(new Char[] { '(' });
            sItemRaw[0] = sItemRaw[0].TrimEnd(' ');

            for (int i = 0; i < ConfigData.Count; i++)
            {
                if (ConfigData[i].sDirName == sItemRaw[0])
                {
                    //MessageBox.Show ( ConfigData[i].sDirName );
                    //MessageBox.Show ( ConfigData[i].sPattern.ToString() );
                    //MessageBox.Show ( ConfigData[i].iID.ToString () );
                    //ConfigData.IndexOf ( ConfigData[i] );
                    int iIndexofItemToDisable = ConfigData.IndexOf(ConfigData[i]);
                    //ConfigData.RemoveAt ( iIndexofItemToBeRemoved );
                    ConfigData[i].DisableDirOption(iIndexofItemToDisable);

                    int iIndexToEdit = lstUserDirectoryOptions.SelectedIndex;

                    ConfigData[i].GetDirSpec(ConfigData[i].sDirName);

                    //List<string> test = ConfigIterList2[iIndex].GetPatternSpec ( sConfigDir[1] ).ToList();
                    //ConfigData[i].GetPatternSpec ( ConfigData[i].sPattern );

                    lstUserDirectoryOptions.Items[i] = ConfigData[i].FormatDirPatternListUI();

                    //TODO - ADD the DISABLED MARK '//' into config.
                    // Example: CustomDirs=C:\KILL_AT_WILL|//|*.txt|*.tmp|*.chris;
                    UpdateConfigAfterAddRem();
                    // MessageBox.Show ( ConfigData[i].sDirName + " - disabled in search" );
                }
            }
        }
        #endregion

        #region private void EnableDirOptionToolStripMenuItem_Click(object sender, EventArgs e)
        //Right clicking on UI brings up option to ENABLE this directory in current search
        private void EnableDirOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

            //Split the string from the custom string that displays patterns next to it. Trim after.
            string[] sItemRaw = sItem.Split(new Char[] { '(' });
            sItemRaw[0] = sItemRaw[0].TrimEnd(' ');

            for (int i = 0; i < ConfigData.Count; i++)
            {
                if (ConfigData[i].sDirName == sItemRaw[0])
                {
                    //MessageBox.Show ( ConfigData[i].sDirName );
                    //MessageBox.Show ( ConfigData[i].sPattern.ToString() );
                    //MessageBox.Show ( ConfigData[i].iID.ToString () );
                    //ConfigData.IndexOf ( ConfigData[i] );
                    int iIndexofItemToDisable = ConfigData.IndexOf(ConfigData[i]);
                    //ConfigData.RemoveAt ( iIndexofItemToBeRemoved );
                    ConfigData[i].EnableDirOption();

                    //MessageBox.Show ( ConfigData[i].sDirName + " - enabled in search" );

                    //TODO: Done. Updating the UI works.
                    int iIndexToEdit = lstUserDirectoryOptions.SelectedIndex;

                    lstUserDirectoryOptions.Items[iIndexToEdit] = ConfigData[i].FormatDirPatternListUI();

                    //TODO - Remove the DISABLED MARK '//' from config.
                    // Example: CustomDirs=C:\KILL_AT_WILL|//|*.txt|*.tmp|*.chris;
                    UpdateConfigAfterAddRem();
                }
            }
        }
        #endregion

        #region private void contextMenuEnableDisableDirSearch_Click(object sender, EventArgs e)
        // When the Enable/Disable dir options is opened, figure out if it should update UI to keep from re-disabling/enabling directory spec
        //TODO when NOT selecting an item, menu needs to not show
        private void contextMenuEnableDisableDirSearch_Click(object sender, EventArgs e)
        {
            if (lstUserDirectoryOptions.SelectedItems.Count == 0)
                return;

            //TODO this small amount of code is used in other places. We should put it into a function.
            string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

            //Split the string from the custom string that displays patterns next to it. Trim after.
            string[] sItemRaw = sItem.Split(new Char[] { '(' });
            sItemRaw[0] = sItemRaw[0].TrimEnd(' ');

            for (int i = 0; i < ConfigData.Count; i++)
            {
                if (ConfigData[i].sDirName == sItemRaw[0])
                {
                    if (ConfigData[i].bEnabled == false)
                    {
                        DisableDirOptionToolStripMenuItem.Enabled = false;
                        EnableDirOptionToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        DisableDirOptionToolStripMenuItem.Enabled = true;
                        EnableDirOptionToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region private void contextMenuEnableDisableDirSearch_Opening(object sender, CancelEventArgs e)
        private void contextMenuEnableDisableDirSearch_Opening(object sender, CancelEventArgs e)
        {
            if (lstUserDirectoryOptions.SelectedItems.Count == 0)
                return;

            //TODO this small amount of code is used in other places. We should put it into a function.
            string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

            //Split the string from the custom string that displays patterns next to it. Trim after.
            string[] sItemRaw = sItem.Split(new Char[] { '(' });
            sItemRaw[0] = sItemRaw[0].TrimEnd(' ');

            for (int i = 0; i < ConfigData.Count; i++)
            {
                if (ConfigData[i].sDirName == sItemRaw[0])
                {
                    if (ConfigData[i].bEnabled == false)
                    {
                        DisableDirOptionToolStripMenuItem.Enabled = false;
                        EnableDirOptionToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        DisableDirOptionToolStripMenuItem.Enabled = true;
                        EnableDirOptionToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region  private void TxtFilePattern_KeyPress(object sender, KeyPressEventArgs e)
        //Press enter instead of using BtnAddItemFromDirEntry_Click() below? 
        // Simulate button click event and let that do the work.
        private void TxtFilePattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnAddItemFromDirEntry.PerformClick();
        }
        #endregion

        #region private void BtnAddItemFromDirEntry_Click(object sender, EventArgs e)
        // Plus(+) button pressed
        private void BtnAddItemFromDirEntry_Click(object sender, EventArgs e)
        {
            //TODO: When adding any directory, we must check and see if it is VALID!
            // C:\temp\YOU_CAN_REM
            // C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys
            if (txtUserDirEntry.Text != "")
            {
                int iLen = ConfigData.Count();

                ConfigInfo configinfo = new ConfigInfo();

                configinfo.iID = iLen + 1;
                configinfo.sDirName = "";
                configinfo.GetDirSpec(txtUserDirEntry.Text);

                if (txtFilePattern.Text == "")
                {
                    txtFilePattern.Text = "*.*";
                    configinfo.GetCustPatternSpec(txtFilePattern.Text);
                }
                else
                    configinfo.GetCustPatternSpec(txtFilePattern.Text);

                ConfigData.Add(configinfo);

                lstUserDirectoryOptions.Items.Add(configinfo.FormatDirPatternListUI());

                //ConfigData.Clear ();
                //lstUserDirectoryOptions.Items.Add ( txtUserDirEntry.Text );
                UpdateConfigAfterAddRem();
            }
            txtUserDirEntry.Text = "";
            txtFilePattern.Text = "";
        }
        #endregion

        #region private void BtnRemoveItemFromDirEntry_Click(object sender, EventArgs e)
        // Minus/Remove button pressed
        // Remove the items from the directory options listbox and from our internal container
        // April 04 2019 - works! cW
        private void BtnRemoveItemFromDirEntry_Click(object sender, EventArgs e)
        {
            if (lstUserDirectoryOptions.SelectedItems.Count != 0)
            {
                while (lstUserDirectoryOptions.SelectedIndex != -1)
                {
                    //Loop through our listbox and break apart the strings. We
                    // Need to find the dirname and compare that to our list that contains the dirname.
                    // Once we find, then remove that item from the list, updating the UI afterwards.

                    //GEt the item that we clicked on. Get the index and string.
                    iSelectedIndex = lstUserDirectoryOptions.SelectedIndex;
                    string sItem = lstUserDirectoryOptions.GetItemText(lstUserDirectoryOptions.SelectedItem);

                    //Split the string from the custom string that displays patterns next to it. Trim after.
                    string[] sItemRaw = sItem.Split(new Char[] { '(' });
                    sItemRaw[0] = sItemRaw[0].TrimEnd(' ');

                    for (int i = 0; i < ConfigData.Count; i++)
                    {
                        if (ConfigData[i].sDirName == sItemRaw[0])
                        {
                            //MessageBox.Show ( ConfigData[i].sDirName );
                            //MessageBox.Show ( ConfigData[i].sPattern.ToString() );
                            //MessageBox.Show ( ConfigData[i].iID.ToString () );
                            //ConfigData.IndexOf ( ConfigData[i] );
                            int iIndexofItemToBeRemoved = ConfigData.IndexOf(ConfigData[i]);
                            ConfigData.RemoveAt(iIndexofItemToBeRemoved);

                            lstUserDirectoryOptions.Items.RemoveAt(lstUserDirectoryOptions.SelectedIndex);

                        }
                    }
                    UpdateConfigAfterAddRem();
                }
            }
        }
        #endregion

        #region private void ToolStripMenuItemRemoveDir_Click(object sender, EventArgs e)
        // Context menu in dir options list - remove option
        private void ToolStripMenuItemRemoveDir_Click(object sender, EventArgs e)
        { //Simulate the (-) or remove button
            BtnRemoveItemFromDirEntry_Click(this, EventArgs.Empty);
        }
        #endregion

        # region private void CheckBoxDontProcessParentFolderFiles_CheckedChanged(object sender, EventArgs e)
        private void CheckBoxDontProcessParentFolderFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDontProcessParentFolderFiles.Checked)
            {
                pConfig.IniWrite("application", "NoParentFiles", "true");
                bNoParentFiles = true;
            }
            else
            {
                pConfig.IniWrite("application", "NoParentFiles", "false");
                bNoParentFiles = false;
            }
        }
        #endregion


    } //ENd of Form main

}





