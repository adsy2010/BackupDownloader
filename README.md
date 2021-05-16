# BackupDownloader

This application was built due to a need to download files from a remote server to a local directory automatically without any thought or interaction. Once the configuration file is setup, the application is ready to use.

## Installing

You can compile the application manually at this time only. 

- Copy all files from `bin/release` or `bin/debug` into a directory you plan on running the application from
- Run the BackupDownloader.exe application
- Fill in the BackupDownloader.ini files SSH section and save
  - [SSH]
  - HOST="The host name or ip address"
  - USERNAME="The username you access the server with"
  - SSH_KEY_PASSWORD="Your SSH key password for your SSH private key"
  - HOST_KEY="The host key fingerprint ssh-rsa 3072 ab:de:fg:hi.... etc"
  - SSH_PRIVATE_KEY_PATH="The path to the SSH private ppk file"

- Now run the application again and fill in the configurations BACKUP section
  - [BACKUP]
  - BACKUP_DIRECTORY="The local directory you are backing up to"
  - REMOTE_DIRECTORIES"A list of remote full path directories separated by ; "

<pre>
  [SSH]
  HOST="127.0.0.1"
  USERNAME="root"
  SSH_KEY_PASSWORD="password"
  HOST_KEY="ssh-rsa 3072 sdfouHGFHFg934GFHGFHDSGF"
  SSH_PRIVATE_KEY_PATH="C:\Users\me\backup folders\SSH\PRIVATE.ppk"
  [BACKUP]
  BACKUP_DIRECTORY="C:\Users\me\backup folders\automated"
  REMOTE_DIRECTORIES="/var/www/sites/mysite.co.uk/backups;/var/www/sites/mysecondsite.co.uk/backups"
</pre>

The next time you run the application it will sync all files from the remote directories to the chosen local directory. This is a one way transfer and will not remove any files from either side of the connection. As there is 0 loss of data from either side, you can safely setup a scheduled task to run the application as often as you like.
