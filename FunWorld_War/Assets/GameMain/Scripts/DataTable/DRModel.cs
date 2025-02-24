//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-31 16:47:50.462
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
    public class DRModel : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取模型资源。
        /// </summary>
        public string model
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取待机动作。
        /// </summary>
        public string Stand
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取奔跑动作。
        /// </summary>
        public string Running
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取死亡动作。
        /// </summary>
        public string Death
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取缩放。
        /// </summary>
        public string zoom
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
            model = columnStrings[index++];
            Stand = columnStrings[index++];
            Running = columnStrings[index++];
            Death = columnStrings[index++];
            zoom = columnStrings[index++];

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
                    model = binaryReader.ReadString();
                    Stand = binaryReader.ReadString();
                    Running = binaryReader.ReadString();
                    Death = binaryReader.ReadString();
                    zoom = binaryReader.ReadString();
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