//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2025-04-07 17:17:31.875
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
    /// ValueName。
    /// </summary>
    public class DRAttribute : DataRowBase
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
        /// 获取属性类型，1：普通，2：百分比。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取参数1，表示在使用时该属性的实际数值会除以一个系数。。
        /// </summary>
        public int Param_rate
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取保留小数点精度，0=整数，1=一位小数，2=两位小数。
        /// </summary>
        public int Digit_decimal
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取经过参数1换算过后的数值范围的最小值（仅针对角色整体属性，单个装备不限制）。
        /// </summary>
        public int Range_min
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取经过参数1换算过后的数值范围的最大值（仅针对角色整体属性，单个装备不限制）。
        /// </summary>
        public int Range_max
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
            m_Id = int.Parse(columnStrings[index++]);
            ValueName = columnStrings[index++];
            index++;
            Type = int.Parse(columnStrings[index++]);
            Param_rate = int.Parse(columnStrings[index++]);
            Digit_decimal = int.Parse(columnStrings[index++]);
            Range_min = int.Parse(columnStrings[index++]);
            Range_max = int.Parse(columnStrings[index++]);
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
                    Param_rate = binaryReader.Read7BitEncodedInt32();
                    Digit_decimal = binaryReader.Read7BitEncodedInt32();
                    Range_min = binaryReader.Read7BitEncodedInt32();
                    Range_max = binaryReader.Read7BitEncodedInt32();
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