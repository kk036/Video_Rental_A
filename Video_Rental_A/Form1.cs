using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Rental_A
{
    public partial class Form1 : Form
    {
        //global declaration area of variable and object of classes
        String query = "";
        int CustomerID=0, MovieID = 0, RentID = 0, Video_Cost=0,Video_Copy;
        int btnCustomer = 0, btnVideo = 0, btnRent = 0;
        Connection Obj = new Connection();

        //this method id used to clear all the working of the textbox and global variable to reset  the whole task
        public void ClearAll() {
            FirstName.Text = "";
            LastName.Text = "";
            MobileNo.Text = "";
            Address.Text = "";

            CustomerIDTxtBox.Text = "";
            MovieIDTxtBox.Text = "";

            title.Text = "";
            Ratting.Text = "";
            Year.Text = "";
            Cost.Text = "";
            Plot.Text = "";
            Genre.Text = "";
            Copies.Text = "";

            CustomerID = 0;
            MovieID = 0;
            RentID = 0;


        }
        private void delCustomer_Click(object sender, EventArgs e)
        {
            //this method is ued to del the custmer from the customer but the customer record is only deleted when he has no movie on rent 
            if (CustomerID > 0)
            {
                DataTable tblRecord = new DataTable();
                query = "";
                query = "select * from Rental where CustomerID='" + CustomerIDTxtBox.Text.ToString() + "' && ReturnDate='Issued On Rent'";
                tblRecord = Obj.Srch(query);
                if (tblRecord.Rows.Count>0)
                {
                    MessageBox.Show("You already have a movie on rent so return first");
                }
                else
                {
                    //if he has no movie on rent only then his record will be deleted
                    query = "";
                    query = "delete from Customer where id=" + CustomerID + "";
                    Obj.InsDelUpdt(query);
                    MessageBox.Show("Customer Record is Deleted");
                }
                //display the record after deleting the cusotmer
                query = "select * from Customer";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();
            }
            else {
                MessageBox.Show("Please select  the customer from Record to delete ");
            }
        }

        private void updateCustomer_Click(object sender, EventArgs e)
        {
            //this condition is used to update the record of the customer while clicking on the record of the customer
            if (CustomerID > 0 && !FirstName.Text.Equals("") && !LastName.Text.ToString().Equals("") && !MobileNo.Text.Equals("") && !Address.Text.ToString().Equals(""))
            {
                query = "";
                query = "update  Customer set FirstName='"+FirstName.Text.ToString()+"',LastName='"+LastName.Text.ToString()+"',Mobile='"+MobileNo.Text.ToString()+"',Address='"+Address.Text.ToString()+"' where id=" + CustomerID + "";
                Obj.InsDelUpdt(query);
                MessageBox.Show("Customer Record is Updated");
                query = "select * from Customer";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;

            }
            else
            {
                MessageBox.Show("Please select  the customer from Record to Update ");
            }
            //calling the reset method to reset all the text box
            ClearAll();
        }

        private void Year_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dislay the cost of the price of the video after adding the year of the video
                DateTime date = DateTime.Now;

                int year = date.Year;

                int diff = year - Convert.ToInt32(Year.Text.ToString());
                // MessageBox.Show(diff.ToString());
                if (diff >= 5)
                {
                    Cost.Text = "2";
                }
                if (diff >= 0 && diff < 5)
                {
                    Cost.Text = "5";
                }
            }
            catch (Exception ex) {
                    
            }
        }

        private void AddVideo_Click(object sender, EventArgs e)
        {
            // this method is used to add the video details in the table affter filling all the textbox 
            if (!title.Text.ToString().Equals("") && !Ratting.Text.ToString().Equals("") && !Year.Text.ToString().Equals("") && !Copies.Text.ToString().Equals("") && !Plot.Text.ToString().ToString().Equals("") && !Genre.Text.ToString().Equals("")) {
                // insert the query 
                String query = "insert into Video(Title,Ratting,Year,Cost,Copies,Plot,Genre) values('" + title.Text.ToString() + "','" + Ratting.Text.ToString() + "'," + Convert.ToInt32(Year.Text.ToString()) + "," + Convert.ToInt32(Cost.Text.ToString()) + "," + Convert.ToInt32(Copies.Text.ToString()) + ",'" + Plot.Text.ToString() + "','" + Genre.Text.ToString() + "')";
                Obj.InsDelUpdt(query);


                MessageBox.Show("Video Record is Saved");


                query = "select * from Video";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();
            }
        }

        private void delVideo_Click(object sender, EventArgs e)
        {
            /// this method is used to delete the video and remove it only when it is returned by the customer
            if (MovieID>0) {

                String query = "";
                query = "select * from Rental where VideoID='" + MovieIDTxtBox.Text.ToString() + "' && ReturnDate='Issued On Rent'";
                DataTable tblRecord1 = new DataTable();
                tblRecord1 = Obj.Srch(query);
                if (tblRecord1.Rows.Count > 0)
                {
                    MessageBox.Show("Video is Already on rent so canot delete ");
                }
                else
                {


                    query = "delete from Video  where id=" + MovieID + "";
                    Obj.InsDelUpdt(query);
                    MessageBox.Show("Video Record is Deleted");
                }
                query = "select * from Video";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();
            }
        }

        private void updateVideo_Click(object sender, EventArgs e)
        {
            //update the record of the video like ratting plot or genera etc
            if (MovieID>0) {
                string query = "update Video set Title='" + title.Text.ToString() + "',Ratting='" + Ratting.Text.ToString() + "',Year=" + Convert.ToInt32(Year.Text.ToString()) + ",Cost=" + Convert.ToInt32(Cost.Text.ToString()) + ",Copies=" + Convert.ToInt32(Copies.Text.ToString()) + ",Plot='" + Plot.Text.ToString() + "',Genre='" + Genre.Text.ToString() + "' where ID=" + MovieID+ "";
                Obj.InsDelUpdt(query);
                MessageBox.Show("Video Record is Updated");

                query = "select * from Video";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();

            }


        }

        private void rentalIssue_Click(object sender, EventArgs e)
        {
            //this method is used to issue the movie on rent the movie is issued on rent to that customer who has only 1 or 0 movie on rent 
            if (!CustomerIDTxtBox.Text.ToString().Equals("") && !MovieIDTxtBox.Text.ToString().Equals("")) {
                // issue the movie on rent 
                DataTable tblRecord = new DataTable();
                query = "";
                query = "select * from Rental where CustomerID='"+CustomerIDTxtBox.Text.ToString()+ "' and ReturnDate='Issued On Rent'";
                tblRecord = Obj.Srch(query);
                if (tblRecord.Rows.Count < 2)
                {
                    query = "";

                    query = "select * from Rental where VideoID='" + MovieIDTxtBox.Text.ToString() + "' and  ReturnDate='Issued On Rent'";
                    DataTable tblRecord1 = new DataTable();
                    tblRecord1 = Obj.Srch(query);
                    if (tblRecord1.Rows.Count < Video_Copy)
                    {

                        query = "insert into Rental(CustomerID,VideoID,IssueDate,ReturnDate) values('" + CustomerIDTxtBox.Text.ToString() + "','" + MovieIDTxtBox.Text.ToString() + "','" + Issue.Value.Date.ToString() + "','Issued On Rent')";
                        Obj.InsDelUpdt(query);
                        MessageBox.Show("Movie is issued on Rent ");
                    }
                    else {
                        MessageBox.Show("no more videos available");
                    }



                }
                else {
                    MessageBox.Show("You already have 2 movies on rent so return those first ");
                }
                query = "select * from Rental";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();

            }
        }

        private void rentalDelete_Click(object sender, EventArgs e)
        {
            // this is is used to delete the record of that entry which is entered by mistake
            if (RentID > 0)
            {
                query = "";
               
                    query = "delete from Rental where ID=" + RentID + "";
                    Obj.InsDelUpdt(query);
                    MessageBox.Show("Record Is Deleted");
                
                query = "select * from Rental";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();
            }
        }

        private void rentalReturn_Click(object sender, EventArgs e)
        {
            //this method id used to return the movie after the date or before the date 
            if (RentID>0) {


                DateTime Current_date = DateTime.Now;

                //convert the old date from string to Date fromat
                DateTime Old_date = Convert.ToDateTime(Issue.Text.ToString());


                //get the difference in the days fromat
                String diff = (Current_date - Old_date).TotalDays.ToString();


                // calculate the round off value 
                Double Days = Math.Round(Convert.ToDouble(diff));

                //            MessageBox.Show("" + Days);
                // return the total cost of the Video
                int price = 0;
                price=Video_Cost * Convert.ToInt32(Days);

                //this will also print the charges of the rent 
                query = "Update  Rental set CustomerID='" + CustomerIDTxtBox.Text.ToString() + "',VideoID='" + MovieIDTxtBox.Text.ToString() + "',IssueDate='" + Issue.Value.Date.ToString() + "',ReturnDate='" + Return.Value.Date.ToString() + "' where ID=" + RentID + "";
                Obj.InsDelUpdt(query);


                MessageBox.Show("Movie is returned and your Charges is "+price);


                query = "select * from Rental";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //calling the reset method to reset all the text box
                ClearAll();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this method is used to print  the id of the movie which is send most on rent 
            query = "";
            int countVideo = 0,countID=0;
            DataTable tbl = new DataTable();
            DataTable tbl1 = new DataTable();

            query = "select * from Video ";
            tbl = Obj.Srch(query);
            for (int y=0;y<tbl.Rows.Count;y++) {
                String query1 = "select * from Rental where VideoID='"+tbl.Rows[y]["id"].ToString()+"'";
                tbl1 = Obj.Srch(query1);
                if (tbl1.Rows.Count>0) {
                    if (tbl1.Rows.Count > countVideo) {
                        countVideo = tbl.Rows.Count;
                        countID = Convert.ToInt32(tbl.Rows[y]["id"].ToString());
                    }
                }


            }
            MessageBox.Show("Top Rated  Video which is on Rent Most the id  is==" + countID);
            //calling the reset method to reset all the text box
            ClearAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this method id used to print the id of that customer who has most movie on rent 
            query = "";
            int countVideo = 0, countID = 0;
            DataTable tbl = new DataTable();
            DataTable tbl1 = new DataTable();

            query = "select * from Customer";
            tbl = Obj.Srch(query);
            for (int y = 0; y < tbl.Rows.Count; y++)
            {
                String query1 = "select * from Rental where CustomerID='" + tbl.Rows[y]["id"].ToString() + "'";
                tbl1 = Obj.Srch(query1);
                if (tbl1.Rows.Count > 0)
                {
                    if (tbl1.Rows.Count > countVideo)
                    {
                        countVideo = tbl.Rows.Count;
                        countID = Convert.ToInt32(tbl.Rows[y]["id"].ToString());
                    }
                }


            }
            MessageBox.Show("Top Rated customer ID who get most Video on Rent ID is==" + countID);

            //calling the reset method to reset all the text box
            ClearAll();

        }

        private void VideoData_Click(object sender, EventArgs e)
        {

            //this is used to get the record of the movie
            btnVideo = 1;
            query = "";
            query = "select * from Video ";
            DataTable TblRecord = new DataTable();
            TblRecord = Obj.Srch(query);
            Record.DataSource = TblRecord;

            btnCustomer = 0;
            btnRent = 0;

        }

        private void Record_DoubleClick(object sender, EventArgs e)
        {
            //this is used to print  the details after double cliking on the data gridview and it will display the details in the text box
            if (btnVideo==1) {
                MovieID = Convert.ToInt32(Record.CurrentRow.Cells[0].Value.ToString());
                MovieIDTxtBox.Text = Record.CurrentRow.Cells[0].Value.ToString();
                title.Text = Record.CurrentRow.Cells[1].Value.ToString();
                Ratting.Text = Record.CurrentRow.Cells[2].Value.ToString();
                Year.Text = Record.CurrentRow.Cells[3].Value.ToString();
                Cost.Text = Record.CurrentRow.Cells[4].Value.ToString();

                Video_Cost = Convert.ToInt32(Record.CurrentRow.Cells[4].Value.ToString());

                Copies.Text = Record.CurrentRow.Cells[5].Value.ToString();
                Video_Copy = Convert.ToInt32(Record.CurrentRow.Cells[5].Value.ToString());

                Plot.Text = Record.CurrentRow.Cells[6].Value.ToString();
                Genre.Text = Record.CurrentRow.Cells[7].Value.ToString();

                btnVideo= 0;
            }
            if (btnCustomer==1) {

                CustomerID = Convert.ToInt32(Record.CurrentRow.Cells[0].Value.ToString());

                CustomerIDTxtBox.Text = Record.CurrentRow.Cells[0].Value.ToString();
                FirstName.Text = Record.CurrentRow.Cells[1].Value.ToString();
                LastName.Text = Record.CurrentRow.Cells[2].Value.ToString();
                MobileNo.Text = Record.CurrentRow.Cells[3].Value.ToString();
                Address.Text = Record.CurrentRow.Cells[4].Value.ToString();
                btnCustomer = 0;

            }

            if (btnRent==1) {

                RentID=Convert.ToInt32( Record.CurrentRow.Cells[0].Value.ToString());

                CustomerIDTxtBox.Text = Record.CurrentRow.Cells[1].Value.ToString();
                MovieIDTxtBox.Text = Record.CurrentRow.Cells[2].Value.ToString();
                Issue.Text = Record.CurrentRow.Cells[3].Value.ToString();

                btnRent = 0;
            }



        }

        private void CustomerData_Click(object sender, EventArgs e)
        {
            //this is used to display the customer 
            btnCustomer = 1;
            query = "";
            query = "select * from Customer ";
            DataTable TblRecord = new DataTable();
            TblRecord = Obj.Srch(query);
            Record.DataSource = TblRecord;

            btnVideo = 0;
            btnRent = 0;

        }

        private void Rental_Click(object sender, EventArgs e)
        {
            //this is used to display the rental record
            btnRent = 1;

            query = "";
            query = "select * from Rental ";
            DataTable TblRecord = new DataTable();
            TblRecord = Obj.Srch(query);
            Record.DataSource = TblRecord;

            btnCustomer = 0;
            btnVideo = 0;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            // this method is used to enter  the record of the customer in the table 
            if (!FirstName.Text.ToString().Equals("") && !LastName.Text.ToString().Equals("") && !MobileNo.Text.ToString().Equals("") && !Address.Text.ToString().Equals("")) {
                query = "";
                query = "Insert into Customer(FirstName,LastName,Mobile,Address) values('" + FirstName.Text.ToString() + "','" + LastName.Text.ToString() + "','" + MobileNo.Text.ToString() + "','" + Address.Text.ToString() + "')";
                Obj.InsDelUpdt(query);
                MessageBox.Show("Customer Record is Saved");

                query = "select * from Customer";
                DataTable recordTbl = new DataTable();
                recordTbl = Obj.Srch(query);
                Record.DataSource = recordTbl;
                //this is used to get the record of the movie
                ClearAll();
            }
        }
    }
}
