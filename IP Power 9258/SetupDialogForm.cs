using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.IPPower9258;
using System.Net.NetworkInformation;

namespace ASCOM.IPPower9258
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm(string version)
        {
            Form form = this.FindForm();

            InitializeComponent();

            Label desc = (Label) form.Controls.Find("description", true)[0];
            desc.Text = string.Format("Opengear IP-Power-9258 driver (ver {0}), supports up to four boxes.", version);

            // Initialise current values of user settings from the ASCOM Profile
            chkTrace.Checked = Switch.traceState;
            for (int boxNo = 0; boxNo < Switch.nBoxes; boxNo++)
            {
                form.Controls.Find("ipAddress" + boxNo.ToString(), true)[0].Text = IPPower9258.Instance.ipAddresses[boxNo];
                form.Controls.Find("user" + boxNo.ToString(), true)[0].Text = IPPower9258.Instance.users[boxNo];
                form.Controls.Find("password" + boxNo.ToString(), true)[0].Text = IPPower9258.Instance.passwords[boxNo];
                ((CheckBox)form.Controls.Find("enabled" + boxNo.ToString(), true)[0]).Checked = IPPower9258.Instance.enabled[boxNo];

                for (int i = 0; i < IPPower9258.nSwitchesPerBox; i++)
                {
                    form.Controls.Find("switchName" + boxNo.ToString() + i.ToString(), true)[0].Text = IPPower9258.Instance.switchNames[boxNo, i];
                    form.Controls.Find("switchDesc" + boxNo.ToString() + i.ToString(), true)[0].Text = IPPower9258.Instance.switchDescriptions[boxNo, i];
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here

            Switch.traceState = chkTrace.Checked;

            Form form = FindForm();
            Control[] controls;
            controls = form.Controls.Find("tabs", true);
            TabControl tabs = (TabControl)controls[0];

            for (int box = 0; box < Switch.nBoxes; box++)
            {
                TabPage page = tabs.TabPages[box];
                
                controls = form.Controls.Find("enabled" + box.ToString(), true);
                if (controls != null)
                {
                    CheckBox enabled = (CheckBox) controls[0];
                    Label status = (Label) form.Controls.Find("status" + box.ToString(), true)[0];

                    if (enabled.Checked)
                    {
                        string address = form.Controls.Find("ipAddress" + box.ToString(), true)[0].Text;
                        string user = form.Controls.Find("user" + box.ToString(), true)[0].Text;
                        string password = form.Controls.Find("password" + box.ToString(), true)[0].Text;

                        IPPower9258.Instance.ipAddresses[box] = address;
                        IPPower9258.Instance.users[box] = user;
                        IPPower9258.Instance.passwords[box] = password;
                    }
                }

                for (int sw = 0; sw < IPPower9258.nSwitchesPerBox; sw++)
                {
                    controls = form.Controls.Find("switchName" + box.ToString() + sw.ToString(), true);
                    if (controls != null)
                        IPPower9258.Instance.switchNames[box, sw] = controls[0].Text;
                    controls = form.Controls.Find("switchDesc" + box.ToString() + sw.ToString(), true);
                    if (controls != null)
                        IPPower9258.Instance.switchDescriptions[box, sw] = controls[0].Text;
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void switchName_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            int switchNo = Int32.Parse(name.Substring(name.Length - 1, 1));
            int boxNo = Int32.Parse(name.Substring(name.Length - 2, 1));

            IPPower9258.Instance.switchNames[boxNo, switchNo] = ((TextBox)sender).Text;
        }

        private void switchDescription_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            int switchNo = Int32.Parse(name.Substring(name.Length - 1, 1));
            int boxNo = Int32.Parse(name.Substring(name.Length - 2, 1));

            IPPower9258.Instance.switchDescriptions[boxNo, switchNo] = ((TextBox)sender).Text;
        }


        private void textIPAddress_Validating(object sender, CancelEventArgs e)
        {
            string address = ((TextBox)sender).Text;

            if (! IPPower9258.ValidIPv4(address))
            {
                e.Cancel = true;
            }
        }
        
        private void enabled_CheckStateChanged(object sender, EventArgs e)
        {
            Form form = FindForm();
            CheckBox cb = (CheckBox)sender;
            int box;
            Int32.TryParse(cb.Name.Substring(cb.Name.Length - 1), out box);
            Label status = (Label)form.Controls.Find("status" + box.ToString(), true)[0];

            if (cb.CheckState == CheckState.Unchecked)
            {
                status.Text = "";
                IPPower9258.Instance.enabled[box] = false;
                return;
            }
            else if (cb.CheckState == CheckState.Checked)
            {
                string address = form.Controls.Find("ipAddress" + box.ToString(), true)[0].Text;
                string user = form.Controls.Find("user" + box.ToString(), true)[0].Text;
                string password = form.Controls.Find("password" + box.ToString(), true)[0].Text;
                string err = null;

                status.Text = "Testing ...";
                if (IPPower9258.Instance.testReachability(box, address, user, password, out err))
                {
                    cb.Checked = true;
                    status.ForeColor = Color.Green;
                    status.Text = "Reachable. Returns valid outlet status.";
                    IPPower9258.Instance.enabled[box] = true;
                } else
                {
                    cb.Checked = false;
                    status.ForeColor = Color.Red;
                    status.Text = err;
                    IPPower9258.Instance.enabled[box] = false;
                }
            }
        }

        private void textIPAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int box;
            Int32.TryParse(tb.Name.Substring(tb.Name.Length - 1), out box);

            IPPower9258.Instance.ipAddresses[box] = tb.Text;
        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int box;
            Int32.TryParse(tb.Name.Substring(tb.Name.Length - 1), out box);

            IPPower9258.Instance.users[box] = tb.Text;
        }

        private void textPassword_textChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int box;
            Int32.TryParse(tb.Name.Substring(tb.Name.Length - 1), out box);

            IPPower9258.Instance.passwords[box] = tb.Text;
        }

        private void testConnectivity(object sender, EventArgs e)
        {
            Form form = FindForm();
            Button button = (Button)sender;
            int box;
            Int32.TryParse(button.Name.Substring(button.Name.Length - 1), out box);
            Label status = (Label)form.Controls.Find("status" + box.ToString(), true)[0];
            string err = null;

            string address = form.Controls.Find("ipAddress" + box.ToString(), true)[0].Text;
            string user = form.Controls.Find("user" + box.ToString(), true)[0].Text;
            string password = form.Controls.Find("password" + box.ToString(), true)[0].Text;

            status.Text = "Testing ...";
            if (IPPower9258.Instance.testReachability(box, address, user, password, out err))
            {
                status.ForeColor = Color.Green;
                status.Text = "Reachable. Returns valid outlet status.";
            } else
            {
                status.ForeColor = Color.Red;
                status.Text = err;
            }
        }
    }
}