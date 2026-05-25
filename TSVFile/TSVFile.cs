using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TSVFile
{
    public partial class frmTSVFile : Form
    {
        /// <summary>
        /// 單字清單
        /// </summary>
        WordCollection _WordList = new WordCollection();

        /// <summary>
        /// 關於視窗
        /// </summary>
        frmAbout about = new frmAbout();

        public frmTSVFile()
        {
            InitializeComponent();
        }

        private void TSVFile_Load(object sender, EventArgs e)
        {
            tsslMessage.Text = "請開啟檔案";

            lvwWord.View = View.Details;
            lvwWord.FullRowSelect = true;

            if (lvwWord.Columns.Count == 0)
            {
                lvwWord.Columns.Add("Word", 120);
                lvwWord.Columns.Add("Phonogram", 120);
                lvwWord.Columns.Add("SoundPath", 200);
                lvwWord.Columns.Add("Explain", 400);
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text files (*.txt)|*.txt|TSV files (*.tsv)|*.tsv|All files (*.*)|*.*";
            ofd.Title = "開啟檔案";
            ofd.InitialDirectory = Application.StartupPath;

            DialogResult dr = ofd.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);

                _WordList.LoadFromStringArray(lines);

                UpdateListView();

                tsslMessage.Text = $"已載入 {_WordList.Count} 筆資料";
            }
        }

        /// <summary>
        /// 更新 ListView 的內容
        /// </summary>
        private void UpdateListView()
        {
            lvwWord.BeginUpdate();

            lvwWord.Items.Clear();

            foreach (WordItem item in _WordList)
            {
                ListViewItem lvi = new ListViewItem(item.Word);

                lvi.SubItems.Add(item.Phonogram);
                lvi.SubItems.Add(item.SoundPath);
                lvi.SubItems.Add(item.Explain);

                lvwWord.Items.Add(lvi);
            }

            lvwWord.EndUpdate();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog(this);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSVFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "確定要離開嗎?",
                "離開",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void tsmiExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTSVFile_Load(object sender, EventArgs e)
        {
            tsslMessage.Text = "請開啟檔案";
        }

        private void frmTSVFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("確定要離開嗎?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
        }
    }
}