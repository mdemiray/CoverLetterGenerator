using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;  // for query

namespace CoverLetterGenerator
{
    public partial class ContactListQueryResultForm : Form
    {
        public ContactListQueryResultForm()
        {
            InitializeComponent();
        }


        private IQueryable<ContactListCls> x;
        List<string> resultList = new List<string>();
        int counter = 0;

        private ContactListCls currentEntity;
        //private IMongoQuery query;
        //private JobApplicationInfoCls x_2;

        public ContactListCls CurrentEntity
        {
            get
            {
                return currentEntity;
            }
        }






        // constructor
        public ContactListQueryResultForm(IQueryable<ContactListCls> x)
        {
            InitializeComponent();

            this.x = x;
            var liste = x.ToList();

            foreach (var item in liste)
            {
                resultList.Add(item.ID.ToString());

            }

            label_CLM_ItemCount.Text = resultList.Count.ToString();
            listBox_CLM_QueryResults.DataSource = resultList;

            // Initialize datagrid view
            string IDofTheSelectedObject = listBox_CLM_QueryResults.SelectedItem.ToString();
            var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
            currentEntity = Form1.Collection_CLM.FindOne(queryID);



            int n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Entity ID";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.ID;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "First Name";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.FirstName;


            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Last Name";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.LastName;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Gender";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.Gender;


            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Position";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.PositionName;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Company";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.CompanyName;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Email";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.Email;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Phone";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.Phone;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Address";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.Address;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "City";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.City;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "First Contacted Date";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.FirstCantactedDate;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Last Contacted Date";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.LastContactedDate;

            n = dataGridView_CLM.Rows.Add();
            dataGridView_CLM.Rows[n].Cells[0].Value = "Notes";
            dataGridView_CLM.Rows[n].Cells[1].Value = currentEntity.NotesAboutContact;


            counter++;

            

        }

        private void listBox_CLM_QueryResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // constructor calismadan once , yani datagridview ilklendirilmeden once burasi calismasin diye counter koyuldu.
            //counter, constructor 1 kere calistiktan sonra 1 oluyor.

            if (counter != 0)
            {
                // form the datagrid view accordingly


                string IDofTheSelectedObject = listBox_CLM_QueryResults.SelectedItem.ToString();
                //var selectedObject = x.AsQueryable().Where(b=> b.ID.ToString() == IDofTheSelectedObject);

                var queryID = Query.EQ("_id", ObjectId.Parse(IDofTheSelectedObject));
                currentEntity = Form1.Collection_CLM.FindOne(queryID);
                //var a = entity.ToString();



                dataGridView_CLM.Rows[0].Cells[1].Value = currentEntity.ID;
                dataGridView_CLM.Rows[1].Cells[1].Value = currentEntity.FirstName;
                dataGridView_CLM.Rows[2].Cells[1].Value = currentEntity.LastName;
                dataGridView_CLM.Rows[3].Cells[1].Value = currentEntity.Gender;
                dataGridView_CLM.Rows[4].Cells[1].Value = currentEntity.PositionName;
                dataGridView_CLM.Rows[5].Cells[1].Value = currentEntity.CompanyName;
                dataGridView_CLM.Rows[6].Cells[1].Value = currentEntity.Email;
                dataGridView_CLM.Rows[7].Cells[1].Value = currentEntity.Phone;
                dataGridView_CLM.Rows[8].Cells[1].Value = currentEntity.Address;
                dataGridView_CLM.Rows[9].Cells[1].Value = currentEntity.City;
                dataGridView_CLM.Rows[10].Cells[1].Value = currentEntity.FirstCantactedDate;
                dataGridView_CLM.Rows[11].Cells[1].Value = currentEntity.LastContactedDate;
                dataGridView_CLM.Rows[12].Cells[1].Value = currentEntity.NotesAboutContact;
               
                

            }
        }

        private void button_CLM_Bring_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
