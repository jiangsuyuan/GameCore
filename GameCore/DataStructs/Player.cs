using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DataStructs
{
    /// <summary>
    /// 主角
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 唯一标识符
        /// </summary>
        public string GUID;
        /// <summary>
        /// 玩家名称
        /// </summary>
        public string PlayerName;
        /// <summary>
        /// 玩家性别
        /// </summary>
        public bool PlayerSex;

        /// <summary>
        /// 初始化
        /// </summary>
        public Player()
        {

        }
    }
}
