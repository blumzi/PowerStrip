using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ASCOM.Wise40.Hardware;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;

namespace ASCOM.IPPower9258
{
    public class IPPower9258
    {
        public const int nSwitchesPerBox = 4;
        private int nBoxes;

        public string[,] switchNames;
        public string[,] switchDescriptions;
        public string[] ipAddresses;
        public bool[] enabled;
        public string[] users;
        public string[] passwords;
        private NetworkCredential[] credentials;

        private short numSwitch;    // total number of switch output ports

        // private NetworkCredential credentials = new NetworkCredential("admin", "12345678");

        private static readonly IPPower9258 instance = new IPPower9258(); // Singleton

        public static IPPower9258 Instance   // Singleton
        {
            get
            {
                return instance;
            }
        }

        public void init(int nBoxes)
        {
            Instance.nBoxes = nBoxes;
            Instance.numSwitch = (short)(nBoxes * nSwitchesPerBox);
            Instance.switchNames = new string[nBoxes, IPPower9258.nSwitchesPerBox];
            Instance.switchDescriptions = new string[nBoxes, IPPower9258.nSwitchesPerBox];
            Instance.ipAddresses = new string[nBoxes];
            Instance.users = new string[nBoxes];
            Instance.passwords = new string[nBoxes];
            Instance.enabled = new bool[nBoxes];
            Instance.credentials = new NetworkCredential[nBoxes];
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static IPPower9258()
        {
        }

        private IPPower9258()
        {
        }

        public short MaxSwitch
        {
            get
            {
                return numSwitch;
            }
        }

        public bool GetSwitch(short id)
        {
            int boxNo = id / nSwitchesPerBox;

            if (!enabled[boxNo])
                throw new InvalidValueException(string.Format("Box #{0} is disabled", boxNo));

            string url = string.Format("http://{0}/Set.cmd?CMD=GetPower", ipAddresses[boxNo]);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (credentials[boxNo] == null)
                credentials[boxNo] = new NetworkCredential(users[boxNo], passwords[boxNo]);
            request.Credentials = credentials[boxNo];

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream);

            // <html>P60=0,P61=0,P62=0,P63=0,P64=0,P65=0,P66=0,P67=0</html>
            string statLine = readStream.ReadToEnd();
            statLine = statLine.Remove(0, 6);
            statLine = statLine.Remove(statLine.IndexOf('<'));
            string[] stats = statLine.Split(',');
            string status = stats[id].Remove(0, stats[id].IndexOf('=') + 1);
            return (status == "0") ? false : true;
        }

        public void SetSwitch(short id, bool state)
        {
            int boxNo = id / nSwitchesPerBox;

            if (!enabled[boxNo])
                throw new InvalidValueException(string.Format("Box #{0} is disabled", boxNo));

            string setting = string.Format("P6{0}={1}", id, state ? "1" : "0");
            string url = string.Format("http://{0}/Set.cmd?CMD=SetPower+{1}", ipAddresses[boxNo], setting);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (credentials[boxNo] == null)
                credentials[boxNo] = new NetworkCredential(users[boxNo], passwords[boxNo]);
            request.Credentials = credentials[boxNo];
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream);

            string stat = readStream.ReadToEnd().Remove(0, "<html>".Length);
            stat = stat.Remove(stat.IndexOf('<'));
            if (!stat.StartsWith(setting))
                throw new InvalidOperationException(string.Format("Could not set: {0}", url));
        }

        public string GetSwitchName(short id)
        {
            return switchNames[id / nSwitchesPerBox, id % nSwitchesPerBox];
        }

        public void SetSwitchName(short id, string name)
        {
            switchNames[id / nSwitchesPerBox, id % nSwitchesPerBox] = name;
        }

        public string GetSwitchDescription(short id)
        {
            return switchDescriptions[id / nSwitchesPerBox, id % nSwitchesPerBox];
        }

        public static bool ValidIPv4(string s)
        {
            if (s == null || s == string.Empty)
                return false;

            var quads = s.Split('.');
            if (quads.Length != 4)
                return false;
            foreach (var quad in quads)
            {
                int q;
                if (!Int32.TryParse(quad, out q) ||
                    !q.ToString().Length.Equals(quad.Length) ||
                    q < 0 ||
                    q > 255)
                    return false;
            }
            return true;
        }

        public bool makeCredentials(int box, string address, string user, string password, out string err)
        {
            IPAddress addr = null;

            err = null;

            if (address == string.Empty)
                err += "  Empty address\n";
            else if (!System.Net.IPAddress.TryParse(address, out addr))
                err += string.Format("  Invalid address \"{0}\"\n", address);

            if (user == string.Empty)
                err += "  Empty user name\n";

            if (password == string.Empty)
                err += "  Empty password\n";

            /*
            if (err == null && addr != null)
            {
                try
                {
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(addr);
                    if (reply.Status != IPStatus.Success)
                        err += string.Format("  Unreachable address {0}\n", address);
                }
                catch (Exception ex)
                {
                    err += ex.Message;
                }


                bool wasEnabled = enabled[box];
                enabled[box] = true;
                try
                {
                    GetSwitch((short)(box * nSwitchesPerBox)); // try to get the status of outlet[0]
                }
                catch (Exception ex)
                {
                    err += string.Format("  Cannot GET outlet[0] status from \"{0}\" ({1})", address, ex.Message);
                }
                enabled[box] = wasEnabled;
            }
            */

            if (err != null)
                return false;

            instance.ipAddresses[box] = address;
            instance.users[box] = user;
            instance.passwords[box] = password;
            instance.credentials[box] = new NetworkCredential(user, password);
            return true;
        }

        public bool testReachability(int box, string address, string user, string password, out string err)
        {
            IPAddress addr;
            err = null;

            if (address == string.Empty)
            {
                err += "Empty address.";
                return false;
            }

            if (!System.Net.IPAddress.TryParse(address, out addr))
            {
                err += "Invalid address";
                return false;
            }

            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(addr);
                if (reply.Status != IPStatus.Success)
                    err += string.Format("  Unreachable address {0}", address);
            }
            catch (Exception ex)
            {
                err += "(" + ex.Message + ")";
                return false;
            }
            err += "Reachable. ";

            if (user == string.Empty || password == string.Empty)
            {
                err += "User or password are empty.";
                return false;
            }

            bool wasEnabled = enabled[box];
            enabled[box] = true;
            try
            {
                GetSwitch((short)(box * nSwitchesPerBox)); // try to get the status of outlet[0]
                enabled[box] = wasEnabled;
                err += " Returns valid outlet status.";
                return true;
            }
            catch (Exception ex)
            {
                err += ex.Message;
                enabled[box] = wasEnabled;
                return false;
            }
        }
    }
}