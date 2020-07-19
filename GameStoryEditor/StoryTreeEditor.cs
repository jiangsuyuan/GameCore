using GameCore.Database;
using GameCore.DataStructs;
using GameLogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        /// 当前人对话列表
        /// </summary>
        private List<Story> storyList = null;


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

        #region 选择所属人
        /// <summary>
        /// 人员选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTableData();
        }
        /// <summary>
        /// 所属人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTableData();
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
                foreach (Story story in storyList)
                {
                    int rowIndex = dataGridView1.Rows.Add(new string[] { story.ID, story.storyName });

                    currentTopic = "";
                }
                this.storyList = storyList;
            }
        }
        #endregion

        #region 对话管理
        /// <summary>
        /// 单击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentRow == null || this.dataGridView1.CurrentRow.Index < 0)
                {
                    return;
                }
                if (this.storyList != null)
                {
                    Story story = storyList.ElementAt(e.RowIndex);
                    this.textBox2.Text = story.storyName;
                    if (story.playerSex == "男")
                    {
                        this.radioButton1.Checked = true;
                    }
                    if (story.playerSex == "女")
                    {
                        this.radioButton2.Checked = true;
                    }
                    else
                    {
                        this.radioButton3.Checked = true;
                    }
                    this.textBox3.Text = story.beginTime.ToString();
                    this.textBox4.Text = story.endTime.ToString();
                    this.textBox5.Text = story.beginFavorable.ToString();
                    this.textBox6.Text = story.endFavorable.ToString();
                    this.textBox7.Text = story.beginFavorableType.ToString();
                    this.textBox8.Text = story.endFavorableType.ToString();

                    this.button4.Enabled = true;
                    this.button5.Enabled = false;
                    this.button6.Enabled = true;

                    if (Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value) != currentTopic)
                    {
                        treeView1.Nodes.Clear();

                        currentTopic = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                        story.dialogueTree = DatabaseManager.Instance.GetStoryTreesByID(currentTopic);
                        for(int i = 0;i < story.dialogueTree.Count;i++)
                        {
                            if (string.IsNullOrEmpty(story.dialogueTree.ElementAt(i).parentID))
                            {
                                string talkerName = "玩家";
                                if (!string.IsNullOrEmpty(story.dialogueTree.ElementAt(i).TalkerID))
                                {
                                    for (int j = 0; j < npcList.Count; j++)
                                    {
                                        if (npcList.ElementAt(j).ID == story.dialogueTree.ElementAt(i).TalkerID)
                                        {
                                            break;
                                        }
                                    }
                                }
                                TreeNode tn = treeView1.Nodes.Add(talkerName + "：" + story.dialogueTree.ElementAt(i).Content);
                                tn.Tag = story.dialogueTree.ElementAt(i);
                                this.CreateTree(tn, story.dialogueTree.ElementAt(i).ID, story.dialogueTree);
                                break;
                            }
                        }
                        treeView1.ExpandAll();
                    }
                }               

                panel1.Enabled = false;
                panel2.Enabled = false;
                panel4.Enabled = false;
                this.treeView1.Enabled = false;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 新建树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.CurrentCell = null;

                //清空
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                this.radioButton3.Checked = true;

                this.radioButton4.Checked = true;
                this.radioButton6.Checked = true;
                this.textBox9.Text = "";
                this.textBox1.Text = "";
                this.treeView1.Nodes.Clear();

                panel1.Enabled = false;
                panel2.Enabled = true;
                panel4.Enabled = true;
                this.treeView1.Enabled = true;

                this.button6.Enabled = false;
                this.button5.Enabled = true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 修改树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = false;
                panel2.Enabled = this.treeView1.Nodes.Count == 0 | false;
                panel4.Enabled = true;
                button5.Enabled = true;
                this.treeView1.Enabled = true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    return;
                }
                Story story = new Story();

                story.ID = Guid.NewGuid().ToString();
                story.NPCID = npcID;
                story.storyName = textBox2.Text;
                if (radioButton1.Checked)
                {
                    story.playerSex = "男";
                }
                else if (radioButton2.Checked)
                {
                    story.playerSex = "女";
                }
                else if (radioButton3.Checked)
                {
                    story.playerSex = "不限";
                }

                //保存对话
                story.beginTime = Convert.ToInt32(textBox3.Text);
                story.endTime = Convert.ToInt32(textBox4.Text);
                story.beginFavorable = Convert.ToInt32(textBox5.Text);
                story.endFavorable = Convert.ToInt32(textBox6.Text);
                story.beginFavorableType = Convert.ToInt32(textBox7.Text);
                story.endFavorableType = Convert.ToInt32(textBox8.Text);

                int rowIndex = dataGridView1.Rows.Add(new string[] { story.ID, story.storyName });
                dataGridView1.CurrentCell = dataGridView1[1, rowIndex];
                currentTopic = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);

                //获取对话树
                if (treeView1.Nodes.Count > 0)
                {
                    getTreeNodes(treeView1.Nodes[0], ref story.dialogueTree);
                }

                //TODO:判断Insert还是Update
                DatabaseManager.Instance.InsertStory(story);
                for (int i = 0; i < story.dialogueTree.Count; i++)
                {
                    DatabaseManager.Instance.InsertStoryTree(story.dialogueTree.ElementAt(i));
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 递归获取所有对话。
        /// </summary>
        /// <param name="tn"></param>
        private void getTreeNodes(TreeNode tn, ref List<StoryTree> storyTreeList)
        {
            storyTreeList.Add(tn.Tag as StoryTree);
            foreach (TreeNode tnSub in tn.Nodes)
            {
                getTreeNodes(tnSub, ref storyTreeList);
            }
        }
        /// <summary>
        /// 递归生成树
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="ParentId"></param>
        /// <param name="SubClassItem"></param>
        public void CreateTree(TreeNode Node, string ParentId, List<StoryTree> SubClassItem)
        {
            try
            {
                for (int i = 0; i < SubClassItem.Count; i++)
                {
                    if (SubClassItem.ElementAt(i).parentID == ParentId)
                    {
                        string talkerName = "玩家";
                        if (!string.IsNullOrEmpty(SubClassItem.ElementAt(i).TalkerID))
                        {
                            for (int j = 0; j < npcList.Count; j++)
                            {
                                if (npcList.ElementAt(j).ID == SubClassItem.ElementAt(i).TalkerID)
                                {
                                    break;
                                }
                            }
                        }
                        TreeNode tn = Node.Nodes.Add(talkerName + "：" + SubClassItem.ElementAt(i).Content);
                        tn.Tag = SubClassItem.ElementAt(i);
                        CreateTree(tn, SubClassItem.ElementAt(i).ID, SubClassItem);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        #endregion

        #region 对话树管理
        /// <summary>
        /// 添加回应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string npcNameTemp = "";

            if(this.radioButton6.Checked)
            {
                npcNameTemp = "玩家";
            }
            else
            {
                if(!string.IsNullOrEmpty(comboBox3.Text))
                {
                    npcNameTemp = comboBox3.Text;
                }
                else
                {
                    MessageBox.Show("请选择NPC");
                }
            }

            StoryTree storyTree = new StoryTree();
            storyTree.ID = Guid.NewGuid().ToString();
            storyTree.Content = textBox1.Text;
            storyTree.DialogueID = currentTopic;

            if (treeView1.Nodes.Count == 0)
            {
                TreeNode tn = treeView1.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                tn.Tag = storyTree;
                storyTree.parentID = "";
                treeView1.SelectedNode = tn;
                
            }
            else if(treeView1.SelectedNode != null)
            {
                TreeNode tn = treeView1.SelectedNode.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                tn.Tag = storyTree;
                storyTree.parentID = (treeView1.SelectedNode.Tag as StoryTree).ID;
                treeView1.SelectedNode = tn;
            }
            ////保存对话
            //DatabaseManager.Instance.InsertStory(storyTree);
        }
        /// <summary>
        /// 说话人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBox2.Enabled = radioButton5.Checked;
            if (!radioButton5.Checked)
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

        #endregion

        //删除节点
        private void button2_Click(object sender, EventArgs e)
        {
            //判断，删除所有子节点还是删除当前层级。


        }
        /// <summary>
        /// 更新节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {



            //DatabaseManager.Instance.UpdateStory(storyTree);
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
