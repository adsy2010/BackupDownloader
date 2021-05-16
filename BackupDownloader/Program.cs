using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackupDownloader.SSH;

namespace BackupDownloader
{
    class Program
    {
        private static SessionOptions sessionOptions = new SessionOptions();

        static void Main(string[] args)
        {
            try
            {
                WinSCP.Session session = new WinSCP.Session();
            
                session.Open(Program.sessionOptions.getSessionOptions());
                if (session.Opened) {
                    Console.WriteLine("Connected successfully");

                    Backup.BackupOptions backupOptions = new Backup.BackupOptions();

                    foreach (string remoteDirectory in backupOptions.getRemoteDirectories())
                    {
                        session.SynchronizeDirectories(WinSCP.SynchronizationMode.Local, backupOptions.getBackupDirectory(), remoteDirectory, false);
                        Console.WriteLine("backed up: " + remoteDirectory);
                    }
                    //session.GetFilesToDirectory(downloadBackupDirectory, @"C:\Users\adsy2\WS Backups\automated");

                }
                session.Close();
                Console.WriteLine("Disconnected");
            }
            catch(Exception exception)
            {
                Console.WriteLine("Failed connection: " + exception.Message);
                
                Console.Read();
            }


        }
    }
}
