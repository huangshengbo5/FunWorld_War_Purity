//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-31 16:46:23.622
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
    public class DRCamp : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取注释,阵营id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_1
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_2
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_3
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_4
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_5
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_6
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_7
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_8
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_9
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_10
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_11
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_12
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_13
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_14
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取。
        /// </summary>
        public int CampID_15
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
            CampID_1 = int.Parse(columnStrings[index++]);
            CampID_2 = int.Parse(columnStrings[index++]);
            CampID_3 = int.Parse(columnStrings[index++]);
            CampID_4 = int.Parse(columnStrings[index++]);
            CampID_5 = int.Parse(columnStrings[index++]);
            CampID_6 = int.Parse(columnStrings[index++]);
            CampID_7 = int.Parse(columnStrings[index++]);
            CampID_8 = int.Parse(columnStrings[index++]);
            CampID_9 = int.Parse(columnStrings[index++]);
            CampID_10 = int.Parse(columnStrings[index++]);
            CampID_11 = int.Parse(columnStrings[index++]);
            CampID_12 = int.Parse(columnStrings[index++]);
            CampID_13 = int.Parse(columnStrings[index++]);
            CampID_14 = int.Parse(columnStrings[index++]);
            CampID_15 = int.Parse(columnStrings[index++]);

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
                    CampID_1 = binaryReader.Read7BitEncodedInt32();
                    CampID_2 = binaryReader.Read7BitEncodedInt32();
                    CampID_3 = binaryReader.Read7BitEncodedInt32();
                    CampID_4 = binaryReader.Read7BitEncodedInt32();
                    CampID_5 = binaryReader.Read7BitEncodedInt32();
                    CampID_6 = binaryReader.Read7BitEncodedInt32();
                    CampID_7 = binaryReader.Read7BitEncodedInt32();
                    CampID_8 = binaryReader.Read7BitEncodedInt32();
                    CampID_9 = binaryReader.Read7BitEncodedInt32();
                    CampID_10 = binaryReader.Read7BitEncodedInt32();
                    CampID_11 = binaryReader.Read7BitEncodedInt32();
                    CampID_12 = binaryReader.Read7BitEncodedInt32();
                    CampID_13 = binaryReader.Read7BitEncodedInt32();
                    CampID_14 = binaryReader.Read7BitEncodedInt32();
                    CampID_15 = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private KeyValuePair<int, int>[] m_CampID_ = null;

        public int CampID_Count
        {
            get
            {
                return m_CampID_.Length;
            }
        }

        public int GetCampID_(int id)
        {
            foreach (KeyValuePair<int, int> i in m_CampID_)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("GetCampID_ with invalid id '{0}'.", id));
        }

        public int GetCampID_At(int index)
        {
            if (index < 0 || index >= m_CampID_.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetCampID_At with invalid index '{0}'.", index));
            }

            return m_CampID_[index].Value;
        }

        private void GeneratePropertyArray()
        {
            m_CampID_ = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(1, CampID_1),
                new KeyValuePair<int, int>(2, CampID_2),
                new KeyValuePair<int, int>(3, CampID_3),
                new KeyValuePair<int, int>(4, CampID_4),
                new KeyValuePair<int, int>(5, CampID_5),
                new KeyValuePair<int, int>(6, CampID_6),
                new KeyValuePair<int, int>(7, CampID_7),
                new KeyValuePair<int, int>(8, CampID_8),
                new KeyValuePair<int, int>(9, CampID_9),
                new KeyValuePair<int, int>(10, CampID_10),
                new KeyValuePair<int, int>(11, CampID_11),
                new KeyValuePair<int, int>(12, CampID_12),
                new KeyValuePair<int, int>(13, CampID_13),
                new KeyValuePair<int, int>(14, CampID_14),
                new KeyValuePair<int, int>(15, CampID_15),
            };
        }
    }
//}