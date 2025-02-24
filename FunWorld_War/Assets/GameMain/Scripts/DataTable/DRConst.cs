//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-31 16:46:23.708
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
    public class DRConst : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取注释。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取名字。
        /// </summary>
        public string Chinese
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取整数参数。
        /// </summary>
        public string parameter1
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
            Chinese = columnStrings[index++];
            parameter1 = columnStrings[index++];

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
                    Chinese = binaryReader.ReadString();
                    parameter1 = binaryReader.ReadString();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private KeyValuePair<int, string>[] m_parameter = null;

        public int parameterCount
        {
            get
            {
                return m_parameter.Length;
            }
        }

        public string Getparameter(int id)
        {
            foreach (KeyValuePair<int, string> i in m_parameter)
            {
                if (i.Key == id)
                {
                    return i.Value;
                }
            }

            throw new GameFrameworkException(Utility.Text.Format("Getparameter with invalid id '{0}'.", id));
        }

        public string GetparameterAt(int index)
        {
            if (index < 0 || index >= m_parameter.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetparameterAt with invalid index '{0}'.", index));
            }

            return m_parameter[index].Value;
        }

        private void GeneratePropertyArray()
        {
            m_parameter = new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int, string>(1, parameter1),
            };
        }
    }
//}