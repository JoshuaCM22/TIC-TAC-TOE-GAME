﻿using System;
using System.Runtime.InteropServices;

namespace TIC_TAC_TOE_GAME
{
    class Program
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
            int origWidth, width;
            int origHeight, height;
            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;
            width = 80;
            height = 35;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
            Title.DrawInterface();
        }
    }
}