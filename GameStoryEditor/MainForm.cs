using GameCore.Database;
using GameLogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStoryEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 玩家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Player_Click(object sender, EventArgs e)
        {
            try
            {
                PlayerEditor pe = new PlayerEditor();
                pe.ShowDialog();
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// NPC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_NPC_Click(object sender, EventArgs e)
        {
            try
            {
                NPCEditor ne = new NPCEditor();
                ne.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 对话树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Story_Click(object sender, EventArgs e)
        {
            try
            {
                StoryTreeEditor ste = new StoryTreeEditor();
                ste.ShowDialog();
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if( DatabaseManager.Instance.CreateTables())
            {
                MessageBox.Show("创建成功");
            }
            else
            {
                MessageBox.Show("创建失败");
            }
        }
    }
}
