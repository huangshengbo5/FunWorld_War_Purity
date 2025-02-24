//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-23 19:53:16.108
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

//namespace __DATA_TABLE_NAME_SPACE__
//{
    /// <summary>
    /// 属性表。
    /// </summary>
    public class DRAvalue : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取属性id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取属性名字注释 属性类型1=固定值2=万分比。
        /// </summary>
        public string ValueName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取属性图标图标名字或路径。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int ShowNameID
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int Icon
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            ValueName = columnStrings[index++];
            index++;
            Type = int.Parse(columnStrings[index++]);
            ShowNameID = int.Parse(columnStrings[index++]);
            Icon = int.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    ValueName = binaryReader.ReadString();
                    Type = binaryReader.Read7BitEncodedInt32();
                    ShowNameID = binaryReader.Read7BitEncodedInt32();
                    Icon = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
//}