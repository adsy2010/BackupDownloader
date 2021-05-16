using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDownloader.Backup
{
    public class BackupOptions
    {

        private IniFile iniFile;

        public BackupOptions()
        {
            this.LoadIni();
        }

        public void LoadIni()
        {
            this.iniFile = new IniFile();
            this.BuildIni();
        }

        public String getBackupDirectory()
        {
            return this.iniFile.Read("BACKUP_DIRECTORY", "BACKUP");
        }

        public List<string> getRemoteDirectories()
        {
            string remoteDirectories = this.iniFile.Read("REMOTE_DIRECTORIES", "BACKUP");

            return new List<string>(remoteDirectories.Split(';'));

        }

        /// <summary>
        /// Creates an INI files keys if they dont exist
        /// </summary>
        public void BuildIni()
        {

            List<string> sshKeys = new List<string>
            {
                "BACKUP_DIRECTORY",
                "REMOTE_DIRECTORIES",
            };

            foreach (string key in sshKeys)
            {
                if (!this.iniFile.KeyExists(key, "BACKUP"))
                {
                    this.iniFile.Write(key, "", "BACKUP");
                }
            }
        }
    }
}
