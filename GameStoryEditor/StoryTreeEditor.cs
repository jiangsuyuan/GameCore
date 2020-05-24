using GameCore.Database;
using GameCore.DataStructs;
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
    /// <summary>
    /// 对话树编辑
    /// </summary>
    public partial class StoryTreeEditor : Form
    {
        /// <summary>
        /// NPC列表
        /// </summary>
        private List<NPC> npcList = null;
        /// <summary>
        /// 拥有人ID
        /// </summary>
        private string npcID = "";
        /// <summary>
        /// 当前对话
        /// </summary>
        private string currentTopic = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public StoryTreeEditor()
        {
            InitializeComponent();

            InitializeTable();
            InitializeData();
        }
        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitializeTable()
        {
            dataGridView1.Click += DataGridView1_Click;

            DataGridViewColumn ageColumn0 = new DataGridViewColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                FillWeight = 200,
                CellTemplate = new DataGridViewTextBoxCell(),
                MinimumWidth = 100,
                Visible = false
            };
            DataGridViewColumn ageColumn1 = new DataGridViewColumn()
            {
                Name = "Name",
                HeaderText = "名称",
                FillWeight = 200,
                CellTemplate = new DataGridViewTextBoxCell(),
                MinimumWidth = 100,
                Visible = true
            };

            dataGridView1.Columns.Add(ageColumn0);
            dataGridView1.Columns.Add(ageColumn1);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitializeData()
        {
            npcList = DatabaseManager.Instance.GetNPCs();
            this.comboBox1.Items.Clear();
            for(int i =0;i<npcList.Count;i++)
            {
                ListItem li = new ListItem(npcList.ElementAt(i).ID, npcList.ElementAt(i).NPCName);
                this.comboBox1.Items.Add(li);
            }
            comboBox1.Enabled = false;

            this.comboBox2.Items.Clear();
            for (int i = 0; i < npcList.Count; i++)
            {
                ListItem li = new ListItem(npcList.ElementAt(i).ID, npcList.ElementAt(i).NPCName);
                this.comboBox2.Items.Add(li);
            }
            this.comboBox2.Enabled = false;

            this.comboBox3.Items.Clear();
            for (int i = 0; i < npcList.Count; i++)
            {
                ListItem li = new ListItem(npcList.ElementAt(i).ID, npcList.ElementAt(i).NPCName);
                this.comboBox3.Items.Add(li);
            }
            this.comboBox3.Enabled = false;

            UpdateTableData();
        }

        

        /// <summary>
        /// 表格点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow == null)
                {
                    return;
                }
                if(Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value) != currentTopic)
                {
                    currentTopic = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                    //TODO：切换对话树






                }
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
            
        }

        /// <summary>
        /// 添加树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            string npcNameTemp = "";

            StoryTree storyTree = new StoryTree();
            storyTree.ID = Guid.NewGuid().ToString();

            storyTree.Content = textBox1.Text;

            if (treeView1.SelectedNode == null)
            {
                TreeNode tn = treeView1.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                tn.Tag = storyTree.ID;
                storyTree.parentID = "";
                treeView1.SelectedNode = tn;
            }
            else
            {
                TreeNode tn = treeView1.SelectedNode.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                tn.Tag = storyTree.ID;
                storyTree.parentID = treeView1.SelectedNode.Tag.ToString();
                treeView1.SelectedNode = tn;
            }         
            

            //DatabaseManager.Instance.InsertStoryTree(storyTree);
        }

        /// <summary>
        /// 添加对话树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    return;
                }
                Story story = new Story();

                story.ID = Guid.NewGuid().ToString();
                story.NPCID = npcID;
                story.storyName = textBox2.Text;
                if(radioButton1.Checked)
                {
                    story.playerSex = "男";
                }
                else if(radioButton2.Checked)
                {
                    story.playerSex = "女";
                }
                else if(radioButton3.Checked)
                {
                    story.playerSex = "不限";
                }

                story.beginTime = Convert.ToInt32(textBox3.Text);
                story.endTime = Convert.ToInt32(textBox4.Text);
                story.beginFavorable = Convert.ToInt32(textBox5.Text);
                story.endFavorable = Convert.ToInt32(textBox6.Text);
                story.beginFavorableType = Convert.ToInt32(textBox7.Text);
                story.endFavorableType = Convert.ToInt32(textBox8.Text);

                int rowIndex = dataGridView1.Rows.Add(new string[] { story.ID, story.storyName });
                dataGridView1.CurrentCell = dataGridView1[1, rowIndex];
                currentTopic = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                treeView1.Nodes.Clear();

                DatabaseManager.Instance.InsertStory(story);
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }

        /// <summary>
        /// 说话人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox2.Enabled = radioButton5.Checked;
            if(!radioButton5.Checked)
            {
                this.comboBox2.Text = "";
            }
        }
        /// <summary>
        /// 说话人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox3.Enabled = radioButton7.Checked;
            if (!radioButton7.Checked)
            {
                this.comboBox3.Text = "";
            }
        }
        /// <summary>
        /// 所属人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox1.Enabled = radioButton8.Checked;
            if (!radioButton8.Checked)
            {
                this.comboBox1.Text = "";
            }
            UpdateTableData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTableData(); 
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTableData();
        }

        /// <summary>
        /// 更新表格数据
        /// </summary>
        private void UpdateTableData()
        {
            if (radioButton9.Checked)
            {
                npcID = "玩家";
            }
            else
            {
                if (this.comboBox1.SelectedIndex != -1)
                {
                    ListItem li = this.comboBox1.SelectedItem as ListItem;
                    npcID = li.Key;
                }
                else
                {
                    npcID = "";
                }
            }
            this.dataGridView1.Rows.Clear();
            if (!string.IsNullOrEmpty(npcID))
            {
                List<Story> storyList = DatabaseManager.Instance.GetStorysByID(npcID);
                foreach(Story story in storyList)
                {
                    int rowIndex = dataGridView1.Rows.Add(new string[] { story.ID, story.storyName });

                    currentTopic = "";

                }
            }
        }
    }

    public class ListItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ListItem(string pKey, string pValue)
        {
            this.Key = pKey;
            this.Value = pValue;
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
}
