using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;  // for query






namespace CoverLetterGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (this.Form1_Closing);
        }

        object missing = System.Reflection.Missing.Value;
        Word.Document newCoverLetter;
        Word.Application wordApp;

        string[] templateFiles = null;

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

          



            bool wordAppAcikMi = false;

            Process[] islemler = Process.GetProcesses();

            foreach (Process islemadi in islemler)
            {

                if (islemadi.ProcessName == "WINWORD" /*&& wordApp != null*/ )
                {
                    //islemadi.Kill();
                    wordAppAcikMi = true;
                    break;
                }
            }


            // Eğer wordApp zaten açılmışsa, tekrar açma
            if (wordAppAcikMi == false)
            {
                this.wordApp = new Word.Application();

            }




            // Note: Instead of reading all templates, only ticked templates should be read.
            ReadAllTemplates();


            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;





            // create new word document named as "newCoverLetter"
            newCoverLetter = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            

            //string tarih = month + "." + day + "." + year ;
            string tarih = DateTime.Now.ToString("MMMM d, yyyy");


            // Mektubun başına tarih eklenir
            AddParagraph(newCoverLetter, tarih);


            string genderOfRecruiter = comboBoxGender.Text;
            string surnameOfRecruiter = textBoxHiringManagerName.Text;

            string hitap = null;

            if (surnameOfRecruiter == "")
            {
                hitap = "Dear Hiring Manager,";

            }
            else
            {
                hitap = "Dear " + genderOfRecruiter + " " + surnameOfRecruiter;
            }

            // Hitap eklenir
            AddParagraph(newCoverLetter, hitap);




            // Intro paragrafı replace edilerek eklenir.
            
            templateFilesDictionary[checkBoxIntroduction.Text] = templateFilesDictionary[checkBoxIntroduction.Text].Replace("PARAMETER_JOB_NAME", textBoxPosition.Text);

            if (textBoxJobRefCode.Text != "" && textBoxJobRefCode.Text != null)
            {
                string jobRefCodeText = String.Concat("with the job reference code ", textBoxJobRefCode.Text);
                templateFilesDictionary[checkBoxIntroduction.Text] = templateFilesDictionary[checkBoxIntroduction.Text].Replace("PARAMETER_JOB_REFERENCE_CODE", jobRefCodeText);
            }
            else
            {
               
                templateFilesDictionary[checkBoxIntroduction.Text] = templateFilesDictionary[checkBoxIntroduction.Text].Replace("PARAMETER_JOB_REFERENCE_CODE", "");
            }

            //fileIntroduction = fileIntroduction.Replace("PARAMETER_JOB_NAME", textBoxPosition.Text);
            //fileIntroduction = fileIntroduction.Replace("PARAMETER_JOB_REFERENCE_CODE", textBoxJobRefCode.Text);


            if (checkBoxIntroduction.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBoxIntroduction.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBoxIntroduction.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBoxIntroduction.Text + "\"");
                }

            }


            //string companyName = textBoxCompanyName.Text;

            #region YETENEKLER..........

            if (checkBoxEducation.Checked)
            {
                var a = checkBoxEducation.Text;
                AddParagraph(newCoverLetter, templateFilesDictionary[checkBoxEducation.Text]);
                

            }

            

            if (checkBox_OOP.Checked)
            {
                
                

                if (templateFilesDictionary.ContainsKey(checkBox_OOP.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_OOP.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_OOP.Text + "\"");
                }

            }


            if (checkBox_SDLC.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_SDLC.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_SDLC.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_SDLC.Text + "\"");
                }
            }


            if (checkBox_BScDegree.Checked)
            {
                


                if (templateFilesDictionary.ContainsKey(checkBox_BScDegree.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_BScDegree.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_BScDegree.Text + "\"");
                }
            }

            if (checkBox_MScDegree.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_MScDegree.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_MScDegree.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_MScDegree.Text + "\"");
                }
            }

            if (checkBox_Database.Checked)
            {
                


                if (templateFilesDictionary.ContainsKey(checkBox_Database.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_Database.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_Database.Text + "\"");
                }
            }

            if (checkBox_DriverLicense.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_DriverLicense.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_DriverLicense.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_DriverLicense.Text + "\"");
                }
            }

            if (checkBox_LanguageSkills.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_LanguageSkills.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_LanguageSkills.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_LanguageSkills.Text + "\"");
                }
            }

            if (checkBox_MacOSExperience.Checked)
            {
                


                if (templateFilesDictionary.ContainsKey(checkBox_MacOSExperience.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_MacOSExperience.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_MacOSExperience.Text + "\"");
                }


            }

            if (checkBox_ScriptingLanguages.Checked)
            {
                


                if (templateFilesDictionary.ContainsKey(checkBox_ScriptingLanguages.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_ScriptingLanguages.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_ScriptingLanguages.Text + "\"");
                }
            }

            if (checkBox_VersionControl.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_VersionControl.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_VersionControl.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_VersionControl.Text + "\"");
                }
            }

            if (checkBox_TestAutomation.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_TestAutomation.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_TestAutomation.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_TestAutomation.Text + "\"");
                }
            }

            if (checkBox_IntegrationTesting.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_IntegrationTesting.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_IntegrationTesting.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_IntegrationTesting.Text + "\"");
                }
            }

            if (checkBox_UnitTesting.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_UnitTesting.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_UnitTesting.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_UnitTesting.Text + "\"");
                }
            }

            if (checkBox_DICOM.Checked)
            {
                


                if (templateFilesDictionary.ContainsKey(checkBox_DICOM.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_DICOM.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_DICOM.Text + "\"");
                }
            }

            if (checkBox_Jenkins.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBox_Jenkins.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_Jenkins.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_Jenkins.Text + "\"");
                }
            }

            if (checkBox_BugTrackingTools.Checked)
            {
                if (templateFilesDictionary.ContainsKey(checkBox_BugTrackingTools.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_BugTrackingTools.Text]);

                }
                else
                {
                    
                    MessageBox.Show("No Template document found with the name of " +"\"" +  checkBox_BugTrackingTools.Text + "\"");
                }
                
            }

            if (checkBox_iOSDeveloper.Checked)
            {
                if (templateFilesDictionary.ContainsKey(checkBox_iOSDeveloper.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBox_iOSDeveloper.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBox_iOSDeveloper.Text + "\"");
                }

            }





            #endregion
            
            


            // Tum yetenekler eklendikten sonra COCNLUSION eklenir.
            if (checkBoxConclusion.Checked)
            {
                

                if (templateFilesDictionary.ContainsKey(checkBoxConclusion.Text))
                {
                    AddParagraph(newCoverLetter, templateFilesDictionary[checkBoxConclusion.Text]);

                }
                else
                {

                    MessageBox.Show("No Template document found with the name of " + "\"" + checkBoxConclusion.Text + "\"");
                }

            }


            // Copy the text of the cover letter to Clipboard     
            Clipboard.SetText(newCoverLetter.Range().Text);



            string savingDirectory = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Generated_Cover_Letters\";
            //string savingDirectory = @"D:\Muharrem\Csharp_Projects\CoverLetterGenerator\Generated_Cover_Letters\";
            string savingFolderName = "";
            string savingFileName = "";

            if (textBoxJobRefCode.Text != null && textBoxJobRefCode.Text != "")
            {
                savingFolderName =  textBoxCompanyName.Text + "_" + textBoxPosition.Text + "_" + textBoxJobRefCode.Text + "_" + textBoxCity.Text;
                savingFileName = "CoverLetter_" + textBoxCompanyName.Text + "_" + textBoxPosition.Text + "_" + textBoxJobRefCode.Text + "_" + textBoxCity.Text + ".docx";
            }
            else
            {
                savingFolderName = textBoxCompanyName.Text + "_" + textBoxPosition.Text  + "_" + textBoxCity.Text;
                savingFileName = "CoverLetter_" + textBoxCompanyName.Text + "_" + textBoxPosition.Text  + "_" + textBoxCity.Text + ".docx";
            }




            var path = Path.Combine(savingDirectory, savingFolderName);
            
            var newDirectory = System.IO.Directory.CreateDirectory(path);


            // deneme
           // var sdfsdfs = Directory.CreateDirectory(@"D:\Muharrem\ali");
            

            //object nameOfNewCoverLetter = @"D:\mhrrm\C#_Projeler\CoverLetterGenerator\Cover_Letter_Templates\Cover_Letter_Template.docx";
            object nameOfNewCoverLetter = String.Concat(path, "\\", savingFileName) as object;
            newCoverLetter.SaveAs(ref nameOfNewCoverLetter);
            newCoverLetter.Close(ref missing, ref missing, ref missing);


            MessageBox.Show("DONE !");

            /*  Çıkarken kapatmaya gerek yok.

            Process[] islemler = Process.GetProcesses();

            foreach (Process islemadi in islemler)
            {

                if (islemadi.ProcessName == "WINWORD")
                {

                    islemadi.Kill();

                }
            }
             * 
             */
             

        }

        private void AddParagraph(Word.Document wordDocument, string s)
        {
            // Verilen word dökümanına, string olarak verilen paragrafı ekler
            Word.Paragraph tempParagraph = wordDocument.Content.Paragraphs.Add(ref missing);
            tempParagraph.Range.Text = s;
            tempParagraph.Range.InsertParagraphAfter();


        }




        //string fileEducation;
        //string fileExperience;
        //string fileRelocation;
        //string fileIntroduction;
        //string fileConclusion;

        ////string file1 = @"D:\mhrrm\is\Cover_Letter_Templates\Education.txt";
        ////string file2 = @"D:\mhrrm\is\Cover_Letter_Templates\Experience.txt";
        ////string file3 = @"D:\mhrrm\is\Cover_Letter_Templates\Conclusion.txt";
        
        //string fileNameEducation = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\Education.docx";
        //string fileNameExperience = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\Experience.docx";
        //string fileNameRelocation = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\Relocation.docx";
        //string fileNameIntroduction = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\Introduction.docx";
        //string fileNameConclusion = @"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\Conclusion.docx";


        private string extractFileName(string wholeFileName)
        {
            
            string [] splittedArray = wholeFileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
            splittedArray = splittedArray[splittedArray.Length - 1].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            return splittedArray[0];
        }

        // this dictionary keeps all of the template files. (value, key) = (fileName, fileContent)
        Dictionary<string, string> templateFilesDictionary = new Dictionary<string, string>();

        private void ReadAllTemplates()
        {
            // remove all previous entries in the dictionary, Each time we will generate it again.
            templateFilesDictionary.Clear();

            // get template files and then remove the temporary ones.
            templateFiles = Directory.GetFiles(@"D:\Muharrem\Csharp_Projects_SVN\CoverLetterGenerator\Cover_Letter_Templates\");
            templateFiles = templateFiles.Where(c => !c.Contains("$")).ToArray();


            string fileName = null;
            foreach (var item in templateFiles)
            {
                fileName = extractFileName(item);
                templateFilesDictionary.Add(fileName, ReadWordDoc(item));
            }



        }

        private string ReadWordDoc(string fileName)
        {
            string dokumanMetni = "";
            Word.Document document = null;

            object readOnly = false;
            object isVisible = false;

            object fileNameMdfd = (object)Convert.ChangeType(fileName, typeof(Object));

            if (File.Exists(fileName))
            {

                wordApp.Visible = false;

                try
                {
                    //document = wordApp.Documents.Open(@"D:\Muharrem\Csharp_Projects\CoverLetterGenerator\Cover_Letter_Templates\Education.docx");
                    document = wordApp.Documents.Open(ref fileNameMdfd,
                                                        ref missing,
                                                           ref readOnly,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref isVisible,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing,
                                                           ref missing);
                    dokumanMetni = document.Content.Text;

                    //document.Close(ref missing, ref missing, ref missing);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }





            }
            else
            {
                MessageBox.Show("File does not exist");
            }


            return dokumanMetni;

        }


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = fileDialog.FileName;

                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);

                string[] okunanDosyaSatirlari = File.ReadAllLines(fileToOpen);

            }
        }

        private void clearTextBoxes()
        {
            textBoxCity.Clear();
            textBoxCompanyName.Clear();
            textBoxJobRefCode.Clear();
            textBoxHiringManagerName.Clear();
            textBoxPosition.Clear();
            textBox_HiringManagerContactInfo.Clear();
            textBoxSalary.Clear();
            textBoxSalaryMax.Clear();
            textBoxSalaryMin.Clear();
            //textBox_Explanation.Clear();
            textBox_JobType.Clear();
            richTextBox_Explanation.Clear();
            textBox_IDofTheEntity.Clear();

        }

        private void clearComboBoxes()
        {
            comboBoxGender.SelectedIndex = -1;
            comboBoxIsResponseGiven.SelectedIndex = -1;
            comboBoxIsResponsePositive.SelectedIndex = -1;
            comboBox_IsBeenApplied.SelectedIndex = -1;
            comboBox_JobFindPlatform.SelectedIndex = -1;
            comboBox_CoverLetterSent.SelectedIndex = -1;



            comboBoxGender.ResetText();
            comboBox_IsBeenApplied.ResetText();
            comboBoxIsResponseGiven.ResetText();
            comboBoxIsResponsePositive.ResetText();
            comboBox_CoverLetterSent.ResetText();
            comboBox_JobFindPlatform.ResetText();

        }


        private void clearCheckBoxes()
        {
            checkBoxConclusion.Checked = false;
            checkBoxEducation.Checked = false;
            //checkBoxExperience.Checked = false;
            checkBoxIntroduction.Checked = false;
            checkBox_OOP.Checked = false;

            

        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            // clear text boxes
            //clearTextBoxes();
            textBoxCity.Clear();
            textBoxCompanyName.Clear();
            textBoxJobRefCode.Clear();
            textBoxHiringManagerName.Clear();
            textBoxPosition.Clear();
            textBox_HiringManagerContactInfo.Clear();
            textBoxSalary.Text = "0";
            textBoxSalaryMax.Text = "0";
            textBoxSalaryMin.Text = "0";
            //textBox_Explanation.Clear();
            textBox_JobType.Clear();
            richTextBox_Explanation.Clear();
            textBox_IDofTheEntity.Clear();


            // clear combo boxes
            //clearComboBoxes();
            comboBoxGender.ResetText();
            comboBox_IsBeenApplied.Text = "True";
            comboBoxIsResponseGiven.Text = "False";
            comboBoxIsResponsePositive.Text = "False";
            comboBox_CoverLetterSent.Text = "False";
            comboBox_JobFindPlatform.ResetText();

            // Uncheck checkboxes
            clearCheckBoxes();
            

        }

        #region GETTER & SETTER of Form1 

        public string TextBoxCompanyName
        {
            get
            {
                return textBoxCompanyName.Text;
            }

            set
            {
                textBoxCompanyName.Text = value;
            }
        }


        public string TextBoxJobType
        {
            get { return textBox_JobType.Text; }
            set { textBox_JobType.Text = value; }
        }



        public string TextBoxHiringManagerName
        {
            get
            {
                return textBoxHiringManagerName.Text;
            }

            set
            {
                textBoxHiringManagerName.Text = value;
            }
        }

        public string TextBoxPosition
        {
            get
            {
                return textBoxPosition.Text;
            }

            set
            {
                textBoxPosition.Text = value;
            }
        }

        public string TextBoxJobRefCode
        {
            get
            {
                return textBoxJobRefCode.Text;
            }

            set
            {
                textBoxJobRefCode.Text = value;
            }
        }

        public string TextBoxCity
        {
            get
            {
                return textBoxCity.Text;
            }

            set
            {
                textBoxCity.Text = value;
            }
        }

        public string TextBoxSalary
        {
            get
            {
                return textBoxSalary.Text;
            }

            set
            {
                textBoxSalary.Text = value;
            }
        }

        public string TextBoxSalaryMin
        {
            get
            {
                return textBoxSalaryMin.Text;
            }

            set
            {
                textBoxSalaryMin.Text = value;
            }
        }

        public string TextBoxSalaryMax
        {
            get
            {
                return textBoxSalaryMax.Text;
            }

            set
            {
                textBoxSalaryMax.Text = value;
            }
        }



        public string TextBox_HiringManagerContactInfo
        {
            get
            {
                return textBox_HiringManagerContactInfo.Text;

            }

            set
            {
                textBox_HiringManagerContactInfo.Text = value;



            }
        }


        public string ComboBoxIsResponseGiven
        {

            get
            {
                return comboBoxIsResponseGiven.Text;
            }
            set
            {
                // first clear the previuos selection
                comboBoxIsResponseGiven.SelectedIndex = -1;
                // then set the value
                comboBoxIsResponseGiven.SelectedText = value;
            }
        }


        public string ComboBoxIsResponsePositive
        {
            set
            {
                comboBoxIsResponsePositive.SelectedIndex = -1;
                comboBoxIsResponsePositive.SelectedText = value;
            }
        }

        public string ComboBox_IsBeenApplied
        {
            set
            {
                comboBox_IsBeenApplied.SelectedIndex = -1;
                comboBox_IsBeenApplied.SelectedText = value;
            }
        }

        public string ComboBox_JobFindPlatform
        {
            set
            {
                comboBox_JobFindPlatform.SelectedIndex = -1;
                comboBox_JobFindPlatform.SelectedText = value;
            }
        }

        public string ComboBoxGender
        {
            set
            {
                comboBoxGender.SelectedIndex = -1;
                comboBoxGender.SelectedText = value;
            }
        }








        #endregion















        #region Job Application Tracking DB Stuff
        // DB related attributes
        MongoClient client = new MongoClient();
        private static MongoCollection<JobApplicationInfoCls> collection;
        string nameOfTheDB = "";
        string nameOfTheCollection = "";
        MongoServer server;
        MongoDatabase dataBase;
        bool IsConnectedToDB = false;

        public static MongoCollection<JobApplicationInfoCls> Collection
        {
            get
            {
                return collection;
            }
        }

        #endregion


        #region Contact List Manager DB Stuff

        MongoClient CLM_MongoClient = new MongoClient();
        private static MongoCollection<ContactListCls> CLM_collection;

        string nameOfTheDB_CLM = "";
        string nameOfTheCollection_CLM = "";
        MongoServer server_CLM;
        MongoDatabase dataBase_CLM;
        bool IsConnectedToDB_CLM = false;


        public static MongoCollection<ContactListCls> Collection_CLM
        {
            get
            {
                return CLM_collection;
            }
        }
        

        #endregion






        private void button_Read_DB_Click(object sender, EventArgs e)
        {
            if (collection != null)
            {
                // get all the entries whose company name starts with Apple
                var x = collection.AsQueryable().Where(b => b.CompanyName.StartsWith("Apple"));

                // get all the jobs whose salaries are bigger than 40 K
                var number = collection.AsQueryable().Where(b => b.Salary > 40000);

                // finds the job gives the minimum salary. Orderby orders the collection in ascending order
                var minSalaryJob = collection.AsQueryable().OrderBy(b => b.Salary).First();

                // finds the job gives the maximum salary. Orderby orders the collection in ascending order
                var maxSalaryJob = collection.AsQueryable().OrderBy(b => b.Salary).Last();

                // Find a particular entry
                var entry = collection.AsQueryable().Single(b => b.CompanyName == "Microsoft");

                // remove specific entry   ???
                //collection.Remove(IMongoQuery.Equals("CompanyName", "Microsoft3"));

                // remove all collection
                //collection.RemoveAll();

            }

            else
            {
                MessageBox.Show("First, Connect to a DATABASE");
            }

        }

        private void button_WriteDB_Click(object sender, EventArgs e)
        {
            //MongoClient client = new MongoClient();
            //var server = client.GetServer();
            //var db = server.GetDatabase("JobApplicationPool");
            //collection = db.GetCollection<JobApplicationInfoCls>("JobApplicationInfo");

            if (IsConnectedToDB == false)
            {
                // no connection with database, first connect

                if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                {

                    nameOfTheDB = textBox_NameOfTheDB.Text;
                    nameOfTheCollection = textBox_NameOfTheCollection.Text;


                    server = client.GetServer();
                    dataBase = server.GetDatabase(nameOfTheDB);
                    collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                    // delete cached culture info so that current local time is fetched correctly. 
                    System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                    IsConnectedToDB = true;

                }
                else
                {
                    MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                }


            }

            JobApplicationInfoCls result = null;

            if (collection != null)
            {


                string IDofTheCurrentEntity = textBox_IDofTheEntity.Text;
                ObjectId newObjectID;
                bool IsValidObjectID = ObjectId.TryParse(IDofTheCurrentEntity, out newObjectID);

                if (IsValidObjectID)
                {
                    var queryID = Query.EQ("_id", newObjectID);
                    result = collection.FindOne(queryID);

                }


                //var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheCurrentEntity));
                //var result = collection.FindOne(queryID);

                if (IsValidObjectID == true && result != null)
                {
                    // daha once database e girilmis, update et
                    // result i mevcut UI verilerine gore update et ve db ye yaz.

                    result.HiringManagerName = textBoxHiringManagerName.Text;
                    result.HiringManagerContactInfo = textBox_HiringManagerContactInfo.Text;
                    result.HiringManagerGender = comboBoxGender.Text;
                    result.CompanyName = textBoxCompanyName.Text;
                    result.Position = textBoxPosition.Text;
                    result.JobReferenceCode = textBoxJobRefCode.Text;
                    result.City = textBoxCity.Text;
                    // Application date will not be updated. it is the time when first written to db
                    result.Salary = Convert.ToUInt32(textBoxSalary.Text);
                    result.SalaryMax = Convert.ToUInt32(textBoxSalaryMax.Text);
                    result.SalaryMin = Convert.ToUInt32(textBoxSalaryMin.Text);
                    result.IsResponseGiven = Convert.ToBoolean(comboBoxIsResponseGiven.Text.ToString());
                    result.IsResponsePositive = Convert.ToBoolean(comboBoxIsResponsePositive.Text.ToString());
                    result.IsApplied = Convert.ToBoolean(comboBox_IsBeenApplied.Text.ToString());
                    result.CoverLetterSent = Convert.ToBoolean(comboBox_CoverLetterSent.Text.ToString());
                    result.JobFindingPlatform = comboBox_JobFindPlatform.Text.ToString();
                    result.JobType = textBox_JobType.Text.ToString();
                    //result.Explanation = textBox_Explanation.Text.ToString();
                    result.Explanation = richTextBox_Explanation.Text.ToString();


                    collection.Save(result);
                    MessageBox.Show("Entry updated in DB!!");

                }

                else
                {
                    // sonuc null. yani database e daha once boyle bir veri girilmemis ya da geceresiz bir ID girilmis
                    // yeni veri olustur ve gir.

                    JobApplicationInfoCls newEntry = new JobApplicationInfoCls
                    {
                        // ID = ObjectId.GenerateNewId(),
                        HiringManagerName = textBoxHiringManagerName.Text,
                        HiringManagerContactInfo = textBox_HiringManagerContactInfo.Text,
                        HiringManagerGender = comboBoxGender.Text,
                        CompanyName = textBoxCompanyName.Text,

                        Position = textBoxPosition.Text,
                        JobReferenceCode = textBoxJobRefCode.Text,
                        City = textBoxCity.Text,

                        // generatedID = Company + Position + City + Job Ref Code... This must be always unique.
                        //GeneratedID = String.Concat(textBoxCompanyName.ToString(), "_" , textBoxPosition.ToString(), "_", textBoxCity.ToString(), "_", textBoxJobRefCode.ToString() ),
                        ApplicationDate = DateTime.Now.Date,
                        ApplicationDate_Hour = DateTime.Now.Hour,
                        ApplicationDate_Minute = DateTime.Now.Minute,
                        ApplicationDate_Second = DateTime.Now.Second,
                        Salary = Convert.ToUInt32(textBoxSalary.Text), //Int32.Parse(textBoxSalary.Text),
                        SalaryMax = Convert.ToUInt32(textBoxSalaryMax.Text),
                        SalaryMin = Convert.ToUInt32(textBoxSalaryMin.Text),
                        IsResponseGiven = Convert.ToBoolean(comboBoxIsResponseGiven.Text.ToString()), //comboBoxIsResponseGiven.Text,
                        IsResponsePositive = Convert.ToBoolean(comboBoxIsResponsePositive.Text.ToString()),
                        IsApplied = Convert.ToBoolean(comboBox_IsBeenApplied.Text.ToString()),
                        CoverLetterSent = Convert.ToBoolean(comboBox_CoverLetterSent.Text.ToString()),
                        JobFindingPlatform = comboBox_JobFindPlatform.Text.ToString(),
                        JobType = textBox_JobType.Text.ToString(),
                        Explanation = richTextBox_Explanation.Text.ToString(),




                };

                    collection.Save(newEntry);
                    MessageBox.Show("Written to DB!!");
                }





            }
            else
            {
                MessageBox.Show("First, Connect to a DATABASE");
            }


            

        }

        private void button_Bring_Click(object sender, EventArgs e)
        {


            if (IsConnectedToDB == false)
            {
                // no connection with database, first connect

                if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                {

                    nameOfTheDB = textBox_NameOfTheDB.Text;
                    nameOfTheCollection = textBox_NameOfTheCollection.Text;


                    server = client.GetServer();
                    dataBase = server.GetDatabase(nameOfTheDB);
                    collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                    // delete cached culture info so that current local time is fetched correctly. 
                    System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                    IsConnectedToDB = true;

                }
                else
                {
                    MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                }


            }





            //  before bringing elements from db, refresh collection. Since new elements might have been added to db
            collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

            //var query = Query.And(

            //    Query.EQ("City", "Waterloo"),
            //    Query.EQ("Company", "Google")
            //    );


            #region            Customized queries go here...

            // Filters CompanyName and City
           // var x = collection.AsQueryable().Where(b => b.CompanyName.Contains("Google") && b.City.Contains("Waterloo"));


            //// get all the jobs whose salaries are bigger than 40 K
            var x = collection.AsQueryable().Where(b => b.Salary > 40000);

            //// finds the job gives the minimum salary. Orderby orders the collection in ascending order
            //var x = collection.AsQueryable().OrderBy(b => b.Salary).First();

            //// finds the job gives the maximum salary. Orderby orders the collection in ascending order
            //var x = collection.AsQueryable().OrderBy(b => b.Salary).Last();

            //// Find a particular entry
            //var x = collection.AsQueryable().Single(b => b.CompanyName == "Google");



            #endregion




            //// open new form to display all the items
            //QueryResultForm newForm = new QueryResultForm(x);
            QueryResultForm newForm = new QueryResultForm(x);
            newForm.ShowDialog();
            //newForm.ShowDialog();

            //// first clear the previous selection of combobox es
            comboBoxGender.SelectedIndex = -1;
            comboBoxIsResponseGiven.SelectedIndex = -1;
            comboBoxIsResponsePositive.SelectedIndex = -1;
            comboBox_IsBeenApplied.SelectedIndex = -1;
            comboBox_JobFindPlatform.SelectedIndex = -1;
            comboBox_CoverLetterSent.SelectedIndex = -1;

            comboBoxGender.ResetText();
            comboBoxIsResponseGiven.ResetText();
            comboBoxIsResponsePositive.ResetText();
            comboBox_IsBeenApplied.ResetText();
            comboBox_JobFindPlatform.ResetText();
            comboBox_CoverLetterSent.ResetText();

            

            textBoxHiringManagerName.Text = newForm.CurrentEntity.HiringManagerName;
            textBox_HiringManagerContactInfo.Text = newForm.CurrentEntity.HiringManagerContactInfo;
            comboBoxGender.SelectedText = newForm.CurrentEntity.HiringManagerGender;
            textBoxCompanyName.Text = newForm.CurrentEntity.CompanyName;
            textBoxPosition.Text = newForm.CurrentEntity.Position;
            textBoxJobRefCode.Text = newForm.CurrentEntity.JobReferenceCode;
            textBoxCity.Text = newForm.CurrentEntity.City;
            textBoxSalary.Text = newForm.CurrentEntity.Salary.ToString();
            textBoxSalaryMax.Text = newForm.CurrentEntity.SalaryMax.ToString();
            textBoxSalaryMin.Text = newForm.CurrentEntity.SalaryMin.ToString();
            comboBoxIsResponseGiven.SelectedText = newForm.CurrentEntity.IsResponseGiven.ToString();
            comboBoxIsResponsePositive.SelectedText = newForm.CurrentEntity.IsResponsePositive.ToString();
            comboBox_IsBeenApplied.SelectedText = newForm.CurrentEntity.IsApplied.ToString();
            comboBox_JobFindPlatform.SelectedText = newForm.CurrentEntity.JobFindingPlatform;
            comboBox_CoverLetterSent.SelectedText = newForm.CurrentEntity.CoverLetterSent.ToString();
            textBox_IDofTheEntity.Text = newForm.CurrentEntity.ID.ToString();




















            //#region deneme alani

            //if (IsConnectedToDB == false)
            //{
            //    // no connection with database, first connect

            //    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
            //    {

            //        nameOfTheDB = textBox_NameOfTheDB.Text;
            //        nameOfTheCollection = textBox_NameOfTheCollection.Text;


            //        server = client.GetServer();
            //        dataBase = server.GetDatabase(nameOfTheDB);
            //        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

            //        // delete cached culture info so that current local time is fetched correctly. 
            //        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
            //        IsConnectedToDB = true;

            //    }
            //    else
            //    {
            //        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
            //    }


            //}





            ////  before bringing elements from db, refresh collection. Since new elements might have been added to db
            //collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

            //var x = collection.AsQueryable().Where(b => b.CompanyName.StartsWith("Google"));

            //// open new form to display all the items
            //QueryResultForm newForm = new QueryResultForm(x);
            //newForm.ShowDialog();



            //// first clear the previous selection of combobox es
            //comboBoxGender.SelectedIndex = -1;
            //comboBoxIsResponseGiven.SelectedIndex = -1;
            //comboBoxIsResponsePositive.SelectedIndex = -1;
            //comboBox_IsBeenApplied.SelectedIndex = -1;
            //comboBox_JobFindPlatform.SelectedIndex = -1;

            //textBoxHiringManagerName.Text = newForm.CurrentEntity.HiringManagerName;
            //textBox_HiringManagerContactInfo.Text = newForm.CurrentEntity.HiringManagerContactInfo;
            //comboBoxGender.SelectedText = newForm.CurrentEntity.HiringManagerGender;
            //textBoxCompanyName.Text = newForm.CurrentEntity.CompanyName;
            //textBoxPosition.Text = newForm.CurrentEntity.Position;
            //textBoxJobRefCode.Text = newForm.CurrentEntity.JobReferenceCode;
            //textBoxCity.Text = newForm.CurrentEntity.City;
            //textBoxSalary.Text = newForm.CurrentEntity.Salary.ToString();
            //textBoxSalaryMax.Text = newForm.CurrentEntity.SalaryMax.ToString();
            //textBoxSalaryMin.Text = newForm.CurrentEntity.SalaryMin.ToString();
            //comboBoxIsResponseGiven.SelectedText = newForm.CurrentEntity.IsResponseGiven.ToString();
            //comboBoxIsResponsePositive.SelectedText = newForm.CurrentEntity.IsResponsePositive.ToString();
            //comboBox_IsBeenApplied.SelectedText = newForm.CurrentEntity.IsApplied.ToString();
            //comboBox_JobFindPlatform.SelectedText = newForm.CurrentEntity.JobFindingPlatform;
            //textBox_IDofTheEntity.Text = newForm.CurrentEntity.ID.ToString();


            //#endregion    

        }

        private void button_bringByID_Click(object sender, EventArgs e)
        {
            if (textBox_IDofTheEntity.Text != null && textBox_IDofTheEntity.Text != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }



                if (collection != null)
                {


                    string IDofTheCurrentEntity = textBox_IDofTheEntity.Text;
                    var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheCurrentEntity));
                    var result = collection.FindOne(queryID);

                    if (result != null)
                    {

                        // first clear the previous selection of combobox es
                        clearComboBoxes();

                        textBoxHiringManagerName.Text = result.HiringManagerName;
                        textBox_HiringManagerContactInfo.Text = result.HiringManagerContactInfo;
                        comboBoxGender.SelectedText = result.HiringManagerGender;
                        textBoxCompanyName.Text = result.CompanyName;
                        textBoxPosition.Text = result.Position;
                        textBoxJobRefCode.Text = result.JobReferenceCode;
                        textBoxCity.Text = result.City;
                        textBoxSalary.Text = result.Salary.ToString();
                        textBoxSalaryMax.Text = result.SalaryMax.ToString();
                        textBoxSalaryMin.Text = result.SalaryMin.ToString();
                        comboBoxIsResponseGiven.SelectedText = result.IsResponseGiven.ToString();
                        comboBoxIsResponsePositive.SelectedText = result.IsResponsePositive.ToString();
                        comboBox_IsBeenApplied.SelectedText = result.IsApplied.ToString();
                        comboBox_JobFindPlatform.SelectedText = result.JobFindingPlatform;
                        textBox_IDofTheEntity.Text = result.ID.ToString();

                    }
                    else
                    {
                        MessageBox.Show("No entity found with ID  " + textBox_IDofTheEntity.Text);
                    }
                }



            }
            else
            {
                MessageBox.Show("Please enter a valid DB item ID!!!");
            }



        }

        private void button_DeleteByID_Click(object sender, EventArgs e)
        {

            if (IsConnectedToDB == false)
            {
                // no connection with database, first connect

                if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                {

                    nameOfTheDB = textBox_NameOfTheDB.Text;
                    nameOfTheCollection = textBox_NameOfTheCollection.Text;


                    server = client.GetServer();
                    dataBase = server.GetDatabase(nameOfTheDB);
                    collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                    // delete cached culture info so that current local time is fetched correctly. 
                    System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                    IsConnectedToDB = true;

                }
                else
                {
                    MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                }


            }

            JobApplicationInfoCls result = null;

            if (collection != null)
            {


                string IDofTheCurrentEntity = textBox_IDofTheEntity.Text;
                ObjectId newObjectID;
                bool IsValidObjectID = ObjectId.TryParse(IDofTheCurrentEntity, out newObjectID);

                if (IsValidObjectID)
                {
                    var queryID = Query.EQ("_id", newObjectID);
                    result = collection.FindOne(queryID);

                    if (result != null)
                    {
                        // database de bu ID li eleman bulundu. Kullanicaya sor ve sil.

                        // Kullaniciya sor

                        DialogResult dialogResult = MessageBox.Show("Are you sure to delete the entity  " + textBox_IDofTheEntity.Text, "Sure?", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            //Sil

                            collection.Remove(queryID);
                            MessageBox.Show("Deleted from DB!!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Not deleted since you are not sure");

                        }




                    }
                    else
                    {
                        // database de bu ID li eleman bulunamadi.

                        MessageBox.Show("No entity found with this ID!");

                    }


                }
                else
                {
                    MessageBox.Show("Invalid ID! Please enter a valid ID");
                }










            }
            else
            {
                MessageBox.Show("First, Connect to a DATABASE");
            }




        }

       

        private void textBox_NameOfTheDB_TextChanged(object sender, EventArgs e)
        {
            IsConnectedToDB = false;
            collection = null;
        }

        private void textBox_NameOfTheCollection_TextChanged(object sender, EventArgs e)
        {
            IsConnectedToDB = false;
            collection = null;
            
        }



        private void buttonBringByCompanyName_Click(object sender, EventArgs e)
        {

            if (textBoxCompanyName.Text != null && textBoxCompanyName.Text != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }

                //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                var companyName = textBoxCompanyName.Text;

                
                    var x = collection.AsQueryable().Where(c => c.CompanyName.Contains(companyName));

                    if (x.Count() != 0)
                    {
                        QueryResultForm newForm = new QueryResultForm(x);
                        newForm.ShowDialog();

                        if (newForm.DialogResult == DialogResult.OK)
                        {
                            //// first clear the previous selection of combobox es
                            clearComboBoxes();

                            setResultOfTheQuery(newForm);

                        }
                        else if (newForm.DialogResult == DialogResult.Cancel)
                        {
                            // Do nothing!
                        }

                    }
                    else
                    {
                        MessageBox.Show("No Query Result!!");
                    }


                

            }
            else
            {
                MessageBox.Show("Please enter a valid Company name!!!");
            }

        }

        private void button_BringByCity_Click(object sender, EventArgs e)
        {
            if (TextBoxCity != null && TextBoxCity != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }

                //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                var cityName = TextBoxCity;


                var x = collection.AsQueryable().Where(c => c.City.Contains(cityName));

                if (x.Count() != 0)
                {
                    QueryResultForm newForm = new QueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        //// first clear the previous selection of combobox es
                        clearComboBoxes();

                        setResultOfTheQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");

                }










            }
            else
            {
                MessageBox.Show("Please enter a valid City name!!!");
            }

        }

        private void setResultOfTheQuery(QueryResultForm newForm)
        {
            textBoxHiringManagerName.Text = newForm.CurrentEntity.HiringManagerName;
            textBox_HiringManagerContactInfo.Text = newForm.CurrentEntity.HiringManagerContactInfo;
            comboBoxGender.SelectedText = newForm.CurrentEntity.HiringManagerGender;
            textBoxCompanyName.Text = newForm.CurrentEntity.CompanyName;
            textBoxPosition.Text = newForm.CurrentEntity.Position;
            textBoxJobRefCode.Text = newForm.CurrentEntity.JobReferenceCode;
            textBoxCity.Text = newForm.CurrentEntity.City;
            textBoxSalary.Text = newForm.CurrentEntity.Salary.ToString();
            textBoxSalaryMax.Text = newForm.CurrentEntity.SalaryMax.ToString();
            textBoxSalaryMin.Text = newForm.CurrentEntity.SalaryMin.ToString();
            comboBoxIsResponseGiven.SelectedText = newForm.CurrentEntity.IsResponseGiven.ToString();
            comboBoxIsResponsePositive.SelectedText = newForm.CurrentEntity.IsResponsePositive.ToString();
            comboBox_IsBeenApplied.SelectedText = newForm.CurrentEntity.IsApplied.ToString();
            comboBox_JobFindPlatform.SelectedText = newForm.CurrentEntity.JobFindingPlatform;
            comboBox_CoverLetterSent.SelectedText = newForm.CurrentEntity.CoverLetterSent.ToString();
            textBox_IDofTheEntity.Text = newForm.CurrentEntity.ID.ToString();


            // sonradan eklenen alanlar, once eklenen JSON nesnelerinde NULL olabilir. null check yapmak gerek
            if (newForm.CurrentEntity.JobType != null)
            {
                textBox_JobType.Text = newForm.CurrentEntity.JobType.ToString();

            }

            if (newForm.CurrentEntity.Explanation != null)
            {
                richTextBox_Explanation.Text = newForm.CurrentEntity.Explanation.ToString();

            }
            
            
        }

        private void setResultOfContactListQuery(ContactListQueryResultForm newForm)
        {
            textBox_CLM_IDofEntity.Text = newForm.CurrentEntity.ID.ToString();
            textBox_CLM_FirstName.Text = newForm.CurrentEntity.FirstName;
            textBox_CLM_LastName.Text = newForm.CurrentEntity.LastName;
            comboBox_CLM_Gender.Text = newForm.CurrentEntity.Gender;
            textBox_CLM_Position.Text = newForm.CurrentEntity.PositionName;
            textBox_CLM_Company.Text = newForm.CurrentEntity.CompanyName;
            textBox_CLM_Email.Text = newForm.CurrentEntity.Email;
            textBox_CLM_Phone.Text = newForm.CurrentEntity.Phone;
            textBox_CLM_Address.Text = newForm.CurrentEntity.Address;
            textBox_CLM_City.Text = newForm.CurrentEntity.City;
            textBox_CLM_FirstContactedDate.Text = newForm.CurrentEntity.FirstCantactedDate;
            textBox_CLM_LastContactedDate.Text = newForm.CurrentEntity.LastContactedDate;
            richTextBox_CLM_Notes.Text = newForm.CurrentEntity.NotesAboutContact;

        }

        private void button_BringByPosition_Click(object sender, EventArgs e)
        {
            if (TextBoxPosition != null && TextBoxPosition != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }

                //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                var positionName = TextBoxPosition;


                var x = collection.AsQueryable().Where(a => a.Position.Contains(positionName));

                if (x.Count() != 0)
                {
                    QueryResultForm newForm = new QueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        //// first clear the previous selection of combobox es
                        clearComboBoxes();

                        setResultOfTheQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");

                }








            }
            else
            {
                MessageBox.Show("Please enter a valid Position name!!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            Process[] islemler = Process.GetProcesses();

            foreach (Process islemadi in islemler)
            {

                if (islemadi.ProcessName == "WINWORD")
                {
                    islemadi.Kill();
                   
                    
                    break;
                }
            }

        }

        private void button_CheckAll_Click(object sender, EventArgs e)
        {
            checkBoxIntroduction.Checked = true;
            checkBoxEducation.Checked = true;
            checkBox_OOP.Checked = true;
            checkBox_SDLC.Checked = true;
            checkBox_BScDegree.Checked = true;
            checkBox_MScDegree.Checked = true;
            checkBox_Database.Checked = true;
            checkBox_DriverLicense.Checked = true;
            checkBox_LanguageSkills.Checked = true;
            checkBox_MacOSExperience.Checked = true;
            checkBox_ScriptingLanguages.Checked = true;
            checkBox_VersionControl.Checked = true;
            checkBox_TestAutomation.Checked = true;
            checkBox_IntegrationTesting.Checked = true;
            checkBox_UnitTesting.Checked = true;
            checkBox_DICOM.Checked = true;
            checkBox_Jenkins.Checked = true;
            checkBox_BugTrackingTools.Checked = true;




            checkBoxConclusion.Checked = true;
        }

        private void button_UncheckAll_Click(object sender, EventArgs e)
        {
            checkBoxIntroduction.Checked = false;
            checkBoxEducation.Checked = false;
            checkBox_OOP.Checked = false;
            checkBox_SDLC.Checked = false;
            checkBox_BScDegree.Checked = false;
            checkBox_MScDegree.Checked = false;
            checkBox_Database.Checked = false;
            checkBox_DriverLicense.Checked = false;
            checkBox_LanguageSkills.Checked = false;
            checkBox_MacOSExperience.Checked = false;
            checkBox_ScriptingLanguages.Checked = false;
            checkBox_VersionControl.Checked = false;
            checkBox_TestAutomation.Checked = false;
            checkBox_IntegrationTesting.Checked = false;
            checkBox_UnitTesting.Checked = false;
            checkBox_DICOM.Checked = false;
            checkBox_Jenkins.Checked = false;
            checkBox_BugTrackingTools.Checked = false;





            checkBoxConclusion.Checked = false;
        }

        private void button_BringByJobRefCode_Click(object sender, EventArgs e)
        {
            if (TextBoxJobRefCode != null && TextBoxJobRefCode != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }

                //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                var jobRefCode = TextBoxJobRefCode;


                var x = collection.AsQueryable().Where(b => b.JobReferenceCode.Contains(jobRefCode));

                if (x.Count() != 0)
                {
                    QueryResultForm newForm = new QueryResultForm(x);
                    newForm.ShowDialog();


                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        //// first clear the previous selection of combobox es
                        clearComboBoxes();

                        setResultOfTheQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");

                }

                


            }
            else
            {
                MessageBox.Show("Please enter a valid City name!!!");
            }

        }

        private void button_BringByResponseGiven_Click(object sender, EventArgs e)
        {

           

            if (ComboBoxIsResponseGiven != null && ComboBoxIsResponseGiven != "")
            {


                if (IsConnectedToDB == false)
                {
                    // no connection with database, first connect

                    if (textBox_NameOfTheDB.Text != "" && textBox_NameOfTheCollection.Text != "")
                    {

                        nameOfTheDB = textBox_NameOfTheDB.Text;
                        nameOfTheCollection = textBox_NameOfTheCollection.Text;


                        server = client.GetServer();
                        dataBase = server.GetDatabase(nameOfTheDB);
                        collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                        // delete cached culture info so that current local time is fetched correctly. 
                        System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                        IsConnectedToDB = true;

                    }
                    else
                    {
                        MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    }


                }

                //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                collection = dataBase.GetCollection<JobApplicationInfoCls>(nameOfTheCollection);

                //var isResponseGiven = ComboBoxIsResponseGiven.
                var isResponseGiven = Boolean.Parse(ComboBoxIsResponseGiven);

                IQueryable<JobApplicationInfoCls> x = null;

                if (isResponseGiven == true || isResponseGiven == false)
                {
                    x = collection.AsQueryable().Where(b => b.IsResponseGiven == isResponseGiven);

                }
                

                if (x.Count() != 0)
                {
                    QueryResultForm newForm = new QueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        //// first clear the previous selection of combobox es
                        clearComboBoxes();

                        setResultOfTheQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }



                }
                else
                {
                    MessageBox.Show("No Query Result!!");


                }




            }
            else
            {
                MessageBox.Show("Please enter a valid RESPONSE (i.e. TRUE/FALSE)!!!");
            }
        }

        private void button_Statistics_Click(object sender, EventArgs e)
        {

        }

        

        private string getCurrentDate()
        {
            string currentDate = "";    // date format is YYYYmmDD

            var date = System.DateTime.Now.Date.ToString();

            var splittedDate = date.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var newSplittedDate = splittedDate[0].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            currentDate = String.Concat(newSplittedDate[2], "/", newSplittedDate[0], "/", newSplittedDate[1]);


            return currentDate;
        }

        private void button_CLM_WriteDB_Click_1(object sender, EventArgs e)
        {
            
            if (IsConnectedToDB_CLM == false)
            {
                // no connection with database, first connect

                if (textBox_CLM_DBname.Text != "" && textBox_CLM_CollectionName.Text != "")
                {

                    nameOfTheDB_CLM = textBox_CLM_DBname.Text;
                    nameOfTheCollection_CLM = textBox_CLM_CollectionName.Text;


                    server_CLM = CLM_MongoClient.GetServer();
                    dataBase_CLM = server_CLM.GetDatabase(nameOfTheDB_CLM);
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);

                    // delete cached culture info so that current local time is fetched correctly. 
                    System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                    IsConnectedToDB_CLM = true;

                }
                else
                {
                    MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                }


            }

            ContactListCls result = null;

            if (CLM_collection != null)
            {


                string IDofTheCurrentEntity = textBox_CLM_IDofEntity.Text;
                ObjectId newObjectID;
                bool IsValidObjectID = ObjectId.TryParse(IDofTheCurrentEntity, out newObjectID);

                if (IsValidObjectID)
                {
                    var queryID = Query.EQ("_id", newObjectID);
                    result = CLM_collection.FindOne(queryID);

                }



                if (IsValidObjectID == true && result != null)
                {
                    // daha once database e girilmis, update et
                    // result i mevcut UI verilerine gore update et ve db ye yaz.


                    result.FirstName = textBox_CLM_FirstName.Text;
                    result.LastName = textBox_CLM_LastName.Text;
                    result.Gender = comboBox_CLM_Gender.Text;
                    result.PositionName = textBox_CLM_Position.Text;
                    result.CompanyName = textBox_CLM_Company.Text;
                    result.Email = textBox_CLM_Email.Text;
                    result.Phone = textBox_CLM_Phone.Text;
                    result.Address = textBox_CLM_Address.Text;
                    result.City = textBox_CLM_City.Text;
                    // First contacted date will not be updated, when entry is updated
                    result.LastContactedDate = textBox_CLM_LastContactedDate.Text;
                    result.NotesAboutContact = richTextBox_CLM_Notes.Text.ToString();




                    CLM_collection.Save(result);
                    MessageBox.Show("Entry updated in DB!!");

                }

                else
                {
                    // sonuc null. yani database e daha once boyle bir veri girilmemis ya da geceresiz bir ID girilmis
                    // yeni veri olustur ve gir.

                    ContactListCls newEntry = new ContactListCls
                    {


                        FirstName = textBox_CLM_FirstName.Text,
                        LastName = textBox_CLM_LastName.Text,
                        Gender = comboBox_CLM_Gender.Text,
                        PositionName = textBox_CLM_Position.Text,
                        CompanyName = textBox_CLM_Company.Text,
                        Email = textBox_CLM_Email.Text,
                        Phone = textBox_CLM_Phone.Text,
                        Address = textBox_CLM_Address.Text,
                        City = textBox_CLM_City.Text,
                        FirstCantactedDate = getCurrentDate(),
                        LastContactedDate = textBox_CLM_LastContactedDate.Text,
                        NotesAboutContact = richTextBox_CLM_Notes.Text.ToString(),



                    };

                    CLM_collection.Save(newEntry);
                    MessageBox.Show("Written to DB!!");
                }





            }
            else
            {
                MessageBox.Show("First, Connect to a DATABASE");
            }




        
    }


        bool connectToCLMDatabase()
        {
            if (IsConnectedToDB_CLM == false)
            {
                // no connection with database, first connect

                if (textBox_CLM_DBname.Text != "" && textBox_CLM_CollectionName.Text != "")
                {

                    nameOfTheDB_CLM = textBox_CLM_DBname.Text;
                    nameOfTheCollection_CLM = textBox_CLM_CollectionName.Text;


                    server_CLM = CLM_MongoClient.GetServer();
                    dataBase_CLM = server_CLM.GetDatabase(nameOfTheDB_CLM);
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);

                    // delete cached culture info so that current local time is fetched correctly. 
                    System.Globalization.CultureInfo.CurrentCulture.ClearCachedData();
                    IsConnectedToDB_CLM = true;

                }
                else
                {
                    MessageBox.Show("Name of the DB or Collection was not entered. Please enter the DB and Collection name!");
                    IsConnectedToDB_CLM = false;

                }
            }


            return IsConnectedToDB_CLM;
        }


        private void button_CLM_BringByCompany_Click(object sender, EventArgs e)
        {
            if (textBox_CLM_Company.Text != null && textBox_CLM_Company.Text != "")
            {

                if (connectToCLMDatabase())
                {
                    //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);
                }
                
                

                var companyName = textBox_CLM_Company.Text;


                var x = CLM_collection.AsQueryable().Where(c => c.CompanyName.Contains(companyName));

                if (x.Count() != 0)
                {

                    ContactListQueryResultForm newForm = new ContactListQueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        //// first clear the previous selection of combobox es
                        clearComboBoxes();

                        setResultOfContactListQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");
                }


                


            }
            else
            {
                MessageBox.Show("Please enter a valid Company name!!!");
            }
        }

        private void button_CLM_BringByFirstName_Click(object sender, EventArgs e)
        {
            if (textBox_CLM_FirstName.Text != null && textBox_CLM_FirstName.Text != "")
            {

                // Connect to database
                if (connectToCLMDatabase())
                {
                    //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);
                }



                var firstName = textBox_CLM_FirstName.Text;


                var x = CLM_collection.AsQueryable().Where(c => c.FirstName.Contains(firstName));

                if (x.Count() != 0)
                {

                    ContactListQueryResultForm newForm = new ContactListQueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {
                        
                        setResultOfContactListQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");
                }





            }
            else
            {
                MessageBox.Show("Please enter a valid First name!!!");
            }
        }

        private void button_CLM_BringByLastName_Click(object sender, EventArgs e)
        {
            if (textBox_CLM_LastName.Text != null && textBox_CLM_LastName.Text != "")
            {

                // Connect to database
                if (connectToCLMDatabase())
                {
                    //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);
                }



                var lastName = textBox_CLM_LastName.Text;


                var x = CLM_collection.AsQueryable().Where(c => c.LastName.Contains(lastName));

                if (x.Count() != 0)
                {

                    ContactListQueryResultForm newForm = new ContactListQueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {

                        setResultOfContactListQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");
                }





            }
            else
            {
                MessageBox.Show("Please enter a valid Last name!!!");
            }
        }

        private void button_CLM_BringByCity_Click(object sender, EventArgs e)
        {
            if (textBox_CLM_City.Text != null && textBox_CLM_City.Text != "")
            {

                // Connect to database
                if (connectToCLMDatabase())
                {
                    //  before bringing elements from db, refresh collection. Since new elements might have been added to db
                    CLM_collection = dataBase_CLM.GetCollection<ContactListCls>(nameOfTheCollection_CLM);
                }



                var cityName = textBox_CLM_City.Text;


                var x = CLM_collection.AsQueryable().Where(c => c.City.Contains(cityName));

                if (x.Count() != 0)
                {

                    ContactListQueryResultForm newForm = new ContactListQueryResultForm(x);
                    newForm.ShowDialog();

                    if (newForm.DialogResult == DialogResult.OK)
                    {

                        setResultOfContactListQuery(newForm);

                    }
                    else if (newForm.DialogResult == DialogResult.Cancel)
                    {
                        // Do nothing!
                    }

                }
                else
                {
                    MessageBox.Show("No Query Result!!");
                }





            }
            else
            {
                MessageBox.Show("Please enter a valid City name!!!");
            }
        }

        private void textBoxCompanyName_TextChanged(object sender, EventArgs e)
        {
            textBox_CLM_Company.Text = textBoxCompanyName.Text;
        }

        private void textBox_HiringManagerContactInfo_TextChanged(object sender, EventArgs e)
        {
            textBox_CLM_Email.Text = textBox_HiringManagerContactInfo.Text;
            textBox_CLM_Phone.Text = textBox_HiringManagerContactInfo.Text;
        }

        private void textBoxHiringManagerName_TextChanged(object sender, EventArgs e)
        {
            textBox_CLM_FirstName.Text = textBoxHiringManagerName.Text;
            textBox_CLM_LastName.Text = textBoxHiringManagerName.Text;
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_CLM_Gender.Text = comboBoxGender.Text;
        }

        private void textBoxCity_TextChanged(object sender, EventArgs e)
        {
            textBox_CLM_City.Text = textBoxCity.Text;
        }

        private void button_CLM_Clear_Click(object sender, EventArgs e)
        {
            textBox_CLM_IDofEntity.Clear();
            textBox_CLM_FirstName.Clear();
            textBox_CLM_LastName.Clear();
            comboBox_CLM_Gender.Text = "";
            textBox_CLM_Position.Clear();
            textBox_CLM_Company.Clear();
            textBox_CLM_Email.Clear();
            textBox_CLM_Phone.Clear();
            textBox_CLM_Address.Clear();
            textBox_CLM_City.Clear();
            textBox_CLM_FirstContactedDate.Clear();
            textBox_CLM_LastContactedDate.Clear();
            richTextBox_CLM_Notes.Clear();
        }
    }



    public class JobApplicationInfoCls
    {
        [BsonId]
        public ObjectId ID { get; set; }
        //public string GeneratedID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string JobReferenceCode { get; set; }
        public int ApplicationDate_Hour { get; set; }
        public int ApplicationDate_Minute { get; set; }
        public int ApplicationDate_Second { get; set; }
        public DateTime ApplicationDate { get; set; }
        public UInt32 SalaryMax { get; set; }
        public UInt32 SalaryMin { get; set; }
        public UInt32 Salary { get; set; }
        public string HiringManagerName { get; set; }
        public string HiringManagerContactInfo { get; set; }
        public string HiringManagerGender { get; set; }
        public bool IsApplied { get; set; }
        public bool IsResponseGiven { get; set; }
        public bool IsResponsePositive { get; set; }
        public bool CoverLetterSent { get; set; }
        public string JobFindingPlatform { get; set; }
        public string JobType { get; set; }
        public string Explanation { get; set; }

    }

    public class ContactListCls
    {
        [BsonId]
        public ObjectId ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        // Convention for date: YYYYmmDD
        public string FirstCantactedDate { get; set; }
        public string  LastContactedDate { get; set; }
        public string NotesAboutContact { get; set; }



    }



}

