using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DataStructs
{
    /// <summary>
    /// 对话（和主角的）
    /// </summary>
    public class Dialogue
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string ID;
        /// <summary>
        /// 时间上限
        /// </summary>
        public int beginTime;
        /// <summary>
        /// 时间下限
        /// </summary>
        public int endTime;
        /// <summary>
        /// 好感度上限
        /// </summary>
        public int beginFavorable;
        /// <summary>
        /// 好感度下限
        /// </summary>
        public int endFavorable;
        /// <summary>
        /// 好感度类型上限
        /// </summary>
        public int beginFavorableType;
        /// <summary>
        /// 好感度类型下限
        /// </summary>
        public int endFavorableType;
        /// <summary>
        /// 主角性别条件
        /// </summary>
        public int PlayerSex;
        /// <summary>
        /// 对话内容
        /// </summary>
        public DialogueTree dialogueTree;


        //TODO:触发物品条件。


    }

    /// <summary>
    /// 对话树
    /// </summary>
    public class DialogueTree
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string ID;
        /// <summary>
        /// 父对象
        /// </summary>
        public DialogueTree parent;
        /// <summary>
        /// 子对话
        /// </summary>
        public List<DialogueTree> childs;
        /// <summary>
        /// 对话所有者
        /// </summary>
        public bool isPlayer;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content;


        //TODO：效果、影响、奖励等
    }
}
