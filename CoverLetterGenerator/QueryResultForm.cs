using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;  // for query
//using MongoDB.Driver.GridFS;



namespace CoverLetterGenerator
{
    public partial class QueryResultForm : Form
    {
        private IQueryable<JobApplicationInfoCls> x;
        List<string> resultList = new List<string>();
        

        public QueryResultForm()
        {
            InitializeComponent();
        }

        int counter = 0;

        public QueryResultForm(IQueryable<JobApplicationInfoCls> x)
        {

            InitializeComponent();

            // TODO: Complete member initialization
            this.x = x;
            var liste = x.ToList();

            

            foreach (var item in liste)
            {
                resultList.Add(item.ID.ToString());
                
            }

            // show the count items
            label_ItemCount.Text = resultList.Count.ToString();

            listBox_Query_Results.DataSource = resultList;

            //listBox_Query_Results.Items.Add(x.ToString());


            // Initialize datagrid view
            string IDofTheSelectedObject = listBox_Query_Results.SelectedItem.ToString();
            //var selectedObject = x.AsQueryable().Where(b=> b.ID.ToString() == IDofTheSelectedObject);

            var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
            currentEntity = Form1.Collection.FindOne(queryID);
            //var a = entity.ToString();

            int n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Entity ID";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ID;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Company";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.CompanyName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Position";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Position;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Ref Code";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobReferenceCode;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "City";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.City;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Salary;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Max";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMax;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Min";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMin;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Given";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponseGiven;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Positive";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponsePositive;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Been Applied";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsApplied;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Cover Letter Sent?";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.CoverLetterSent;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Find Platform";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobFindingPlatform;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Name";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Contact";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerContactInfo;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Gender";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerGender;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Date";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Hour";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Hour;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Minute";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Minute;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Second";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Second;


            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Type";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobType;


            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Explanation";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Explanation;

            counter++;

        }

        public QueryResultForm(IMongoQuery query)
        {

            InitializeComponent();


            // TODO: Complete member initialization
            this.query = query;


           // var liste = query.



            //foreach (var item in liste)
            //{
            //    resultList.Add(item.ID.ToString());

            //}

            //listBox_Query_Results.DataSource = resultList;



            


            // Initialize datagrid view
            string IDofTheSelectedObject = listBox_Query_Results.SelectedItem.ToString();
            //var selectedObject = x.AsQueryable().Where(b=> b.ID.ToString() == IDofTheSelectedObject);

            var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
            currentEntity = Form1.Collection.FindOne(queryID);
            //var a = entity.ToString();

            int n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Entity ID";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ID;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Company";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.CompanyName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Position";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Position;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Ref Code";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobReferenceCode;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "City";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.City;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Salary;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Max";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMax;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Min";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMin;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Given";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponseGiven;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Positive";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponsePositive;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Been Applied";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsApplied;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Cover Letter Sent?";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.CoverLetterSent;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Find Platform";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobFindingPlatform;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Name";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Contact";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerContactInfo;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Gender";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerGender;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Date";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Hour";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Hour;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Minute";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Minute;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Second";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Second;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Type";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobType;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Explanation";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Explanation;

            

            counter++;
        }

        public QueryResultForm(JobApplicationInfoCls x_2)
        {

            InitializeComponent();

            // TODO: Complete member initialization
            this.x_2 = x_2;



            //var liste = x_2.ToList();



            //foreach (var item in liste)
            //{
            //    resultList.Add(item.ID.ToString());

            //}

            resultList.Add(x_2.ID.ToString());

            listBox_Query_Results.DataSource = resultList;

            //listBox_Query_Results.Items.Add(x.ToString());


            // Initialize datagrid view
            string IDofTheSelectedObject = listBox_Query_Results.SelectedItem.ToString();
            //var selectedObject = x.AsQueryable().Where(b=> b.ID.ToString() == IDofTheSelectedObject);

            var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
            currentEntity = Form1.Collection.FindOne(queryID);
            //var a = entity.ToString();

            int n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Entity ID";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ID;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Company";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.CompanyName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Position";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Position;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Ref Code";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobReferenceCode;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "City";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.City;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Salary;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Max";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMax;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Salary Min";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.SalaryMin;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Given";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponseGiven;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Response Positive";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsResponsePositive;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Is Been Applied";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.IsApplied;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Find Platform";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobFindingPlatform;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Name";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerName;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Contact";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerContactInfo;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Hiring Manager Gender";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.HiringManagerGender;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Date";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Hour";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Hour;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Minute";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Minute;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Application Second";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.ApplicationDate_Second;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Job Type";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.JobType;

            n = dataGridView_SelectedDB_item.Rows.Add();
            dataGridView_SelectedDB_item.Rows[n].Cells[0].Value = "Explanation";
            dataGridView_SelectedDB_item.Rows[n].Cells[1].Value = currentEntity.Explanation;

            counter++;
        }

        private JobApplicationInfoCls currentEntity;
        private IMongoQuery query;
        private JobApplicationInfoCls x_2;

        public JobApplicationInfoCls CurrentEntity
        {
            get
            {
                return currentEntity;
            }
        }



        private void listBox_Query_Results_SelectedIndexChanged(object sender, EventArgs e)
        {

            // constructor calismadan once , yani datagridview ilklendirilmeden once burasi calismasin diye counter koyuldu.
            //counter, constructor 1 kere calistiktan sonra 1 oluyor.

            if (counter != 0)
            {
                // form the datagrid view accordingly


                string IDofTheSelectedObject = listBox_Query_Results.SelectedItem.ToString();
                //var selectedObject = x.AsQueryable().Where(b=> b.ID.ToString() == IDofTheSelectedObject);

                var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
                currentEntity = Form1.Collection.FindOne(queryID);
                //var a = entity.ToString();



                dataGridView_SelectedDB_item.Rows[0].Cells[1].Value = currentEntity.ID;
                dataGridView_SelectedDB_item.Rows[1].Cells[1].Value = currentEntity.CompanyName;
                dataGridView_SelectedDB_item.Rows[2].Cells[1].Value = currentEntity.Position;
                dataGridView_SelectedDB_item.Rows[3].Cells[1].Value = currentEntity.JobReferenceCode;
                dataGridView_SelectedDB_item.Rows[4].Cells[1].Value = currentEntity.City;
                dataGridView_SelectedDB_item.Rows[5].Cells[1].Value = currentEntity.Salary;
                dataGridView_SelectedDB_item.Rows[6].Cells[1].Value = currentEntity.SalaryMax;
                dataGridView_SelectedDB_item.Rows[7].Cells[1].Value = currentEntity.SalaryMin;
                dataGridView_SelectedDB_item.Rows[8].Cells[1].Value = currentEntity.IsResponseGiven;
                dataGridView_SelectedDB_item.Rows[9].Cells[1].Value = currentEntity.IsResponsePositive;
                dataGridView_SelectedDB_item.Rows[10].Cells[1].Value = currentEntity.IsApplied;
                dataGridView_SelectedDB_item.Rows[11].Cells[1].Value = currentEntity.CoverLetterSent;
                dataGridView_SelectedDB_item.Rows[12].Cells[1].Value = currentEntity.JobFindingPlatform;
                dataGridView_SelectedDB_item.Rows[13].Cells[1].Value = currentEntity.HiringManagerName;
                dataGridView_SelectedDB_item.Rows[14].Cells[1].Value = currentEntity.HiringManagerContactInfo;
                dataGridView_SelectedDB_item.Rows[15].Cells[1].Value = currentEntity.HiringManagerGender;
                dataGridView_SelectedDB_item.Rows[16].Cells[1].Value = currentEntity.ApplicationDate;
                dataGridView_SelectedDB_item.Rows[17].Cells[1].Value = currentEntity.ApplicationDate_Hour;
                dataGridView_SelectedDB_item.Rows[18].Cells[1].Value = currentEntity.ApplicationDate_Minute;
                dataGridView_SelectedDB_item.Rows[19].Cells[1].Value = currentEntity.ApplicationDate_Second;
                dataGridView_SelectedDB_item.Rows[20].Cells[1].Value = currentEntity.JobType;
                dataGridView_SelectedDB_item.Rows[21].Cells[1].Value = CurrentEntity.Explanation;
                
            }

            


        }

        private void button_Bring_Click(object sender, EventArgs e)
        {
            
            this.Close();
            this.DialogResult = DialogResult.OK;

            // bu tum formlari kapatiyor
            //Application.Exit();

        }

        
    }
}
