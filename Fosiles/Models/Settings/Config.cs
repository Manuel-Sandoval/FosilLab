using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace Fosiles.Models.Settings
{
    public class Config
    {
        private string protocol;
        private string host;
        private string port;
        private string server;
        private string serviceName;
        private string user;
        private string password;

        public string Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public void cargarConfig(string path)
        {

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(path);

            this.protocol = data["CONEXION"]["Protocol"];
            this.host = data["CONEXION"]["Host"];
            this.port = data["CONEXION"]["Port"];
            this.server = data["CONEXION"]["Server"];
            this.serviceName = data["CONEXION"]["serviceName"];
            this.user = data["CONEXION"]["User"];
            this.password = data["CONEXION"]["Password"];

        }
    }
}
