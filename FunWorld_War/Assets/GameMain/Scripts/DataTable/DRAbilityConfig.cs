//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2025-03-18 15:52:53.871
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
    /// KeyName。
    /// </summary>
    public class DRAbilityConfig : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取Id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取KeyName。
        /// </summary>
        public string KeyName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取名字。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能描述。
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取能力类型 1：技能， 2：Buff。
        /// </summary>
        public int Type
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取目标阵营 1：敌方，2：己方，3：自身。
        /// </summary>
        public int TargetGroup
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取目标选择方式 1:无  2：手动指定，3：碰撞检测, 4: 条件指定。
        /// </summary>
        public int TargetSelect
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取冷却时间。
        /// </summary>
        public float Cooldown
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取Buff类型  1：None  2：虚弱，3 ：强化。
        /// </summary>
        public int BuffType
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
            KeyName = columnStrings[index++];
            Name = columnStrings[index++];
            Description = columnStrings[index++];
            Type = int.Parse(columnStrings[index++]);
            TargetGroup = int.Parse(columnStrings[index++]);
            TargetSelect = int.Parse(columnStrings[index++]);
            Cooldown = float.Parse(columnStrings[index++]);
            BuffType = int.Parse(columnStrings[index++]);

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
                    KeyName = binaryReader.ReadString();
                    Name = binaryReader.ReadString();
                    Description = binaryReader.ReadString();
                    Type = binaryReader.Read7BitEncodedInt32();
                    TargetGroup = binaryReader.Read7BitEncodedInt32();
                    TargetSelect = binaryReader.Read7BitEncodedInt32();
                    Cooldown = binaryReader.ReadSingle();
                    BuffType = binaryReader.Read7BitEncodedInt32();
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