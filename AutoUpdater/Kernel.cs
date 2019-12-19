﻿#region Header and Copyright

// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (C) Felipe Vieira Vendramini - All rights reserved
// The copy or distribution of this file or software without the original lines of this header is extrictly
// forbidden. This code is public and free as is, and if you alter anything you can insert your name
// in the fields below.
// 
// AutoUpdater - AutoUpdater - Kernel.cs
// 
// Description: <Write a description for this file>
// 
// Colaborators who worked in this file:
// Felipe Vieira Vendramini
// 
// Developed by:
// Felipe Vieira Vendramini <service@ftwmasters.com.br>
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Reflection;
using AutoUpdaterCore;

namespace AutoUpdater
{
    public static class Kernel
    {
        public static ushort ActualVersion = 1000;
        public static string Version;

        static Kernel()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Log = new LogWriter(Environment.CurrentDirectory);
        }

        public static LogWriter Log;
    }
}