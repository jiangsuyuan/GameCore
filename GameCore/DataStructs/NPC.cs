using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DataStructs
{
    /// <summary>
    /// NPC
    /// </summary>
    public class NPC
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID;
        /// <summary>
        /// NPC姓名
        /// </summary>
        public string NPCName;
        /// <summary>
        /// NPC性别
        /// </summary>
        public string NPCSex;
        /// <summary>
        /// 好感度（对主角）
        /// </summary>
        public int Favorable;
        /// <summary>
        /// 好感类型
        /// </summary>
        public int FeelingType;
        /// <summary>
        /// 描述
        /// </summary>
        public string description;

    }
}
