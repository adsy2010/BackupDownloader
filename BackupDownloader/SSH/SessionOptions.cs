using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDownloader.SSH
{
    public class SessionOptions
    {
        private WinSCP.SessionOptions sessionOptions;
        private IniFile iniFile;
        
        public SessionOptions()
        {
            this.sessionOptions = new WinSCP.SessionOptions();
            this.sessionOptions.FtpMode = WinSCP.FtpMode.Passive;

            try
            {
                this.LoadIni();

                this.sessionOptions.FtpMode = WinSCP.FtpMode.Passive;
                this.sessionOptions.HostName = this.iniFile.Read("HOST", "SSH");
                this.sessionOptions.UserName = this.iniFile.Read("USERNAME", "SSH");
                this.sessionOptions.SshHostKeyFingerprint = this.iniFile.Read("HOST_KEY", "SSH");
                this.sessionOptions.SshPrivateKeyPath = this.iniFile.Read("SSH_PRIVATE_KEY_PATH", "SSH");
                this.sessionOptions.PrivateKeyPassphrase = this.iniFile.Read("SSH_KEY_PASSWORD", "SSH");
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed connection: " + exception.Message);
                Console.Read();
            }

        }

        public WinSCP.SessionOptions getSessionOptions()
        {
            return this.sessionOptions;
        }

        public void LoadIni()
        {
            this.iniFile = new IniFile();
            this.BuildIni();
        }

        /// <summary>
        /// Creates an INI files keys if they dont exist
        /// </summary>
        public void BuildIni()
        {

            List<string> sshKeys = new List<string>
            {
                "HOST",
                "USERNAME",
                "SSH_KEY_PASSWORD",
                "HOST_KEY",
                "SSH_PRIVATE_KEY_PATH"
            };

            foreach (string key in sshKeys)
            {
                if (!this.iniFile.KeyExists(key, "SSH"))
                {
                    this.iniFile.Write(key, "", "SSH");
                }
            }
        }
         
    }
}
