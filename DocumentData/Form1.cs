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
        private string finalFolderPath = @"C:\Dmytro";
        private string FinalFolderPath { get { return finalFolderPath; } set { finalFolderPath = value; } }
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
            StartBtn.Enabled = false;
            SelectFolderToSaveBtn.Enabled = false;

            int proceedings_id = TakeProceedingId();
            List<int?> articles_id = TakeArticlesId(proceedings_id);
            TakeDocumentType(articles_id);
            TakeDocumentSections(proceedings_id);
            TakeDocumentAuthors(articles_id);
            TakeDocumentNumberAndNames(proceedings_id);
            TakeDocumentDate(proceedings_id);
            textBox1.Text += "DONE_DONE_DONE_DONE_DONE";

            StartBtn.Enabled = true;
            SelectFolderToSaveBtn.Enabled = true;
        }
        
        private void TakeDocumentDate(int proceedings_id)
        {
            List<int> documentDateTimeYearArr = new List<int>();
            List<int> documentDateTimeMonthArr = new List<int>();
            List<int> documentDateTimeDayArr = new List<int>();
            List<string> documentDateTimeArr = new List<string>();

            using (var db = new ovuEntities())
            {
                foreach (var item in db.articles)
                {
                    if (proceedings_id == item.proceedings_id)
                    {
                        documentDateTimeYearArr.Add(item.created_at.Year);
                        documentDateTimeMonthArr.Add(item.created_at.Month);
                        documentDateTimeDayArr.Add(item.created_at.Day);
                    }
                }
            }

            for (int i = 0; i < documentDateTimeDayArr.Count; i++)
            {
                documentDateTimeArr.Add(documentDateTimeYearArr[i].ToString() + "-" + documentDateTimeMonthArr[i].ToString() + "-" + documentDateTimeDayArr[i].ToString());
                textBox1.Text += documentDateTimeArr[i];
            }

            File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsDate_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentDateTimeArr);
        }
        private void TakeDocumentNumberAndNames(int proceedings_id)
        {
            List<string> documentNumberArr = new List<string>();
            List<string> documentNamesArr = new List<string>();

            using (var db = new ovuEntities())
            {
                foreach (var item in db.articles)
                {
                    if (item.proceedings_id == proceedings_id)
                    {
                        documentNumberArr.Add(item.number);
                        textBox1.Text += item.number;

                        documentNamesArr.Add(item.title);
                        textBox1.Text += item.title;
                    }
                }

                File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsNumber_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentNumberArr);
                File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsName_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentNamesArr);
            }


        }
        private void TakeDocumentAuthors(List<int?> articles_id)
        {
            using (var db = new ovuEntities())
            {
                List<string> documentAuthorsArr = new List<string>();
                List<int?> publishers_id = new List<int?>();

                int? check = 0;
                foreach (var item3 in articles_id)
                {
                    foreach (var item4 in db.collections)
                    {
                        if (item4.articles_id == item3 && item4.articles_id != check)
                        {
                            publishers_id.Add(item4.publishers_id);
                            check = item4.articles_id;
                        }
                    }
                }

                foreach (var item5 in publishers_id)
                {
                    foreach (var item6 in db.publishers)
                    {
                        if (item5 == item6.id)
                        {
                            documentAuthorsArr.Add(item6.title);
                            textBox1.Text += item6.title;
                        }
                    }
                }

                File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsAuthors_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentAuthorsArr);
            }
        }
        private void TakeDocumentSections(int proceedings_id)
        {
            using (var db = new ovuEntities())
            {
                List<int?> section_id = new List<int?>();
                List<string> documentSectionArr = new List<string>();

                foreach (var item2 in db.articles)
                {
                    if (item2.proceedings_id == proceedings_id)
                    {
                        section_id.Add(item2.section_id);
                    }
                }

                foreach (var item3 in section_id)
                {
                    foreach (var item4 in db.sections)
                    {
                        documentSectionArr.Add(item4.title);
                        textBox1.Text += item4.title;
                    }
                }

                File.WriteAllLines(FinalFolderPath + "\\" + "DocumentsSection_" + ((int)YearComboBox.SelectedItem).ToString() + "_" + (string)OvuNumberComboBox.SelectedItem + ".txt", documentSectionArr);
            }
        }
        private void TakeDocumentType(List<int?> articles_id)
        {
            using (var db = new ovuEntities())
            {
                List<string> documentTypeArr = new List<string>();                
                List<int?> article_type_id = new List<int?>();                
                
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

        private int TakeProceedingId()
        {
            int proceedings_id = 0;
            using (var db = new ovuEntities())
            {                
                foreach (var item in db.proceedings)
                {
                    if (item.created_at.Year == (int)YearComboBox.SelectedItem && item.number == (string)OvuNumberComboBox.SelectedItem)
                    {
                        proceedings_id = item.id;
                    }
                }
            }
            return proceedings_id;
        }

        private List<int?> TakeArticlesId(int proceedings_id)
        {
            List<int?> articles_id = new List<int?>();

            using (var db = new ovuEntities())
            {
                foreach (var item2 in db.articles)
                {
                    if (item2.proceedings_id == proceedings_id)
                    {
                        articles_id.Add(item2.id);
                    }
                }
            }

            return articles_id;
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
