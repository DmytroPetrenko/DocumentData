using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentData
{
    public partial class Form1 : Form
    {
        private string finalFilderPath = @"C:\Dmytro";
        private string FinalFolderPath { get { return finalFilderPath; } set { finalFilderPath = value; } }
        public Form1()
        {
            InitializeComponent();

            using (ovuEntities db = new ovuEntities())
            {
                // Заполнение списка с годами
                var proceedings = db.proceedings;
                List<int> years = new List<int>();
                foreach (var item in proceedings)
                {
                    if (!years.Contains(item.created_at.Year))
                    {
                        years.Add(item.created_at.Year);
                    }
                }
                YearComboBox.DataSource = years;
                OvuNumberComboBox_SelectedIndexChanged(new object(), new EventArgs());
                YearComboBox.SelectedIndexChanged += OvuNumberComboBox_SelectedIndexChanged;
            }
        }

        void OvuNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (ovuEntities db = new ovuEntities())
            {
                var proceedings = db.proceedings;
                List<string> ovuNumbers = new List<string>();                
                foreach (var item in proceedings)
                {
                    if ((int)YearComboBox.SelectedItem == item.created_at.Year)
                    {
                        ovuNumbers.Add(item.number);
                    }
                }
                OvuNumberComboBox.DataSource = ovuNumbers;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            TakeDocumentType();
        }

        private void TakeDocumentType()
        {
            using (var db = new ovuEntities())
            {
                var article_types = db.article_types;
                List<string> documentTypeArr = new List<string>();
                List<int?> articles_id = new List<int?>();
                List<int?> article_type_id = new List<int?>();
                int proceedings_id = 0;
                foreach (var item in db.proceedings)
                {
                    if (item.created_at.Year == (int)YearComboBox.SelectedItem && item.number == (string)OvuNumberComboBox.SelectedItem)
                    {
                        proceedings_id = item.id;                        
                    }
                }

                foreach (var item2 in db.articles)
                {
                    if (item2.proceedings_id == proceedings_id)
                    {
                        articles_id.Add(item2.id);                     
                    }
                }
                int? check = 0;
                foreach (var item3 in articles_id)
                {
                    foreach (var item4 in db.collections)
                    {
                        
                        if (item4.articles_id == item3 && item4.articles_id != check)
                        {
                            article_type_id.Add(item4.article_type_id);
                            check = item4.articles_id;
                        }
                    }
                }

                foreach (var item5 in article_type_id)
                {
                    foreach (var item6 in db.article_types)
                    {
                        if (item5 == item6.id)
                        {
                            documentTypeArr.Add(item6.title);
                            textBox1.Text += item6.title;
                        }
                    }
                }

                File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsType_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentTypeArr);
            }
        }

        private void SelectFolderToSaveBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.ShowDialog();
                textBox1.Text += "Выбрана папка: " + dialog.SelectedPath;
                FinalFolderPath = dialog.SelectedPath;
            }
        }
    }
}
