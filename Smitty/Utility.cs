using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Smitty
{
    public class Utility
    {
        string szDrive, sDriveType, szTotal, szFree, sUsed, sAvailFree, sVolumeLabel, sDriveFormat = "";
        //long lAmountDirsFound, lAmountFilesFound =0L;

        #region public void WriteRow(ListView lvObj, int Row, string S_STR_DRIVE, string S_STR_TYPE, string S_STR_DRIVETOTAL, string S_STR_DRIVEUSEDFREE)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvObj"></param>
        /// <param name="Row"></param>
        /// <param name="S_STR_DRIVE"></param>
        /// <param name="S_STR_TYPE"></param>
        /// <param name="S_STR_DRIVETOTAL"></param>
        /// <param name="S_STR_DRIVEUSEDFREE"></param>
        //---------------------------------------------------------------------------
        //This writes drive info within the TListView
        public void WriteRow(ListView lvObj, int Row, string S_STR_DRIVE, string S_STR_TYPE, string S_STR_DRIVETOTAL, string S_STR_DRIVEUSEDFREE)
        {
            //if(GenerateDebugfile ==1)
            // Debugit(MAINDEBUGFILE.c_str() , " - Doing Action [WRITEROW]");
            // int newitem;
            // Add some items.
            ListViewItem lviMain = new ListViewItem();
            lviMain.Text = S_STR_DRIVE;
            lviMain.SubItems.Add(S_STR_TYPE);
            lviMain.SubItems.Add(S_STR_DRIVETOTAL);
            lviMain.SubItems.Add(S_STR_DRIVEUSEDFREE);
            //MainDriveListView.Items.Add(lviMain);
            lvObj.Items.Add(lviMain);
        }
        #endregion WriteRow

        #region private void ReadRow(ListView lvObj, int Row, string S_STR_DRIVE, string S_STR_TYPE, string S_STR_DRIVETOTAL, string S_STR_DRIVEUSEDFREE)
        //TODO this can potentially be removed. Search for name of function. It'll be REMmed out.
        private void ReadRow(ListView lvObj, int Row, string S_STR_DRIVE, string S_STR_TYPE, string S_STR_DRIVETOTAL, string S_STR_DRIVEUSEDFREE)
        {

            //ListViewItem sListView = MainDriveListView.SelectedItems[0];
            ListViewItem sListView = lvObj.SelectedItems[0];
            string sDriveId = null;
            int iColumnIndex = 0;

            //Columns: Drive, Type, Total, Used / Free
            //foreach (ColumnHeader chHeader in MainDriveListView.Columns)
            foreach (ColumnHeader chHeader in lvObj.Columns)
            {
                if (chHeader.Text == "Drive")
                {
                    sDriveId = sListView.SubItems[iColumnIndex].Text;
                    GetDriveInfoStatus(sListView.SubItems[iColumnIndex].Text);
                    break;
                }
                iColumnIndex++;
            }
        }
        #endregion ReadRow

        #region static String BytesToString(long byteCount)
        //https://stackoverflow.com/questions/25758281/how-to-determine-if-size-is-kb-mb-gb-tb-in-progress-bar
        //help to convert b -> gb -tb. I was doing it the hard way. -cW
        static String BytesToString(long byteCount)
        {
            string[] arSuffix = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + arSuffix[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + arSuffix[place];
        }
        #endregion BytesToString

        #region public void ExportInfoToFile(string sFile, string sInfo = "")
        public void ExportInfoToFile(string sFile, string sInfo = "")
        {
            StreamWriter pFile = new StreamWriter(sFile, append: true);
            pFile.WriteLine(DateTime.Now.ToString() + ":");
            pFile.WriteLine(sInfo);
            pFile.Dispose();
        }
        #endregion EXportInfoToFile

        #region public void GetAllFreeSpaceDisk(ListView lvObj)
        /// <summary>
        /// Get all info on drives and writes it to a listitem object for a listview.
        /// </summary>
        /// <param name="lvObj"></param>
        public void GetAllFreeSpaceDisk(ListView lvObj)
        {
            int iCounter = 1;
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo pDriveInfo in allDrives)
            {
                szDrive = pDriveInfo.Name;

                sDriveType = pDriveInfo.DriveType.ToString();

                if (pDriveInfo.IsReady == true)
                {
                    sVolumeLabel = pDriveInfo.VolumeLabel;
                    sDriveFormat = pDriveInfo.DriveFormat;
                    //sAvailFree = (pDriveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)) + " GB";
                    sAvailFree = BytesToString(pDriveInfo.AvailableFreeSpace);
                    //szFree = (pDriveInfo.TotalFreeSpace / (1024 * 1024 * 1024)) + " GB";
                    szFree = BytesToString(pDriveInfo.TotalFreeSpace);
                    //szTotal = (pDriveInfo.TotalSize / (1024 * 1024 * 1024)) + " GB";
                    szTotal = BytesToString(pDriveInfo.TotalSize);

                    //sUsed = (pDriveInfo.TotalSize / (1024 * 1024 * 1024)) - (pDriveInfo.TotalFreeSpace / (1024 * 1024 * 1024)) + " GB";
                    sUsed = BytesToString((pDriveInfo.TotalSize) - (pDriveInfo.TotalFreeSpace));

                    //                    cboDrive.Items.Add(szDrive);
                    WriteRow(lvObj, iCounter, szDrive + " ( " + sVolumeLabel + " ) ", sDriveType + " / " + sDriveFormat, szTotal, sUsed + " / " + szFree);
                    iCounter++;
                }
            }
        }
        #endregion GetAllFreeSpaceDisk

        #region public void GetDriveInfoStatus(string sDriveSrc = "")
        //This is the two functions above combined. GetDriveStatusLabels(), GetAllFreeSpaceDisk() 
        public void GetDriveInfoStatus(string sDriveSrc = "")
        {
            int iCounter = 0;
            StringBuilder sDriveInfo = new StringBuilder();

            //sDriveSrc must be in the format of C:\\ or G:\\
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo pDriveInfo in allDrives)
            {
                iCounter++;

                if (pDriveInfo.Name == sDriveSrc)
                {
                    if (pDriveInfo.IsReady == true)
                    {
                        szDrive = pDriveInfo.Name;
                        sDriveType = pDriveInfo.DriveType.ToString();
                        sVolumeLabel = pDriveInfo.VolumeLabel;
                        sDriveFormat = pDriveInfo.DriveFormat;
                        sAvailFree = BytesToString(pDriveInfo.AvailableFreeSpace);
                        szFree = BytesToString(pDriveInfo.TotalFreeSpace);
                        szTotal = BytesToString(pDriveInfo.TotalSize);
                        sUsed = BytesToString((pDriveInfo.TotalSize) - (pDriveInfo.TotalFreeSpace));
                        //WriteRow ( iCounter, szDrive + " ( " + sVolumeLabel + " ) ", sDriveType + " / " + sDriveFormat, szTotal, sUsed + " / " + szFree );
                        sDriveInfo.AppendFormat("Drive {0}: [{1}] ({2}) Type: {3} Format: {4} Total Space: {5} Used Space: {6} Free/Available Space: {7} ", iCounter, szDrive, sVolumeLabel, sDriveType, sDriveFormat, szTotal, sUsed, szFree);
                        ExportInfoToFile(SmittyPRG.STRING_EXPORT_DRV_FILE, sDriveInfo.ToString());
                    }
                }
            }
            MessageBox.Show("Drive information exported to " + SmittyPRG.STRING_EXPORT_DRV_FILE);
        }
        #endregion GetDriveInfoStatus
    }
}


