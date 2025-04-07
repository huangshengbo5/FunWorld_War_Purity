//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2025-04-07 17:17:31.928
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
    /// 。
    /// </summary>
    public class DRDiamond : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取宝石id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取增加固定属性数值。格式为：属性Id|数值;属性Id|数值……（实际使用会除以@item_attritube%param_rate）。
        /// </summary>
        public string Attribute_fix
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取减少固定属性数值。格式为：属性Id|数值;属性Id|数值……（实际使用会除以@item_attritube%param_rate）。
        /// </summary>
        public string Attribute_fixminus
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取增加百分比属性数值。格式为：属性Id|数值;属性Id|数值……（1固定表示10000分之一）。
        /// </summary>
        public string Attribute_percent
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取减少百分比属性数值。格式为：属性Id|数值;属性Id|数值……（1固定表示10000分之一）。
        /// </summary>
        public string Attribute_percentminus
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取增加技能id,skilllevelID。
        /// </summary>
        public int Add_kill
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
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            Attribute_fix = columnStrings[index++];
            Attribute_fixminus = columnStrings[index++];
            Attribute_percent = columnStrings[index++];
            Attribute_percentminus = columnStrings[index++];
            Add_kill = int.Parse(columnStrings[index++]);

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
                    Attribute_fix = binaryReader.ReadString();
                    Attribute_fixminus = binaryReader.ReadString();
                    Attribute_percent = binaryReader.ReadString();
                    Attribute_percentminus = binaryReader.ReadString();
                    Add_kill = binaryReader.Read7BitEncodedInt32();
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