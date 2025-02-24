//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-12-31 16:46:23.724
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
    public class DRNPC : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取//注释,npcid。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取npc名字。
        /// </summary>
        public int nameid
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取头像。
        /// </summary>
        public string icon
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取类型1=玩家士兵，2=怪物士兵。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取品质1=绿，2=蓝，3=紫，4=橙。
        /// </summary>
        public int quality
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取阵营1=默认，2=玩家，3=怪。
        /// </summary>
        public int camp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取性别1=男，2=女。
        /// </summary>
        public int sex
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
        /// 获取职业类型，1=近战，2=远程，3=骑兵，4=机械，5=辅助。
        /// </summary>
        public int vocation
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵模型。
        /// </summary>
        public int model
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵的费值（也代表士兵的战力和兵力）。
        /// </summary>
        public int fee
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵基础属性属性id，值，属性id，值。
        /// </summary>
        public string avalue_base
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵高级基础属性属性id，值，属性id，值。
        /// </summary>
        public string avalue_senior
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
        /// 获取追击距离。
        /// </summary>
        public int Pursuit_distance
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
        /// 获取被动技能。
        /// </summary>
        public double skill_passive
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

        /// <summary>
        /// 获取下一级士兵。
        /// </summary>
        public int next
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取士兵升级消耗金币。
        /// </summary>
        public int upgrade_gold
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取升级消耗道具。
        /// </summary>
        public string upgrade_item
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
            quality = int.Parse(columnStrings[index++]);
            camp = int.Parse(columnStrings[index++]);
            sex = int.Parse(columnStrings[index++]);
            level = int.Parse(columnStrings[index++]);
            vocation = int.Parse(columnStrings[index++]);
            model = int.Parse(columnStrings[index++]);
            fee = int.Parse(columnStrings[index++]);
            avalue_base = columnStrings[index++];
            avalue_senior = columnStrings[index++];
            Attack_range = int.Parse(columnStrings[index++]);
            Pursuit_distance = int.Parse(columnStrings[index++]);
            skill = double.Parse(columnStrings[index++]);
            skill_passive = double.Parse(columnStrings[index++]);
            build_time = int.Parse(columnStrings[index++]);
            next = int.Parse(columnStrings[index++]);
            upgrade_gold = int.Parse(columnStrings[index++]);
            upgrade_item = columnStrings[index++];

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
                    quality = binaryReader.Read7BitEncodedInt32();
                    camp = binaryReader.Read7BitEncodedInt32();
                    sex = binaryReader.Read7BitEncodedInt32();
                    level = binaryReader.Read7BitEncodedInt32();
                    vocation = binaryReader.Read7BitEncodedInt32();
                    model = binaryReader.Read7BitEncodedInt32();
                    fee = binaryReader.Read7BitEncodedInt32();
                    avalue_base = binaryReader.ReadString();
                    avalue_senior = binaryReader.ReadString();
                    Attack_range = binaryReader.Read7BitEncodedInt32();
                    Pursuit_distance = binaryReader.Read7BitEncodedInt32();
                    skill = binaryReader.ReadDouble();
                    skill_passive = binaryReader.ReadDouble();
                    build_time = binaryReader.Read7BitEncodedInt32();
                    next = binaryReader.Read7BitEncodedInt32();
                    upgrade_gold = binaryReader.Read7BitEncodedInt32();
                    upgrade_item = binaryReader.ReadString();
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