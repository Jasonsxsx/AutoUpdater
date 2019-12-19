﻿#region Header and Copyright

// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (C) Felipe Vieira Vendramini - All rights reserved
// The copy or distribution of this file or software without the original lines of this header is extrictly
// forbidden. This code is public and free as is, and if you alter anything you can insert your name
// in the fields below.
// 
// AutoUpdater - AutoUpdaterCore - MsgDownloadInfo.cs
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

using System.Collections.Generic;

namespace AutoUpdaterCore.Sockets.Packets
{
    public class MsgDownloadInfo : PacketStructure
    {
        private StringPacker m_packer = new StringPacker();

        public MsgDownloadInfo(byte[] buffer)
            : base(buffer)
        {
            m_packer = new StringPacker(buffer, 6);
        }

        public MsgDownloadInfo()
            : base(PacketType.MsgDownloadInfo, 10, 10)
        {
        }

        public UpdateDownloadType Mode
        {
            get => (UpdateDownloadType) ReadUShort(4);
            set => WriteUShort((ushort) value, 4);
        }

        public void Append(params string[] strs)
        {
            m_packer.Add(strs);
        }

        public List<string> GetStrings()
        {
            return m_packer.GetStrings();
        }

        protected override byte[] Build()
        {
            byte[] pStr = m_packer.ToArray();
            Resize(10 + pStr.Length);
            WriteHeader(Length, PacketType.MsgDownloadInfo);
            WriteArray(pStr, pStr.Length, 6);
            return base.Build();
        }
    }

    public enum UpdateDownloadType : ushort
    {
        UpdaterPatch,
        GameClientPatch
    }
}