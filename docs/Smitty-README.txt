This is the initial README file. It is intended to be an instruction manual in the future. -cW

 Smitty
 
 C. Winters / US / California / Culver City
 2018
 
 prototype/smitty
 
 Purpose - machine system info/maint utility.
 Smitty is defined as a utility to help automate configuration and updating machines. It is intended to:

 - Clean temporary files, including customised directories, on specific time periods
 - Able to push software by FTP.
 - Able to install pushed software
 - Able to recognise custom install scripts and an internal command line interpreter (TinyMAN [tiny -mobil automation network) will aid in installation.
 - Able to push commands to run or operate on machine as if the person was logged into it. The internal command line interpreter (TinyMAN) will aid in automating tasks.
 - (Future R&D) Create a mobile app to use TinyMAN to perform automated tasks during after hours.
 - (FUTURE R&D) synthetic intelligence to gather known troubleshooting issues in order to automate fixes instead of user repeating fixes. (Will use MySQL type database)
 - Auto update when future releases are developed. 
 - Able to configure auto-logins, registry tweaks, options and save options via INI, XML, or registry. Currently, INI is used but will switch to XML based on user experience.
 - Able to gather inventory of machine and generate report to send to end users. The inventory will be software versions, install locations, memory, CPU, etc. It can be transported using TinyMAN scripts and FTP.
 - (FUTURE R&D) Able to detect some machine changes. Monitor registry dumps and certain directories for changes and generate reports.
 
 NOTES:
 There's still a lot of work, but getting the temp dir/file removals are a priority. That's 95% complete. Testing has been successful. Bugs not tracked yet.
 See TODOs for additional work on prototype.


INSTALLATION:
Copy smitty.exe and smitty.ini over to the machine you wish to use. Currently, there isn't an install method. Also, no dependencies :)

OPERATION:
Run Smitty and it will appear onscreen. The UI is tabulated for each specific operation. Currently, 1.0.0 only searches for temp and custom files to remove. This willbe stored into the configuration file. 

When you close Smitty, it will appear in the TASKBAR tray to operate silently. The icon is a small sleeping pig. When active, it changes to an awake pig. Right clicking on the smitty pig icon will close the application.