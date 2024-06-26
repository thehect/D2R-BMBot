﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public class KeyMouse
    {
        Form1 Form1_0;

        public int ProcessingDelay = 1;

        private const int WH_KEYBOARD_LL = 13;
        public LowLevelKeyboardProc proc;
        public IntPtr hookID = IntPtr.Zero;

        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;

        public const int WM_SYSKEYDOWN = 260;
        public const int WM_SYSKEYUP = 261;
        public const int WM_CHAR = 258;
        public const int WM_KEYDOWN = 256;
        public const int WM_KEYUP = 257;

        //###############################################
        //###############################################

        [DllImport("User32.dll")]
        static extern Int32 SendMessage(int hWnd, int Msg, int wParam, IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(int hWnd, int Msg, int wParam, IntPtr lParam);

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        //###############################################
        //###############################################

        public void SetForm1(Form1 form1_1)
        {
            Form1_0 = form1_1;
        }

        private static IntPtr CreateLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }

        public void MouseClicc_RealPos(int ThX, int ThY)
        {
            //Thread.Sleep(ProcessingDelay);

            MouseMoveTo_RealPos(ThX, ThY);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            Thread.Sleep(1);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            Thread.Sleep(ProcessingDelay);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }
        public void MouseCliccRight_RealPos(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
            Thread.Sleep(1);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            Thread.Sleep(ProcessingDelay);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }

        public void MouseClicc(int ThX, int ThY)
        {
            //Thread.Sleep(ProcessingDelay);

            MouseMoveTo(ThX, ThY);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            Thread.Sleep(1);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            Thread.Sleep(ProcessingDelay);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }

        public void MouseCliccRight(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
            Thread.Sleep(1);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            Thread.Sleep(ProcessingDelay);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }

        /*public void MouseCliccAttackMove(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }*/

        public void MouseCliccRightAttackMove(int ThX, int ThY)
        {
            MouseMoveTo_RealPos(ThX, ThY);
            //PostMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
            PostMessage((int)Form1_0.hWnd, WM_RBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            //PostMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }

        public void PressKey(System.Windows.Forms.Keys ThisK)
        {
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
        }

        public void PressKey2(System.Windows.Forms.Keys ThisK)
        {
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            Thread.Sleep(1);
            //PostMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
        }

        public void PressKey3(System.Windows.Forms.Keys ThisK)
        {
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
        }

        public void PressKeyHold(System.Windows.Forms.Keys ThisK)
        {
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
        }

        public void ReleaseKey(System.Windows.Forms.Keys ThisK)
        {
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
        }

        public void SendCTRL_CLICK(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);
            byte KEYEVENTF_KEYUP = 0x02;
            byte VK_CONTROL = 0x11;

            //press CTRL
            keybd_event(VK_CONTROL, 0, 0, 0);
            //PressKeyHold(Keys.LControlKey);
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)Keys.LControlKey, (IntPtr)0);

            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);

            //release CTRL
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            //ReleaseKey(Keys.LControlKey);
            SendMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)Keys.LControlKey, (IntPtr)0);
        }

        public void SendSHIFT_RIGHTCLICK(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);

            PressKeyHold(Keys.LShiftKey);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONDOWN, 0x00000001, (IntPtr)0);
            SendMessage((int)Form1_0.hWnd, WM_RBUTTONUP, 0x00000000, (IntPtr)0);
            ReleaseKey(Keys.LShiftKey);
        }

        public void SendSHIFT_CLICK(int ThX, int ThY)
        {
            MouseMoveTo(ThX, ThY);

            //ReleaseKey(Keys.LShiftKey);
            PressKeyHold(Keys.LShiftKey);
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            ReleaseKey(Keys.LShiftKey);
        }

        public void SendSHIFT_CLICK_ATTACK(int ThX, int ThY)
        {
            MouseMoveTo_RealPos(ThX, ThY);

            //ReleaseKey(Keys.LShiftKey);
            PressKeyHold(Keys.LShiftKey);
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            //SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            //SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            ReleaseKey(Keys.LShiftKey);
        }

        public void SendSHIFT_CLICK_ATTACK_CAST_NO_MOVE(int ThX, int ThY)
        {
            MouseMoveTo_RealPos(ThX, ThY);

            //ReleaseKey(Keys.LShiftKey);
            PressKeyHold(Keys.LShiftKey);
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            //PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            //SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, (IntPtr)0);
            //SendMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, (IntPtr)0);
            //SendMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            ReleaseKey(Keys.LShiftKey);
        }

        public void PressPotionKey(System.Windows.Forms.Keys ThisK)
        {
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
        }

        public void PressPotionKeyMerc(System.Windows.Forms.Keys ThisK)
        {
            PressKeyHold(Keys.LShiftKey);
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYDOWN, (ushort)ThisK, (IntPtr)0);
            PostMessage((int)Form1_0.hWnd, WM_SYSKEYUP, (ushort)ThisK, (IntPtr)0);
            ReleaseKey(Keys.LShiftKey);
        }

        public void MouseMoveTo(int ThX, int ThY)
        {
            ThX = CorrectXPos(ThX);   //here
            ThY = CorrectYPos(ThY);   //here
            Point position = new Point(ThX, ThY);
            SetCursorPos(position.X, position.Y);
        }


        public void MouseMoveTo_RealPos(int ThX, int ThY)
        {
            Point position = new Point(ThX, ThY);
            SetCursorPos(position.X, position.Y);
        }

        public void MouseClicHoldWithoutRelease()
        {
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
        }

        public void MouseClicHold()
        {
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONDOWN, 0x00000001, CreateLParam(150, 150));
        }

        public void MouseClicRelease()
        {
            PostMessage((int)Form1_0.hWnd, WM_LBUTTONUP, 0x00000000, CreateLParam(150, 150));
        }

        public int CorrectXPos(int ThisPoss)
        {
            double Percent = ((double) ThisPoss * 100.0) / (double) Form1_0.ScreenX;
            int PosInGame = (int) ((Percent * (double) Form1_0.D2Widht) / 100.0);
            return Form1_0.ScreenXOffset + PosInGame;
        }

        public int CorrectYPos(int ThisPoss)
        {
            double Percent = ((double) ThisPoss * 100.0) / (double) Form1_0.ScreenY;
            int PosInGame = (int) ((Percent * (double) Form1_0.D2Height) / 100.0);
            return Form1_0.ScreenYOffset + PosInGame;
        }


        //######################################
        //keyborad hook for start/stop buttons
        public IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == (int) CharConfig.StartStopKey) //numpad5
                {
                    Form1_0.button1_Click(null, null);
                }
                else if (vkCode == (int)CharConfig.PauseResumeKey) //numpad6
                {
                    Form1_0.buttonPauseResume_Click(null, null);
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }





        /*public enum INPUT_TYPE : uint
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public KEYEVENTF dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }


        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]

        struct INPUT
        {
            [FieldOffset(0)] public INPUT_TYPE type;
            [FieldOffset(4)] public MOUSEINPUT mi;
            [FieldOffset(4)] public KEYBDINPUT ki;
            [FieldOffset(4)] public HARDWAREINPUT hi;
        }

        public enum KEYEVENTF : uint
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008
        }*/
    }
}
