using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ASCOM.Wise40.Hardware;
using System.Net;
using System.IO;

namespace ASCOM.IPPower9258
{
    public class IPPower9258
    {
        public string[] switchNames = new string[4];
        public string[] switchDescriptions = new string[4];
        public string ipAddress;
        private short numSwitch = 4;

        private NetworkCredential credentials = new NetworkCredential("admin", "12345678");

        private static readonly IPPower9258 instance = new IPPower9258(); // Singleton

        public static IPPower9258 Instance   // Singleton
        {
            get
            {
                return instance;
            }
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
            string url = string.Format("http://{0}/Set.cmd?CMD=GetPower", ipAddress);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = credentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream);
            string statLine = readStream.ReadToEnd();
            statLine = statLine.Remove(0, 6);
            statLine = statLine.Remove(statLine.IndexOf('<'));
            string[] stats = statLine.Split(',');
            string status = stats[id].Remove(0, stats[id].IndexOf('=') + 1);
            return (status == "0") ? false : true;
        }

        public void SetSwitch(short id, bool state)
        {
            string setting = string.Format("P6{0}={1}", id, state ? "1" : "0");
            string url = string.Format("http://{0}/Set.cmd?CMD=SetPower+{1}", ipAddress, setting);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = credentials;
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
            return switchNames[id];
        }

        public void SetSwitchName(short id, string name)
        {
            switchNames[id] = name;
        }

        public string GetSwitchDescription(short id)
        {
            return switchDescriptions[id];
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

    }
}
