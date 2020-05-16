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
    public partial class NPCEditor : Form
    {
        public NPCEditor()
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
                Name = "name",
                HeaderText = "姓名",
                FillWeight = 200,
                CellTemplate = new DataGridViewTextBoxCell(),
                MinimumWidth = 100,
                
            };
            DataGridViewColumn ageColumn2 = new DataGridViewColumn()
            {
                Name = "sex",
                HeaderText = "性别",
                FillWeight = 100,
                CellTemplate = new DataGridViewTextBoxCell(),
                MinimumWidth = 100,      
            };
            DataGridViewColumn ageColumn3 = new DataGridViewColumn()
            {
                Name = "content",
                HeaderText = "介绍",
                FillWeight = 900,
                CellTemplate = new DataGridViewTextBoxCell(),
                MinimumWidth = 100,
            };

            ageColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ageColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns.Add(ageColumn0);
            dataGridView1.Columns.Add(ageColumn1);
            dataGridView1.Columns.Add(ageColumn2);
            dataGridView1.Columns.Add(ageColumn3);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
        }
        /// <summary>
        /// 单击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBox2.Text.Trim()))
                {
                    MessageBox.Show("请填写姓名");
                    return;
                }                             

                string NpcSex = "男";
                if (radioButton2.Checked)
                {
                    NpcSex = "女";
                }
                int rowIndex = dataGridView1.Rows.Add(new string[] { Guid.NewGuid().ToString(), textBox2.Text, NpcSex, textBox1.Text });
                dataGridView1.CurrentCell = dataGridView1[1, rowIndex];
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow != null)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
