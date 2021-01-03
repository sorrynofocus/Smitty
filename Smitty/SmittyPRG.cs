using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Smitty
{
    static class SmittyPRG
    {
        public static string STRING_CONFIG_FILE = ".\\smitty.ini";
        public static string STRING_EXPORT_DRV_FILE = ".\\ExportedDrives.txt";
        public static string STRING_LOGGING_FILE = ".\\files_processed.log";
        public static bool bAutoClean = false;
        public static bool bStartConfig = false;
        public static bool bByCmdLine = false;
        public static bool bStartUpdate = false;

        // NOTE: Single application mutex is NOT easy in C# but I did find a temp solution on codeproject:
        // https://www.codeproject.com/tips/702830/single-instance-form-application-in-csharp
        //
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //        [STAThread]
        //        static void Main()
        //        {
        //
        //            Application.EnableVisualStyles();
        //            Application.SetCompatibleTextRenderingDefault(false);
        //            Application.Run(new frmMain());
        //        }

        //Used online GUID gen to create a unique namespace for mutex. 
        private static String SingleAppComEventName = "266bf9d4-629f-4e41-bcbc-5b3d5c33f817";
        private static BackgroundWorker singleAppComThread = null;
        private static EventWaitHandle threadComEvent = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string[] sPrgArgs = Environment.GetCommandLineArgs();

            //string s1 = ""; string s2 = ""; string sIndexArg = "";
            //string sIndexArg = "";
            //int iArIndex = 0;

            Dictionary<string, string> dictArgs = new Dictionary<string, string>();

            //int index = Array.IndexOf ( sPrgArgs, "autoclean" );
            //iArIndex = Array.FindIndex ( sPrgArgs, m => m == "/autoclean" );

//            for (int iIndex = 1; iIndex < sPrgArgs.Length - 1; iIndex +=2)
            for (int iIndex = 1; iIndex < sPrgArgs.Length; iIndex += 2)
            {
                try
                {
                    if (sPrgArgs[iIndex].Contains ( "/" ) && sPrgArgs[iIndex + 1].Contains ( "/" ))
                    {
                      dictArgs.Add ( sPrgArgs[iIndex].Replace ( "/", "" ), sPrgArgs[iIndex].Replace ( "/", "" ) );
                        iIndex--;
                    }
                    else
                    {
                        dictArgs.Add ( sPrgArgs[iIndex].Replace ( "/", "" ), sPrgArgs[iIndex +1].Replace ( "/", "" ) );
                        //iIndex +=2;
                    }

                }
                //catch (Exception e)
                catch ( Exception )
                {
                    dictArgs.Add ( sPrgArgs[iIndex].Replace ( "/", "" ), sPrgArgs[iIndex].Replace ( "/", "" ) );
                    }
            }

            //Override configuration file switch
            // /cfg "C:\Users\chris_winters\Documents\Visual Studio 2017\Projects\Smitty\Smitty\bin\Debug\smitty.ini" 
            if (dictArgs.ContainsKey("cfg"))
            {
                //Override the config file
                SmittyPRG.STRING_CONFIG_FILE = dictArgs["cfg"];
                bByCmdLine = true;
            }

            //Autoclean switch
            // /autoclean true
            //This will perform an autoclean on C:. It removed windows/temp and user profile temp. 
            //If configuration file has been loaded then it will search and remove files based on config settings. 
            //Log file will be created in base directory.
            if (dictArgs.ContainsKey("autoclean"))
            {
                bAutoClean = true;
                bByCmdLine = true;
                //Configure to autoclean Main C: and then run the automation to clean the rest via config file
                //MessageBox.Show("autoclean ENABLED: " + dictArgs["autoclean"]);
                

            }

            //configme switch
            // /configme true
            //If you don't have a config file and want to start your own... 
            if (dictArgs.ContainsKey("configme"))
            {
                bStartConfig = true;
                bByCmdLine = true;


            }

            //configme switch
            // /configme true
            //If you don't have a config file and want to start your own... 
            if (dictArgs.ContainsKey("update"))
            {
                bStartUpdate = true;
                bByCmdLine = true;
            }


            //Override log file usage switch
            // /log c:\files_processed.log
            // If you want to use your own log file, use this switch.
            //NOTE: If a logfile is configured in an INI file, then thi
            if (dictArgs.ContainsKey("log"))
            {
                //Override the log file
                SmittyPRG.STRING_LOGGING_FILE = dictArgs["log"];
                bByCmdLine = true;
            }

            //... More configs here....

            //DON'T modify anything below. Lot's of math. ^_^
            try
            {
                // another instance is already running if OpenExsting succeeds.
                threadComEvent = EventWaitHandle.OpenExisting(SingleAppComEventName);
                threadComEvent.Set();  // signal the other instance.
                threadComEvent.Close();
                return;    // return immediatly.
            }
            catch { /* don't care about errors */     }
            // Create the Event handle
            threadComEvent = new EventWaitHandle(false, EventResetMode.AutoReset, SingleAppComEventName);
            CreateInterAppComThread();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            // End the communication thread.
            singleAppComThread.CancelAsync();
            while (singleAppComThread.IsBusy)
                Thread.Sleep(50);
            threadComEvent.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        static private void CreateInterAppComThread()
        {
            singleAppComThread = new BackgroundWorker();
            singleAppComThread.WorkerReportsProgress = false;
            singleAppComThread.WorkerSupportsCancellation = true;
            singleAppComThread.DoWork += new DoWorkEventHandler(singleAppComThread_DoWork);
            singleAppComThread.RunWorkerAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static private void singleAppComThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            WaitHandle[] waitHandles = new WaitHandle[] { threadComEvent };

            while (!worker.CancellationPending)
            {
                // check every second for a signal.
                if (WaitHandle.WaitAny(waitHandles, 1000) == 0)
                {
                    // The user tried to start another instance. We can't allow that, 
                    // so bring the other instance back into view and enable that one. 
                    // That form is created in another thread, so we need some thread sync magic.
                    if (Application.OpenForms.Count > 0)
                    {
                        Form mainForm = Application.OpenForms[0];
                        mainForm.Invoke(new SetFormVisableDelegate(ThreadFormVisable), mainForm);
                    }
                }
            }
        }
        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// When this method is called using a Invoke then this runs in the thread
        /// that created the form, which is nice. 
        /// </summary>
        /// <param name="frm"></param>
        private delegate void SetFormVisableDelegate(Form frm);
        static private void ThreadFormVisable(Form frm)
        {
            if (frm != null)
            {
                // display the form and bring to foreground.
                frm.Visible = true;
                frm.WindowState = FormWindowState.Normal;
                frm.Show();
                SetForegroundWindow(frm.Handle);
            }
        }
        //End of single application mutex

    }
}
