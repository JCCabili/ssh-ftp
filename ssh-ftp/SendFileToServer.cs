using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssh_ftp
{
    public static class SendFileToServer
    {
        // Enter your host name or IP here
        private static string host = "192.168.1.8";
        // Enter your sftp username here
        private static string username = "allcard";
        // Enter your sftp password here
        private static string password = "AllcardTech2k15$pi";



        public static int Send(string fileName,string directory)
        {
            var connectionInfo = new ConnectionInfo(host, "allcard", new PasswordAuthenticationMethod(username, password));
            // Upload File
            using (var sftp = new SftpClient(connectionInfo))
            {

                sftp.Connect();
                //sftp.ChangeDirectory("/home/allcard/mycampusv2");
                sftp.ChangeDirectory(directory);
                using (var uplfileStream = System.IO.File.OpenRead(fileName))
                {
                    
                    sftp.UploadFile(uplfileStream, "mycampusv2.initest", true);
                }
                sftp.Disconnect();
            }
            return 0;
        }
    }
}
