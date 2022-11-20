using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FlashLOL
{
    public partial class Form1 : Form
	{
		public Form1()
        {
            InitializeComponent();
        }

        private void B_Click(object sender, EventArgs e)
        {
			Process process = new Process();
			process.StartInfo.FileName = "netsh";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = "advfirewall firewall add rule name=FlashLOL dir=out action=block program=\"" + this.User.Text + "\" enable=yes profile=public,private,domain";
            process.Start();
            process.WaitForExit();
            System.Threading.Thread.Sleep(4000);
            process.StartInfo.Arguments = "advfirewall firewall del rule name=FlashLOL dir=out";
            process.Start();
            process.WaitForExit();
        }

        private void User_TextChanged(object sender, EventArgs e)
        {
			if(this.User.Text == "")
            {
				this.B.Enabled = false;
				this.B.Text = "请输入游戏位置";
            }
            else
            {
				this.B.Enabled = true;
				this.B.Text = "开刷！";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			this.User.Text = "";
        }
    }
}
