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
    public partial class StoryTreeEditor : Form
    {
        public StoryTreeEditor()
        {
            InitializeComponent();

            InitializeTable();
        }
        /// <summary>
        /// 初始化表格
        /// </summary>
        public void InitializeTable()
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

        private string currentTopic = "";

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
            string npcNameTemp = "你好";


            if (treeView1.SelectedNode == null)
            {
                TreeNode tn = treeView1.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                treeView1.SelectedNode = tn;
            }
            else
            {
                TreeNode tn = treeView1.SelectedNode.Nodes.Add(npcNameTemp + "：" + textBox1.Text);
                treeView1.SelectedNode = tn;
            }
            
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

                int rowIndex = dataGridView1.Rows.Add(new string[] { Guid.NewGuid().ToString(), textBox2.Text });
                dataGridView1.CurrentCell = dataGridView1[1, rowIndex];
                currentTopic = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                treeView1.Nodes.Clear();
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
    }
}
