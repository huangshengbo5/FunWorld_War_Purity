//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-31 16:47:50.464
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
    public class DRFortress : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取//注释,城的id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取关隘名字。
        /// </summary>
        public int nameid
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取图标。
        /// </summary>
        public string icon
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取城的类型。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取阵营1=玩家，2=敌人1，3=敌人2。
        /// </summary>
        public int camp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取等级。
        /// </summary>
        public int level
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取城模型。
        /// </summary>
        public int model
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取基础属性(属性id，值)，(属性id，值)。
        /// </summary>
        public string avalue_base
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击距离。
        /// </summary>
        public int Attack_range
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取主动技能。
        /// </summary>
        public double skill
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取兵力上限。
        /// </summary>
        public int fee
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵建造时间单位秒。
        /// </summary>
        public int build_time
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
            nameid = int.Parse(columnStrings[index++]);
            icon = columnStrings[index++];
            Type = int.Parse(columnStrings[index++]);
            camp = int.Parse(columnStrings[index++]);
            level = int.Parse(columnStrings[index++]);
            model = int.Parse(columnStrings[index++]);
            avalue_base = columnStrings[index++];
            Attack_range = int.Parse(columnStrings[index++]);
            skill = double.Parse(columnStrings[index++]);
            fee = int.Parse(columnStrings[index++]);
            build_time = int.Parse(columnStrings[index++]);

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
                    nameid = binaryReader.Read7BitEncodedInt32();
                    icon = binaryReader.ReadString();
                    Type = binaryReader.Read7BitEncodedInt32();
                    camp = binaryReader.Read7BitEncodedInt32();
                    level = binaryReader.Read7BitEncodedInt32();
                    model = binaryReader.Read7BitEncodedInt32();
                    avalue_base = binaryReader.ReadString();
                    Attack_range = binaryReader.Read7BitEncodedInt32();
                    skill = binaryReader.ReadDouble();
                    fee = binaryReader.Read7BitEncodedInt32();
                    build_time = binaryReader.Read7BitEncodedInt32();
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