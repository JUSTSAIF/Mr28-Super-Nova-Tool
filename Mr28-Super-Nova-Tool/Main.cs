using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mr28_Super_Nova_Tool

////////////////////////////////////
//     Created By SAIF -  Mr28    //
//      Created In 2020-10-?!     //
////////////////////////////////////
{
    public partial class Main : Form
    {
        // Change Color
        private void change_color(Label lc)
        {
            while (true)
            {
                string[] color_hex = { "#3B1EEE", "#AD16F9", "#1665F9", "#F2F916", "#F91616", "#F9168E", "#16E1F9", "#008E11" };
                Random random = new Random();
                int s_c = random.Next(0, color_hex.Length);
                Color _color = System.Drawing.ColorTranslator.FromHtml(color_hex[s_c]);
                int s_c2 = random.Next(0, color_hex.Length);
                Color _color2 = System.Drawing.ColorTranslator.FromHtml(color_hex[s_c2]);
                lc.ForeColor = _color;
                Thread.Sleep(1500);
            }
        }
        // Form SS
        int mov;
        int movX;
        int movY;
        // AppData Sys
        string ApplicationDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Move(object sender, EventArgs e) { }
        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            // Random Title Color
            new Thread(new ThreadStart(() => change_color(title_line))).Start();
            // AppData File Maker
            if (!File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team"))
            {
                System.IO.Directory.CreateDirectory(ApplicationDataDirectory + "/Mr28-Super-Nova-Team");
                System.IO.Directory.CreateDirectory(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs");
                System.IO.Directory.CreateDirectory(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb");
                System.IO.Directory.CreateDirectory(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX");
                System.IO.Directory.CreateDirectory(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices");
            }
            // Check PKGs
            string rootAppFr = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/";
            string AdbShellPath = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb/";
            if (!File.Exists(rootAppFr+"DF.exe") || !File.Exists(rootAppFr + "BlueScreenFix.apk") || !File.Exists(rootAppFr + "ChangeComputerInfo.exe") || !File.Exists(rootAppFr + "Patch.exe") || !File.Exists(rootAppFr + "CT.bat") || !File.Exists(rootAppFr + "HDNC.exe") || !File.Exists(AdbShellPath + "adb.exe") || !File.Exists(AdbShellPath + "AdbWinApi.dll") || !File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/ProjectTitan.exe") || !File.Exists(AdbShellPath + "gl.bat") || !File.Exists(AdbShellPath + "kr.bat"))
            {
                // Start 
                DPanel_.Visible = true;
                DTools_loading.Visible = true;
                D_Title.Visible = true;
                Downloading_names.Visible = true;
                DTools_loading.Start();
                WebClient webClient = new WebClient();
                void stratDownloadingTools()
                {
                    // 1
                    if (!File.Exists(rootAppFr + "DF.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Defender Control"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779745661070344212/DF.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/DF.exe");
                    }
                    // 2
                    if (!File.Exists(rootAppFr + "BlueScreenFix.apk"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading BlueScreen Fix :: Apk File"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779744010239213568/BlueScreenFix.apk", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/BlueScreenFix.apk");
                    }
                    // 3
                    if (!File.Exists(rootAppFr + "ChangeComputerInfo.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Change Computer Info EXE File"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779744093377921094/ChangeComputerInfo.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/ChangeComputerInfo.exe");
                    }
                    // 4
                    if (!File.Exists(rootAppFr + "Patch.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading PH EXE File"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779744107840274473/Patch.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Patch.exe");
                    }
                    // 5
                    if (!File.Exists(rootAppFr + "CT.bat"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Temp Cleaner PKG ... BAT File"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779775967563481118/CT.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/CT.bat");
                    }
                    // 6
                    if (!File.Exists(rootAppFr + "HDNC.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Hard Disk Serial Number Changer Tool :: EXE File ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/779745448352546826/HDNC.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/HDNC.exe");
                    }
                    // 7/1
                    if (!File.Exists(AdbShellPath + "adb.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Hard Disk Serial Number Changer Tool :: EXE File ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780049790385520640/adb.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb/adb.exe");
                    }
                    // 7/2
                    if (!File.Exists(AdbShellPath + "AdbWinApi.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Hard Disk Serial Number Changer Tool :: EXE File ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780049794139815936/AdbWinApi.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb/AdbWinApi.dll");
                    }
                    // 8
                    if (!File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/ProjectTitan.exe"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading Project Titan : Fix 60 FPS ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780399744618463242/ProjectTitan.exe", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/ProjectTitan.exe");
                    }
                    // 9
                    if (!File.Exists(AdbShellPath + "gl.bat"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading gl.bat ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780167586418917396/gl.bat", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/gl.bat");
                    }
                    // 10
                    if (!File.Exists(AdbShellPath + "kr.bat"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading kr.bat ..."));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780167590416875570/kr.bat", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/kr.bat");
                    }

                    Thread.Sleep(400);
                    Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Done ..."));
                    // Stop 
                    Thread.Sleep(1600);
                    DPanel_.Invoke((MethodInvoker)(() => DPanel_.Visible = false));
                    DTools_loading.Invoke((MethodInvoker)(() => DTools_loading.Visible = false));
                    Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Visible = false));
                    D_Title.Invoke((MethodInvoker)(() => D_Title.Visible = false));
                    DTools_loading.Stop();
                }
                Thread StartAppJob = new Thread(stratDownloadingTools);
                StartAppJob.Start();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (IP_flush.Checked == true)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C ipconfig /all & ipconfig /registerdns & ipconfig /displaydns & ipconfig /release & ipconfig /renew & ipconfig /flushdns & netsh int ip reset & netsh winsock reset & netsh interface ipv4 reset & netsh interface ipv6 reset & netsh advfirewall reset & nbtstat -r& nbtstat -rr";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    MessageBox.Show("Done");
                    process.Close();
                    Thread.Sleep(400);
                    IP_flush.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Unknown Err :: !");
                }
            }
        }
        private void OpenDep_Click(object sender, EventArgs e)
        {
            Process.Start("systempropertiesdataexecutionprevention.exe");
        }
        private void Open_Hosts_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", @"c:\Windows\System32\drivers\etc");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Super Nova Err ::\n " + ex.Message.ToString() + "\n Contact To Admin");
            }
        }
        private void DefHosts_Click(object sender, EventArgs e)
        {
            File.Delete("c:\\Windows\\System32\\drivers\\etc\\hosts");
            if (!File.Exists("C:\\Windows\\System32\\drivers\\etc\\hosts"))
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/777978703103131708/779670699765661707/hosts", @"c:\Windows\System32\drivers\etc\hosts");
            }
            else
            {
                File.Delete("c:\\Windows\\System32\\drivers\\etc\\hosts");
                MessageBox.Show("AN error occurred, please restart tool with admin privileges :: Nova");
            }
            MessageBox.Show("Done");
        }
        private void Win_Update_Click(object sender, EventArgs e)
        {
            if (File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/1"))
            {
                winupdate wu = new winupdate();
                wu.Show();
            }
            else
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C net stop wuauserv & net stop bits & net stop dosvc & sc config wuauserv start= disabled";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    using (File.Create(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/1")) { } ;
                    MessageBox.Show("Done");
                    process.Close();
                }
                catch
                {
                    MessageBox.Show("Unknown Err :: !");
                }
            }
        }
        private void FullDriversD_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.mediafire.com/file/ztb54f5hinghurq/Full_Driver.zip/file");
        }
        private void None_bu1_Click(object sender, EventArgs e)
        {
            Process.Start("https://mega.nz/file/GY1GXKZL#vVhh7BOhMwBnAZ7B2QxCC6xxoB2pE3TdItebVMU70es");
        }
        private void VlueScreenD_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.mediafire.com/file/o4mhl6mpwgp3sub/aio-runtimes_v2.5.0.rar/file");
        }
        private void FixPUBG_Click(object sender, EventArgs e)
        {

        }
        private void KEmu_CheckedChanged(object sender, EventArgs e)
        {
            if (KEmu.Checked == true)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C taskkill /f /im dnf.exe & taskkill /f /im tensafe_1.exe & taskkill /f /im tensafe_2.exe & taskkill /f /im tencentdl.exe & taskkill /f /im conime.exe & taskkill /f /im QQDL.EXE & taskkill /f /im qqlogin.exe & taskkill /f /im dnfchina.exe & taskkill /f /im dnfchinatest.exe & taskkill /f /im txplatform.exe & taskkill /f /im aow_exe.exe & taskkill /F /IM TitanService.exe & taskkill /F /IM ProjectTitan.exe & taskkill /F /IM Auxillary.exe & taskkill /F /IM TP3Helper.exe & taskkill /F /IM tp3helper.dat & TaskKill /F /IM androidemulator.exe & TaskKill /F /IM aow_exe.exe & TaskKill /F /IM QMEmulatorService.exe & TaskKill /F /IM RuntimeBroker.exe & taskkill /F /im adb.exe & taskkill /F /im GameLoader.exe & taskkill /F /im TBSWebRenderer.exe & taskkill /F /im AppMarket.exe & taskkill /F /im AndroidEmulator.exe";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    MessageBox.Show("Done");
                    process.Close();
                    Thread.Sleep(400);
                    KEmu.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Unknown Err :: !");
                }

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e){ }
        private void DTools_loading_Click(object sender, EventArgs e){}
        private void DPanel__MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
        private void DPanel__MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void DPanel__MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        private void DefCon_Click(object sender, EventArgs e)
        {
            Process.Start(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/DF.exe");

        }
        private void HDD_Spoofer_Click(object sender, EventArgs e)
        {
            Process.Start(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/HDNC.exe");
        }
        private void ClearTempGGD_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearTempGGD.Checked == true)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C  start "+ ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/CT.bat";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.Close();
                    MessageBox.Show("Done");
                    ClearTempGGD.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Unknown Err :: !");
                }
            }
        }
        private void FireReset_CheckedChanged(object sender, EventArgs e)
        {
            if (FireReset.Checked == true)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C  netsh advfirewall reset";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                process.Close();
                MessageBox.Show("Done");
                ClearTempGGD.Checked = false;
            }
        }
        private void ChangeComputerInfoFF_Click(object sender, EventArgs e)
        {
            //Process.Start(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/ChangeComputerInfo.exe");
            //Process.Start(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Patch.exe");
            MessageBox.Show("Work Note :: Enable");
        }
        private void Bu_apkui_Click(object sender, EventArgs e)
        {
            // Download Twitter App
            void downloadtwfn()
            {
                txtpercent.Visible = true;
                wc_DownloadProgress.Visible = true;
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Visible = true));
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Text = "Downloading Twitter 53.2 MB ..."));
                string filename = "Twitter.apk";
                // https://srv-store3.gofile.io/download/CNLJBf/Twitter.apk
                string url = "https://cdn.discordapp.com/attachments/779739850483695626/780399346729484288/twitter-8-71-0-release-00.apk";
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += wc_completed;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new Uri(url), ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Twitter.apk");
                }
            }
            // Download Es File App
            void downloadESFfn()
            {
                txtpercent.Visible = true;
                wc_DownloadProgress.Visible = true;
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Visible = true));
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Text = "Downloading ES File 20.7 MB ..."));
                string filename = "ES_FILE.apk";
                // https://srv-store2.gofile.io/download/qast6u/ES_FILE.apk
                string url = "https://cdn.discordapp.com/attachments/779739850483695626/780398732272468018/es-file-explorer-4-2-3-4-1.apk";
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += wc_completed;
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new Uri(url), ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/ES_FILE.apk");
                }
            }

            if (install_APK_ui.Text == "Twitter")
            {
                if (!File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Twitter.apk"))
                {
                    downloadtwfn();
                }
                else if(File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Twitter.apk"))
                {
                    string TwSize = getFileSizeM("Twitter.apk").ToString();
                    if (TwSize != "53")
                    {
                        downloadtwfn();
                    }else if(TwSize == "53")
                    {
                        Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
                        if (processesSMART.Length > 0)
                        {
                            InstallApkPB_.Visible = true;
                            InstallApkPB_.Start();
                            install_apk_title.Visible = true;
                            void killadb()
                            {
                                // Kill ADB 
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.Arguments = "/C  TaskKill /F /IM adb.exe";
                                startInfo.Verb = "runas";
                                process.StartInfo = startInfo;
                                process.Start();
                                process.Close();
                            }
                            void InstallTw()
                            {
                                ProcessStartInfo twi = new ProcessStartInfo("cmd.exe");
                                twi.Arguments = "/c adb.exe install ../pkgs/Twitter.apk";
                                twi.UseShellExecute = false;
                                twi.WindowStyle = ProcessWindowStyle.Hidden;
                                twi.WorkingDirectory = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb";
                                twi.RedirectStandardOutput = true;
                                twi.CreateNoWindow = true;
                                var proc = Process.Start(twi);
                                string twi_output = proc.StandardOutput.ReadToEnd();
                                if (twi_output.Contains("Success") == true)
                                {
                                    MessageBox.Show("APK File Has Been Successfully Installed . ");
                                    InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                    install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                    InstallApkPB_.Stop();
                                    killadb();
                                }
                                else
                                {
                                    MessageBox.Show("APK File Has Been Falid to Install . ");
                                    InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                    install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                    InstallApkPB_.Stop();
                                    killadb();
                                }
                                proc.Close();
                            }
                            Thread installtwthd = new Thread(InstallTw);
                            installtwthd.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please Open Emulator First !!");
                        }
                    }
                }
            }
            else if (install_APK_ui.Text == "ES File")
            {
                if (!File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/ES_FILE.apk"))
                {
                    downloadESFfn();
                }
                else if (File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/ES_FILE.apk"))
                {
                    string TwSize = getFileSizeM("ES_FILE.apk").ToString();
                    if (TwSize != "21")
                    {
                        downloadESFfn();
                    }
                    else if (TwSize == "21")
                    {
                        Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
                        if (processesSMART.Length > 0)
                        {
                            InstallApkPB_.Visible = true;
                            InstallApkPB_.Start();
                            install_apk_title.Visible = true;
                            void killadb()
                            {
                                // Kill ADB 
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";
                                startInfo.Arguments = "/C  TaskKill /F /IM adb.exe";
                                startInfo.Verb = "runas";
                                process.StartInfo = startInfo;
                                process.Start();
                                process.Close();
                            }
                            void InstallTw()
                            {
                                ProcessStartInfo twi = new ProcessStartInfo("cmd.exe");
                                twi.Arguments = "/c adb.exe install ../pkgs/ES_FILE.apk";
                                twi.UseShellExecute = false;
                                twi.WindowStyle = ProcessWindowStyle.Hidden;
                                twi.WorkingDirectory = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb";
                                twi.RedirectStandardOutput = true;
                                twi.CreateNoWindow = true;
                                var proc = Process.Start(twi);
                                string twi_output = proc.StandardOutput.ReadToEnd();
                                if (twi_output.Contains("Success") == true)
                                {
                                    MessageBox.Show("APK File Has Been Successfully Installed . ");
                                    InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                    install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                    InstallApkPB_.Stop();
                                    killadb();
                                }
                                else
                                {
                                    MessageBox.Show("APK File Has Been Falid to Install . ");
                                    InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                    install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                    InstallApkPB_.Stop();
                                    killadb();
                                }
                                proc.Close();
                            }
                            Thread installtwthd = new Thread(InstallTw);
                            installtwthd.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please Open Emulator First !!");
                        }
                    }
                }
            }
            else if (install_APK_ui.Text == "Blue Screen")
            {
                if (File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/BlueScreenFix.apk"))
                {
                    Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
                    if (processesSMART.Length > 0)
                    {
                        InstallApkPB_.Visible = true;
                        InstallApkPB_.Start();
                        install_apk_title.Visible = true;
                        void killadb()
                        {
                            // Kill ADB 
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/C  TaskKill /F /IM adb.exe";
                            startInfo.Verb = "runas";
                            process.StartInfo = startInfo;
                            process.Start();
                            process.Close();
                        }
                        void InstallTw()
                        {
                            ProcessStartInfo twi = new ProcessStartInfo("cmd.exe");
                            twi.Arguments = "/c adb.exe install ../pkgs/BlueScreenFix.apk";
                            twi.UseShellExecute = false;
                            twi.WindowStyle = ProcessWindowStyle.Hidden;
                            twi.WorkingDirectory = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb";
                            twi.RedirectStandardOutput = true;
                            twi.CreateNoWindow = true;
                            var proc = Process.Start(twi);
                            string twi_output = proc.StandardOutput.ReadToEnd();
                            if (twi_output.Contains("Success") == true)
                            {
                                MessageBox.Show("APK File Has Been Successfully Installed . ");
                                InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                InstallApkPB_.Stop();
                                killadb();
                            }
                            else
                            {
                                MessageBox.Show("APK File Has Been Falid to Install . ");
                                InstallApkPB_.Invoke((MethodInvoker)(() => InstallApkPB_.Visible = false));
                                install_apk_title.Invoke((MethodInvoker)(() => install_apk_title.Visible = false));
                                InstallApkPB_.Stop();
                                killadb();
                            }
                            proc.Close();
                        }
                        Thread installtwthd = new Thread(InstallTw);
                        installtwthd.Start();
                    }
                    else
                    {
                        MessageBox.Show("Please Open Emulator First !!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Err : Please Select App From List !!");
            }
        }
        private void smartgagaD_Click(object sender, EventArgs e)
        {
            string pathpfs = @"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\";
            var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            if (pathpfs.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
                if (processesSMART.Length > 0)
                {
                    MessageBox.Show("Close SmartGaga .");
                }
                else
                {
                    File.Delete(@"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\lang\en_US.ini");
                    File.Delete(@"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\titan.pak");

                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780148381661659167/en_US.ini", @"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\lang\en_US.ini");
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780148451802742837/titan.pak", @"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\titan.pak");
                    MessageBox.Show("Done .");
                }
            }
            else
            {
                MessageBox.Show("Install SmartGaga First");
            }
        }
        // ================= Download File Functions =======================
        private String getFileSize(String url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "HEAD";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            long len = resp.ContentLength;

            return len.ToString();
        }
        private string GetFileName(string url)
        {
            string[] parts = url.Split('/');
            string fileName = "";

            if (parts.Length > 0)
                fileName = parts[parts.Length - 1];
            else
                fileName = url;
            return fileName;
        }
        private void wc_completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed!");
        }
        private void wc_DownloadProgress_Click(object sender, EventArgs e)
        {

        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            wc_DownloadProgress.Value = e.ProgressPercentage;
            txtpercent.Text = e.ProgressPercentage + "%";

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            //DownloadingStatus.Text = "Downloaded: " + bytesIn + "/" + totalBytes;
        }
        int getFileSizeM(string fileName)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/" + fileName).Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            string resultFileSize = String.Format("{0:0.##} {1}", (int)len, ""); // sizes[order]
            int len2 = (int)len;
            return len2;
        }
        // 2
        int getFileSizeM2(string fileName)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/" + fileName).Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            string resultFileSize = String.Format("{0:0.##} {1}", (int)len, ""); // sizes[order]
            int len2 = (int)len;
            return len2;
        }
        // Download File
        void DownloadFile(string url,string name,string title)
        {
            txtpercent.Visible = true;
            wc_DownloadProgress.Visible = true;
            DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Visible = true));
            DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Text = "Downloading  "+ title + "..."));
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += wc_completed;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(new Uri(url), ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/"+ name);
            }
        }
        async Task DownloadFile_2(string url, string name, string title)
        {
            txtpercent.Visible = true;
            wc_DownloadProgress.Visible = true;
            DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Visible = true));
            DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Text = "Downloading  " + title + "..."));
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += wc_completed;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
               await  wc.DownloadFileTaskAsync(new Uri(url), ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/" + name);
            }
        }
        private void gameloopD_Click(object sender, EventArgs e)
        {
            Process.Start("https://mega.nz/file/c9hEBZST#W3Qla1RJ8ze-TnrhUBir3_IA1DHBmZzxB5i9SoHmJJY");
        }
        private void FPS60Fix_Click(object sender, EventArgs e)
        {
            Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
            if (processesSMART.Length > 0)
            {
                MessageBox.Show("Close SmartGaga First .");
            }
            else
            {
                File.Delete(@"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\ProjectTitan.exe");
                File.Copy(Path.Combine(ApplicationDataDirectory+"/Mr28-Super-Nova-Team/", "ProjectTitan.exe"), Path.Combine(@"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\", "ProjectTitan.exe"));
                MessageBox.Show("Done .");
            }
        }
        private void Disable_google_serv_Click(object sender, EventArgs e)
        {
            Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
            if (processesSMART.Length > 0)
            {
                void killadb()
                {
                    // Kill ADB 
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C  TaskKill /F /IM adb.exe";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.Close();
                }
                void DisableGoogleService()
                {
                    ProcessStartInfo twi = new ProcessStartInfo("cmd.exe");
                    twi.Arguments = "/c adb.exe shell \"pm disable com.google.android.play.games & pm disable com.google.android.gms & pm disable com.google.android.gsf & pm disable com.google.android.gsf.login & pm disable com.android.vending\"";
                    twi.UseShellExecute = false;
                    twi.WindowStyle = ProcessWindowStyle.Hidden;
                    twi.WorkingDirectory = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/adb";
                    twi.RedirectStandardOutput = true;
                    twi.CreateNoWindow = true;
                    var proc = Process.Start(twi);
                    string twi_output = proc.StandardOutput.ReadToEnd();
                    MessageBox.Show("Google Services Has Ben Disabled Successfully .");
                    killadb();
                    proc.Close();
                }
                Thread DisableGoogleServiceF = new Thread(DisableGoogleService);
                DisableGoogleServiceF.Start();
            }
            else
            {
                MessageBox.Show("Err !!");
            }
        }
        private void FixDirX_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            void DFixDXFILES()
            {
                string DxCkFP = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/";
                if (!File.Exists(DxCkFP + "libGLESv2.dll") || !File.Exists(DxCkFP + "libGLES_V2_translator_v3.dll") || !File.Exists(DxCkFP + "libGLESv1.dll") || !File.Exists(DxCkFP + "libGLESv1_CM.dll") || !File.Exists(DxCkFP + "libGLES_CM_translator_v3.dll") || !File.Exists(DxCkFP + "libGLES_V2_translator.dll") || !File.Exists(DxCkFP + "libGLESv3Detect.dll") || !File.Exists(DxCkFP + "libGLES_CM_translator.dll") || !File.Exists(DxCkFP + "libEGL.dll"))
                {
                    // Start 
                    DPanel_.Invoke((MethodInvoker)(() => DPanel_.Visible = true));
                    DTools_loading.Invoke((MethodInvoker)(() => DTools_loading.Visible = true));
                    Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Visible = true));
                    D_Title.Invoke((MethodInvoker)(() => D_Title.Visible = true));
                    DTools_loading.Start();

                    if (!File.Exists(DxCkFP + "libGLESv2.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLESv2"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107821910982716/libGLESv2.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLESv2.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLES_V2_translator_v3.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLES_V2_translator_v3"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107744807747624/libGLES_V2_translator_v3.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLES_V2_translator_v3.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLESv1.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLESv1"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107588867063838/libGLESv1.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLESv1.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLESv1_CM.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLESv1_CM"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107553455472710/libGLESv1_CM.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLESv1_CM.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLES_CM_translator_v3.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLES_CM_translator_v3"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107518709858344/libGLES_CM_translator_v3.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLES_CM_translator_v3.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLES_V2_translator.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLES_V2_translator"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107470328037376/libGLES_V2_translator.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLES_V2_translator.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLESv3Detect.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLESv3Detect"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107460303519785/libGLESv3Detect.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLESv3Detect.dll");
                    }
                    if (!File.Exists(DxCkFP + "libGLES_CM_translator.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libGLES_CM_translator"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107335346814986/libGLES_CM_translator.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libGLES_CM_translator.dll");
                    }
                    if (!File.Exists(DxCkFP + "libEGL.dll"))
                    {
                        Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Downloading libEGL"));
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/779739850483695626/780107333677219870/libEGL.dll", ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX/libEGL.dll");
                    }
                    Thread.Sleep(400);
                    Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Text = "Done ..."));
                    // Stop 
                    Thread.Sleep(1600);
                    DPanel_.Invoke((MethodInvoker)(() => DPanel_.Visible = false));
                    DTools_loading.Invoke((MethodInvoker)(() => DTools_loading.Visible = false));
                    Downloading_names.Invoke((MethodInvoker)(() => Downloading_names.Visible = false));
                    D_Title.Invoke((MethodInvoker)(() => D_Title.Visible = false));
                    DTools_loading.Stop();
                }
                else if(File.Exists(DxCkFP + "libGLESv2.dll") & File.Exists(DxCkFP + "libGLES_V2_translator_v3.dll") & File.Exists(DxCkFP + "libGLESv1.dll") & File.Exists(DxCkFP + "libGLESv1_CM.dll") & File.Exists(DxCkFP + "libGLES_CM_translator_v3.dll") & File.Exists(DxCkFP + "libGLES_V2_translator.dll") & File.Exists(DxCkFP + "libGLESv3Detect.dll") & File.Exists(DxCkFP + "libGLES_CM_translator.dll") & File.Exists(DxCkFP + "libEGL.dll"))
                {
                    try
                    {
                        //System.IO.DirectoryInfo deOldF = new DirectoryInfo(@"%programfiles(x86)%\SmartGaGa\ProjectTitan\Engine\renderer_dx");
                        //foreach (FileInfo file in deOldF.GetFiles())
                        //{
                        //    file.Delete();
                        //}
                        //foreach (DirectoryInfo dir in deOldF.GetDirectories())
                        //{
                        //    dir.Delete(true);
                        //}
                        string sourcePath = ApplicationDataDirectory + "/Mr28-Super-Nova-Team/FixDirX";
                        string targetPath = @"C:\Program Files (x86)\SmartGaGa\ProjectTitan\Engine\renderer_dx";
                        foreach (var srcPath in Directory.GetFiles(sourcePath))
                        {
                            File.Copy(srcPath, srcPath.Replace(sourcePath, targetPath), true);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Close SmartGaga First !");
                    }
                }
            }
            Thread StartAppJob = new Thread(DFixDXFILES);
            StartAppJob.Start();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://mega.nz/file/2Z8VUSqY#r-eGFO54cj4J15ne2_4oQw349x6v_7gtC2osPAjqqFA");
        }
        private void DownlaodSmartGaga_Click(object sender, EventArgs e)
        {
            Process.Start("https://tencentgameassistant.ar.uptodown.com/windows/download");
        }
        private void Guesr_reset_Click(object sender, EventArgs e)
        {
            Process[] processesSMART = Process.GetProcessesByName("ProjectTitan");
            if (processesSMART.Length > 0)
            {
                MessageBox.Show("Close SmartGaga !");
            }
            else
            {
                Process.Start("start " + ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/kr.bat");
                Process.Start("start " + ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/gl.bat");
            }
        }
        async void DownGoogleServ_Click(object sender, EventArgs e)
        {
            if (!File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/Google_Play_Store.apk") || !File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/Google_Play_Games.apk") || !File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/Google_Play_Services.apk"))
            {
                txtpercent.Visible = true;
                wc_DownloadProgress.Visible = true;
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Visible = true));
                DownloadingStatus.Invoke((MethodInvoker)(() => DownloadingStatus.Text = "Downloading Google Services Apks 93 MB ..."));
                await DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758260633436170/Google_Play_Store.apk", "Google_Play_Store.apk", " Google Play Store 21 MB ");
                await DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758263179247636/Google_Play_Games.apk", "Google_Play_Games.apk", " Google Play Games 20 MB ");
                await DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758299771273246/Google_Play_Services.apk", "Google_Play_Services.apk", " Google Play Service 51 MB ");

            }
            else if (File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Google_Play_Store.apk") || File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/pkgs/Google_Play_Games.apk") || File.Exists(ApplicationDataDirectory + "/Mr28-Super-Nova-Team/GoogleServices/Google_Play_Services.apk"))
            {
                string GoogleStoreSize = getFileSizeM2("Google_Play_Store.apk").ToString();
                string GoogleGamesSize = getFileSizeM2("Google_Play_Games.apk").ToString();
                string GoogleServicesSize = getFileSizeM2("Google_Play_Services.apk").ToString();
                if (GoogleStoreSize != "21" || GoogleGamesSize != "20" || GoogleServicesSize != "51")
                {
                    if (GoogleStoreSize != "21")
                    {
                        DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758260633436170/Google_Play_Store.apk", "Google_Play_Store.apk", " Google Play Store 21 MB ");
                    }
                    if (GoogleGamesSize != "20")
                    {
                        DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758263179247636/Google_Play_Games.apk", "Google_Play_Games.apk", " Google Play Games 20 MB ");
                    }
                    if (GoogleServicesSize != "51")
                    {
                        DownloadFile_2("https://cdn.discordapp.com/attachments/779739850483695626/780758299771273246/Google_Play_Services.apk", "Google_Play_Services.apk", " Google Play Service 51 MB ");
                    }
                }
                else if (GoogleStoreSize == "21" || GoogleGamesSize == "20" || GoogleServicesSize == "51")
                {
                    var GoogleServicesPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mr28-Super-Nova-Team\GoogleServices";
                    //MessageBox.Show(GoogleServicesPath);
                    Process.Start("explorer.exe ", GoogleServicesPath);
                }
            }
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
