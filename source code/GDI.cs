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
    public class GDI
    {
        public static void Payload1()
        {
            Random rand = new Random();
            while (true)
            {
                int w = rand.Next(GetSystemMetrics(0));
                int h = rand.Next(GetSystemMetrics((SystemMetric)1));
                int w2 = rand.Next(GetSystemMetrics(0));
                int h2 = rand.Next(GetSystemMetrics((SystemMetric)1));
                int w3 = rand.Next(GetSystemMetrics(0));
                int h3 = rand.Next(GetSystemMetrics((SystemMetric)1));
                var dc = GetWindowDC(GetDesktopWindow());
                DrawIcon(dc, w, h, LoadIcon(HINSTANCE.NULL, IDI_ERROR));
                DrawIcon(dc, w2, h2, LoadIcon(HINSTANCE.NULL, IDI_WARNING));
                DrawIcon(dc, w3, h3, LoadIcon(HINSTANCE.NULL, IDI_INFORMATION));
                DeleteDC(dc);
                Sleep(100);
            }
        }
        public static void GDI1()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            Random rand;
            while (true)
            {
                rand = new Random();
                var dc = GetDC(HWND.NULL);
                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                SelectObject(dc, brush);
                PatBlt(dc, 0, 0, w, h, PATINVERT);
                DeleteObject(brush);
                DeleteDC(dc);
            }
        }
        public static void MouseIcon()
        {
            HICON hICON = LoadIcon(HINSTANCE.NULL, IDI_EXCLAMATION);
            while (true)
            {
                Point point;
                GetCursorPos(out point);
                HDC hdc = GetDC(HWND.NULL);
                DrawIcon(hdc, point.X, point.Y,hICON);
                DeleteDC(hdc);
                ReleaseDC(HWND.NULL, hdc);

            }

        }
        public static void GDI4()
        {
            int w = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int h = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            Point[] point = new Point[3];
            while (true)
            {
                RECT rc = new RECT(0, 0, w, h);
                var dc = GetDC(HWND.NULL);
                var hdc = CreateCompatibleDC(dc);
                var hbit = CreateCompatibleBitmap(dc, w, h);
                var holdbit = SelectObject(hdc, hbit);
                point[0].X = (rc.left + 40) + 0;
                point[0].Y = (rc.top - 40) + 0;

                point[1].X = (rc.right + 40) + 0;
                point[1].Y = (rc.top + 40) + 0;

                point[2].X = (rc.left - 40) + 0;
                point[2].Y = (rc.bottom - 40) + 0;

                PlgBlt(dc, point, dc, rc.left - 20, rc.top - 20, (rc.right - rc.left) + 40, (rc.bottom + rc.top) + 40, HBITMAP.NULL, 0, 0);

                DeleteDC(dc);

            }
        }
        public static void LimparEfeitos()
        {
            RedrawWindow(HWND.NULL, null, HRGN.NULL,
                RedrawWindowFlags.RDW_INVALIDATE |
                RedrawWindowFlags.RDW_ERASE |
                RedrawWindowFlags.RDW_ALLCHILDREN);
        }
        public static void GDI3()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            var rand = new Random();
            while (true)
            {
                var dc = GetDC(HWND.NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbit = CreateCompatibleBitmap(dc, w, h);
                var oldbit = SelectObject(dcC, hbit);
                BitBlt(dcC,0,0,w,h,dc,0,0,SRCCOPY);

                AlphaBlend(dc,rand.Next(-4,4), rand.Next(-4, 4),w,h,dcC,0,0,w,h,new BLENDFUNCTION(50));
                SelectObject(dcC, oldbit);
                DeleteObject(oldbit);
                DeleteObject(hbit);
                ReleaseDC(HWND.NULL, dcC);
                ReleaseDC(HWND.NULL, dc);
            }
        }
        public static void GDI5()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            var rand = new Random();
            while (true)
            {
                var dc = GetDC(IntPtr.Zero);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCPAINT);
                int offsetX = rand.Next(1000);
                int offsetY = rand.Next(1000);
                BitBlt(dc, offsetX, offsetY, w, h, dcC, 0, 0, SRCINVERT);
                SelectObject(dcC, oldbitmap);
                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);
                Sleep(100);

            }
        }
        public static void GDI2()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            while (true)
            {
                var dc = GetWindowDC(GetDesktopWindow());
                StretchBlt(dc, 0, h, w, -h, dc, 0, 0, w, h, SRCCOPY);
                DeleteDC(dc);
            }
        }
    }
}
