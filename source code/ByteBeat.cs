using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.WinMm;

namespace Helios
{
    public class ByteBeat
    {
        static SafeHWAVEOUT hWaveOut;
        public static void ByteBeat1()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX();
                const int HZ = 8000;
                wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
                wfx.nSamplesPerSec = HZ;
                wfx.nAvgBytesPerSec = HZ;
                wfx.wBitsPerSample = 8;
                wfx.nBlockAlign = 1;
                wfx.nChannels = 1;
                wfx.cbSize = 0;
                const uint MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);

                byte[] sbuffer = new byte[16000 * 60];

                for (uint t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(t * 10 / 20 | t * t / 30);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR();
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                    waveOutClose(hWaveOut);
                    handle.Free();
                }
            }

        }
        public static void ByteBeat2()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX();
                const int HZ = 8000;
                wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
                wfx.nSamplesPerSec = HZ;
                wfx.nAvgBytesPerSec = HZ;
                wfx.wBitsPerSample = 8;
                wfx.nBlockAlign = 1;
                wfx.nChannels = 1;
                wfx.cbSize = 0;
                const uint MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);

                byte[] sbuffer = new byte[16000 * 60];

                for (uint t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(t * t / 20 | t | t / 2);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR();
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                    waveOutClose(hWaveOut);
                    handle.Free();
                }
            }
        }
        public static void ByteBeat4()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX();
                const int HZ = 44100;
                wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
                wfx.nSamplesPerSec = HZ;
                wfx.nAvgBytesPerSec = HZ;
                wfx.wBitsPerSample = 8;
                wfx.nBlockAlign = 1;
                wfx.nChannels = 1;
                wfx.cbSize = 0;
                const uint MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);

                byte[] sbuffer = new byte[16000 * 60];

                for (uint t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)((t ^ t >> 10) * t >> 16);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR();
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                    waveOutClose(hWaveOut);
                    handle.Free();
                }
            }
        }
        public static void ByteBeat3()
        {
            while (true)
            {
                WAVEFORMATEX wfx = new WAVEFORMATEX();
                const int HZ = 11025;
                wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
                wfx.nSamplesPerSec = HZ;
                wfx.nAvgBytesPerSec = HZ;
                wfx.wBitsPerSample = 8;
                wfx.nBlockAlign = 1;
                wfx.nChannels = 1;
                wfx.cbSize = 0;
                const uint MAPPER = 0xFFFFFFFF;
                waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);

                byte[] sbuffer = new byte[16000 * 60];

                for (uint t = 0; t < sbuffer.Length; t++)
                {
                    sbuffer[t] = (byte)(t * 1 / 5 | t * t / 500);
                }

                GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);

                WAVEHDR header = new WAVEHDR();
                header.lpData = handle.AddrOfPinnedObject();
                header.dwBufferLength = (uint)sbuffer.Length;
                header.dwFlags = 0;
                header.dwLoops = 0;

                waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
                waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadAbortException)
                {
                    waveOutReset(hWaveOut);
                    waveOutClose(hWaveOut);
                    handle.Free();
                }
            }
        }
    }
}
