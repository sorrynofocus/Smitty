using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smitty
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            //labelAboutTitle.Text = String.Format("About {0} {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            
           // labelAboutTitle.Text = fvi.OriginalFilename;

            //textBoxDescription.Text = fvi.FileDescription;

            labelProductName.Text = fvi.ProductName;

            labelVersion.Text = fvi.FileVersion;

            labelCopyright.Text = fvi.LegalCopyright;

            //labelCompanyName.Text = fvi.CompanyName;

            // IsDebug IsPrivateBuild SpecialBuild Comments CompanyName custom FILEVERSIONINFO 



        }



        #region public long GetFileAgeByHour (string sFile)
        /// <summary>
        /// Gets the age of a file.
        /// </summary>
        /// <param name="sFile">string to a filename</param>
        /// <returns>long amount of hours</returns>
        public long GetFileAgeByHour (string sFile)
         {
            // Converting this code to C#...
            //unsigned __int64 e0a3(wchar_t* szFileName)
            //{
            //    wchar_t buffer[255] = { '\0' };
            //    unsigned __int64 ui64Now, ui64Then, ui64Hours;
            //    ui64Now = ui64Then = ui64Hours = 0;

            //    HANDLE fHandle;
            //    FILETIME ftCreateTime, ftLastAccess, ftLastWrite, fSysTime;
            //    SYSTEMTIME stLastWrite;
            //    WIN32_FIND_DATA ftWriteLast;
            //    fHandle = FindFirstFile(szFileName, &ftWriteLast);

            //    GetSystemTime(&stLastWrite);
            //    SystemTimeToFileTime(&stLastWrite, &fSysTime);

            //    ui64Then = (((unsigned __int64)ftWriteLast.ftCreationTime.dwHighDateTime) << 32) +ftWriteLast.ftCreationTime.dwLowDateTime;
            //    ui64Now = (((unsigned __int64)fSysTime.dwHighDateTime) << 32) +fSysTime.dwLowDateTime;

            //    ui64Hours = (ui64Now - ui64Then) / 10000000 / 60 / 60;
            //    FindClose(fHandle);
            //    return (ui64Hours);
            //}

            //Test files
            // 12/14/2017 C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys\517efac85db7042e2b9ae54b76f4e58d_3f9d48c8-592d-44ea-8b04-7e4d589b5d67
            // June 29 11pm from 12/14/2017 = 13498 hours = 1.5 years

            // D:\MNT\MNT-BlueGaffer\Virtual-Drive-Development\vs2017-projs\repos\Smitty\Smitty-1.1.0.0\Smitty\bin\Debug\smitty.ini
            // D:\MNT\MNT-BlueGaffer\Virtual-Drive-Development\vs2017-projs\repos\Smitty\Smitty-1.1.0.0\Smitty\bin\Debug\smitty.exe
            // D:\MNT\MNT-BlueGaffer\Virtual-Drive-Development\vs2017-projs\repos\Smitty\Smitty-1.1.0.0\Smitty\bin\Debug\smitty.pdb

            if (sFile.Length == 0)
                return (0);

            //Feed the file inforamtion into fileInfo. We need to get the file creation time.
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(sFile);

            //Now get the file information and convert it to a proper local time.
            System.DateTime ftCreateTime = fileInfo.CreationTime;

            //Get the loca date.
            //Example format: {12/14/2017 1:06:26 PM}
            DateTime dtNow = DateTime.Now;

            //In order to determine the file age in hours, we need to get the current local time (now) and subtract it by the creation time (then).
            //We don't use timespans, but rather ticks, because this is more accurate.
            // 
            //Hold our amount in hours
            long lHours = 0;

            //Use this to get the amount of ticks in a date/time - format: 636488535862267019
            long lTicks = 0;
            lTicks = (dtNow.Ticks - ftCreateTime.Ticks);

            //Verify...
            DateTime dt = new DateTime(ftCreateTime.Ticks);
            string sTestIcles = dt.ToString();

            lHours = lTicks / 10000000 / 60 / 60;

            //Above same as this: 
            // long lHours2 = (dtNow - ftCreateTime).Hours;
            // But wanted to keep the math to better understand.
            // 10000000 milliseconds = 10,000 seconds = Ticks per millisecond
            // 1 Tick is 100 nanoseconds or one ten-millionth of a second.
            // 60 / 60 = 60 minutes, 60 seconds
            //
            // This could apply too:
            //double dHours = 0;
            //dHours = TimeSpan.FromTicks(lTicks).TotalHours;
            return (lHours);
        }
#endregion


        // https://stackoverflow.com/questions/15957984/format-a-timespan-with-years
        // cw modified to include hours
        // example
        //System.IO.FileInfo fileInfo = new System.IO.FileInfo(textBox1.Text);
        //System.DateTime ftCreateTime = fileInfo.CreationTime;
        //labelAboutTitle2.Text = GetAgeText(ftCreateTime);
        public string GetAgeText(DateTime birthDate)
        {
            const double ApproxDaysPerMonth = 30.4375;
            const double ApproxDaysPerYear = 365.25;

            /*
            The above are the average days per month/year over a normal 4 year period
            We use these approximations as they are more accurate for the next century or so
            After that you may want to switch over to these 400 year approximations

               ApproxDaysPerMonth = 30.436875
               ApproxDaysPerYear  = 365.2425 

              How to get theese numbers:
                The are 365 days in a year, unless it is a leepyear.
                Leepyear is every forth year if Year % 4 = 0
                unless year % 100 == 1
                unless if year % 400 == 0 then it is a leep year.

                This gives us 97 leep years in 400 years. 
                So 400 * 365 + 97 = 146097 days.
                146097 / 400      = 365.2425
                146097 / 400 / 12 = 30,436875

            Due to the nature of the leap year calculation, on this side of the year 2100
            you can assume every 4th year is a leap year and use the other approximatiotions

            */
            //Calculate the span in days
            int iDays = (DateTime.Now - birthDate).Days;

            int iHours = (DateTime.Now - birthDate).Hours;

            //Calculate years as an integer division
            int iYear = (int)(iDays / ApproxDaysPerYear);

            //Decrease remaing days
            iDays -= (int)(iYear * ApproxDaysPerYear);

            //Calculate months as an integer division
            int iMonths = (int)(iDays / ApproxDaysPerMonth);

            //Decrease remaing days
            iDays -= (int)(iMonths * ApproxDaysPerMonth);

            //Return the result as an string   
            return string.Format("{0} years, {1} months, {2} days {3} Hours", iYear, iMonths, iDays, iHours);
        }



        private void ButtonAboutClose_Click(object sender, EventArgs e)
        {

            /*
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(textBox1.Text);
            System.DateTime ftCreateTime = fileInfo.CreationTime;
            DateTime dtNow = DateTime.Now;
            // {12/14/2017 1:06:26 PM}

            //var lastmodified = fileInfo.LastWriteTime;
            //{12/14/2017 1:06:26 PM}

            // DateTime fileCreatedDate = System.IO.File.GetCreationTime(textBox1.Text);
            // {12/14/2017 1:06:26 PM}
            ;
            ;

            DateTime structCreationTime = ftCreateTime;

            long lHours = 0;
            long lTicks = 0;
            // 636488535862267019
            //lHours = structCreationTime.Ticks / 10000000 / 60 / 60;
            lTicks = (dtNow.Ticks - structCreationTime.Ticks);
            lHours = lTicks / 10000000 / 60 / 60;
            //Above same as  this: long lHours2 = (dtNow - ftCreateTime).Hours;
            long lHours2 = (dtNow - ftCreateTime).Hours;
            */

            labelAboutTitle.Text = GetFileAgeByHour(textBoxDescription.Text).ToString();





            //Experiemental
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(textBoxDescription.Text);
            System.DateTime ftCreateTime = fileInfo.CreationTime;
            //labelAboutTitle2.Text = GetAgeText(ftCreateTime);
            DateTime structLastWriteTime = fileInfo.LastWriteTime;
            DateTime structLastAccessTime = fileInfo.LastAccessTime;

            var datetimeNow = DateTime.Now;
            //int iDays = (int) (GetFileAgeByHour(textBox1.Text) / 24);

            // 1 year -365
            //2 years - 730
            // 3 yars - 1095
            // 4 years - 1460
            // 5 years - 1825
            int iDays = 1460;


            double[] iDDays = null;

        

            TimeSpan timespanCustomTimeBomb = new TimeSpan(iDays, 0, 0, 0);

            TimeSpan datetimeCreationTimeDifference = datetimeNow - ftCreateTime;
            TimeSpan datetimeLastWriteTimeDifference = datetimeNow - structLastWriteTime;
            TimeSpan datetimeLastAccessTimeDifference = datetimeNow - structLastAccessTime;

            iDDays = new double[3];

            iDDays[0] = datetimeCreationTimeDifference.TotalDays;
            iDDays[1] = datetimeLastWriteTimeDifference.TotalDays;
            iDDays[2] = datetimeLastAccessTimeDifference.TotalDays;

            if (
                    (datetimeCreationTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                    ||
                    (datetimeLastWriteTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
                    ||
                    (datetimeLastAccessTimeDifference.TotalDays >= timespanCustomTimeBomb.TotalDays)
               )
                labelVersion.Text = "true. Older than 757 days  (figure from config DaysToRemove=X)";
            else
                labelVersion.Text = "false. NOT older than 757 days (figure from config DaysToRemove=X)";

        }
    }
}
