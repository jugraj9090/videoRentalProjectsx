using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoRentalProjectsx
{
    public partial class Form1 : Form 
    {
        link lnk = new link();
        int copies = 0;
        int recordView = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Customer_dataadd_Click(object sender, EventArgs e)
        {
            if (Customer_username.Text.ToString().Equals("") && Customer_useremail.Text.ToString().Equals("") && Customer_useraddress.Text.ToString().Equals(""))
            {
                MessageBox.Show("must fill the all details ");
            }
            else {
                String customerAdd = "insert into Customer_data values('"+Customer_username.Text+"','"+Customer_useremail.Text+"','"+Customer_useraddress.Text+"')";
                lnk.Query(customerAdd);
                MessageBox.Show("Cusotmer is added");
                Customer_username.Text = "";
                Customer_useremail.Text = "";
                Customer_useraddress.Text = "";
            }
        }

        private void Customer_delete_Click(object sender, EventArgs e)
        {
            if (userid_rental.Text.ToString().Equals(""))
            {
                MessageBox.Show("Must choose the customer before deleting ");
            }
            else {
                string message = "Do you want to delete this Customer?";
                string title = "Close Dialoge box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    DataTable tbl = new DataTable();
                    String verfy = "select * from Booking_data where Customer_Id="+Convert.ToInt32(userid_rental.Text) +" and ReturnDate='Book'";
                    tbl = lnk.Record(verfy);
                    if (tbl.Rows.Count > 0)
                    {
                        MessageBox.Show(" you already have movies on booking ");
                    }
                    else{
                        String customerDelete = "delete from Customer_data where Customer_Id=" + Convert.ToInt32(userid_rental.Text) + "";
                        lnk.Query(customerDelete);
                        this.Close();

                        Customer_username.Text = "";
                        Customer_useremail.Text = "";
                        Customer_useraddress.Text = "";
                        userid_rental.Text = "";
                    }
                }
            }
        }

        private void Customer_update_Click(object sender, EventArgs e)
        {
            if (userid_rental.Text.ToString().Equals("") && Customer_username.Text.ToString().Equals("") && Customer_useremail.Text.ToString().Equals("") && Customer_useraddress.Text.ToString().Equals(""))
            {
                MessageBox.Show("must fill all values to update ");
            }
            else {
                          
                String customer_Update ="update  Customer_data set Name='"+Customer_username.Text+"',Email='"+Customer_useremail.Text+"', Address='"+Customer_useraddress.Text+ "' where Customer_Id=" + Convert.ToInt32(userid_rental.Text) + " ";
                lnk.Record(customer_Update);
                MessageBox.Show("Record if sucessfully Updated ");

                Customer_username.Text = "";
                Customer_useremail.Text = "";
                Customer_useraddress.Text = "";
                userid_rental.Text = "";

            }
        }


        public int countCustomerBooking(int Customer_ID) {

            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Booking_data where Customer_Id="+Customer_ID+" and BookingDate='Book'");

            return tbl.Rows.Count;
        }




        public int countMovieBooking(int Customer_ID)
        {

            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Booking_data where Movie_Id=" + Customer_ID + " and BookingDate='Book'");

            return tbl.Rows.Count;
        }


        public int countMovieCopies(int Customer_ID)
        {

            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Movie_data where Movie_Id=" + Customer_ID + "");

            return Convert.ToInt32(tbl.Rows[0]["Copies"]);
        }



        public int getMovieCost(int Customer_ID)
        {
     
            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Movie_data where Movie_Id=" + Customer_ID + "");

            return Convert.ToInt32(tbl.Rows[0]["Cost"]);

        }



        private void issuemovie_rental_Click(object sender, EventArgs e)
        {
            if (userid_rental.Text.ToString().Equals("") && videoid_rental.Text.ToString().Equals(""))
            {
                MessageBox.Show("must choose the video or customer to book a video ");
            }
            else {
                if (countCustomerBooking(Convert.ToInt32(userid_rental.Text.ToString())) < 2)
                {

                    if (countMovieBooking(Convert.ToInt32(videoid_rental.Text.ToString())) < countMovieCopies(Convert.ToInt32(videoid_rental.Text.ToString())))
                    {






                        String Book_Video = "insert into Booking_data values(" + Convert.ToInt32(videoid_rental.Text.ToString()) + "," + Convert.ToInt32(userid_rental.Text.ToString()) + ",'" + BookingDtp.Text + "','Book')";
                        lnk.Query(Book_Video);
                        MessageBox.Show("Movie is Booked by Customer Id : " + userid_rental.Text);
                    }
                    else {
                        MessageBox.Show("All sample are Booked ");
                    }
                }
                Customer_username.Text = "";
                Customer_useremail.Text = "";
                Customer_useraddress.Text = "";
                userid_rental.Text = "";

                videoid_rental.Text = "";
                textBox_video_name.Text = "";
                textBox_stars.Text = "";
                textBox_copies.Text = "";
                textBox_year.Text = "";
                textBox_plot.Text = "";
                textBox_production.Text = "";


            }

        }

        private void Delete_rentalmovie_Click(object sender, EventArgs e)
        {
            if (lblRental_Id.Text.ToString().Equals(""))
            {
                MessageBox.Show("select the rental video to delete ");
            }
            else {
                string message = "Do you really want to delete this Booking ?";
                string title = "Close Dialoge box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    String Booking_Delete = "delete from Booking_data where Rent_Id="+Convert.ToInt32(lblRental_Id.Text.ToString())+"";
                    lnk.Query(Booking_Delete);
                    this.Close();

                }



                Customer_username.Text = "";
                Customer_useremail.Text = "";
                Customer_useraddress.Text = "";
                userid_rental.Text = "";

                videoid_rental.Text = "";
                textBox_video_name.Text = "";
                textBox_stars.Text = "";
                textBox_copies.Text = "";
                textBox_year.Text = "";
                textBox_plot.Text = "";
                textBox_production.Text = "";

                lblRental_Id.Text = "";



            }
        }

        private void movie_add_Click(object sender, EventArgs e)
        {
            if (textBox_video_name.Text.ToString().Equals("") && textBox_stars.Text.ToString().Equals("") && textBox_year.Text.ToString().Equals("") && textBox_copies.Text.ToString().Equals("") && textBox_plot.Text.ToString().Equals("") && textBox_production.Text.ToString().Equals("")) {
                MessageBox.Show("you must have to fill all the details ");
            }
            else {

                try {

                    DateTime dateNow = DateTime.Now;

                    int Currentyear = dateNow.Year;

                    int diffYear = Currentyear - Convert.ToInt32(textBox_year.Text.ToString());
                    int cost = 0;
                    // MessageBox.Show(diff.ToString());
                    if (diffYear >= 5)
                    {
                        cost = 2;
                    }
                    if (diffYear >= 0 && diffYear < 5)
                    {
                        cost = 5;

                    }
                    

                    String Movie_Add = "insert into Movie_data values('"+textBox_video_name.Text+"','"+textBox_stars.Text+"','"+textBox_year.Text+"','"+textBox_copies.Text+"',"+cost+",'"+textBox_plot.Text+"','"+textBox_production.Text+"')";
                    lnk.Query(Movie_Add);
                    MessageBox.Show("Video Booking Charges per day is: " + cost);

                    textBox_video_name.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_year.Text = "";


                }
                catch (Exception ex) {
                        
                }


            }

        }

        private void delete_movie_Click(object sender, EventArgs e)
        {
            if (videoid_rental.Text.ToString().Equals(""))
            {
                MessageBox.Show("must select the video for deleting ");
            }
            else {
                string message = "Do you really want to delete this Booking ?";
                string title = "Close Dialoge box";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    DataTable tbl = new DataTable();
                    String verfy = "select * from Booking_data where Movie_Id=" + Convert.ToInt32(videoid_rental.Text) + " and ReturnDate='Book'";
                    tbl = lnk.Record(verfy);
                    if (tbl.Rows.Count > 0)
                    {
                        MessageBox.Show("  this movie is already booked so can't delete yet");
                    }
                    else {
                        String Booking_Delete = "delete from Movie_data where Movie_Id=" + Convert.ToInt32(videoid_rental.Text.ToString()) + "";
                        lnk.Query(Booking_Delete);
                        this.Close();

                    }

                    textBox_video_name.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_year.Text = "";
                    videoid_rental.Text = "";



                }

            }
        }

        private void update_movie_Click(object sender, EventArgs e)
        {
            if ( videoid_rental.Text.ToString().Equals("") && textBox_video_name.Text.ToString().Equals("") && textBox_stars.Text.ToString().Equals("") && textBox_year.Text.ToString().Equals("") && textBox_copies.Text.ToString().Equals("") && textBox_plot.Text.ToString().Equals("") && textBox_production.Text.ToString().Equals(""))
            {
                MessageBox.Show("you must have to fill all the details ");
            }
            else
            {

                try
                {

                    DateTime dateNow = DateTime.Now;

                    int Currentyear = dateNow.Year;

                    int diffYear = Currentyear - Convert.ToInt32(textBox_year.Text.ToString());
                    int cost = 0;
                    // MessageBox.Show(diff.ToString());
                    if (diffYear >= 5)
                    {
                        cost = 2;
                    }
                    if (diffYear >= 0 && diffYear < 5)
                    {
                        cost = 5;

                    }


                    String Movie_Add = "update Movie_data set Name='" + textBox_video_name.Text + "',Stars='" + textBox_stars.Text + "',Year=" + Convert.ToInt32(textBox_year.Text) + ",Copies=" + Convert.ToInt32(textBox_copies.Text) + ",Cost=" + cost + ",Plot='"+textBox_plot.Text+"',Production='" + textBox_production.Text + "' where Movie_Id="+Convert.ToInt32(videoid_rental.Text.ToString())+"";
                    lnk.Query(Movie_Add);

                    MessageBox.Show("Video Booking is updated Charges per day is: " + cost);

                    videoid_rental.Text = "";
                    textBox_video_name.Text = "";
                    textBox_copies.Text = "";
                    textBox_plot.Text = "";
                    textBox_production.Text = "";
                    textBox_stars.Text = "";
                    textBox_year.Text = "";

                }
                catch (Exception ex)
                {

                }
                

            }



        }

        private void returnmovie_rental_Click(object sender, EventArgs e)
        {
            if(lblRental_Id.Text.ToString().Equals("")) {
                MessageBox.Show("Select  the video to return ");
            }
            else{

                //get the difference to between booking date or retrun date to calcualte the charges 

                DateTime crnt_date = DateTime.Now;


                //convert the old date from string to Date fromat
                DateTime prev_date = Convert.ToDateTime(BookingDtp.Text);


                //get the difference in the days fromat
                String Daysdiff = (crnt_date - prev_date).TotalDays.ToString();


                // calculate the round off value 
                Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));
                

                int Price = Convert.ToInt32(DaysInterval) * getMovieCost(Convert.ToInt32(videoid_rental.Text));



                // when we return the movie 
                String Return_Movie = "update   Booking_Data set Movie_Id="+Convert.ToInt32(videoid_rental.Text)+",Customer_Id="+Convert.ToInt32(userid_rental.Text)+",BookingDate='"+BookingDtp.Text+"',ReturnDate="+ReturnDtp.Text+" where Rent_Id="+Convert.ToInt32(lblRental_Id.Text)+"";
                lnk.Query(Return_Movie);

                MessageBox.Show("Thans for  the visit and Your charges is: " + Price);
            }



        }

        private void user_record_Click(object sender, EventArgs e)
        {
            //get the all record and view in the database table 
            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Customer_data");
            DatabaseTable.DataSource = tbl;
            //flag for viewing the customer 
            recordView = 1;

        }

        private void movie_record_Click(object sender, EventArgs e)
        {
            //get the all record and view in the database table 
            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Movie_data");
            DatabaseTable.DataSource = tbl;
            //flag for viewing the Movie 
            recordView = 2;
        }

        private void rental_info_Click(object sender, EventArgs e)
        {
            //get the all record and view in the database table 
            DataTable tbl = new DataTable();
            tbl = lnk.Record("select * from Booking_data");
            DatabaseTable.DataSource = tbl;
            //flag for viewing the Booking 
            recordView = 3;
        }

        private void DatabaseTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if  the flag value is 1 then we display the record of the customer
            if (recordView == 1) {
                //display the data 
                userid_rental.Text = DatabaseTable.CurrentRow.Cells[0].Value.ToString();
                Customer_username.Text= DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                Customer_useremail.Text= DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                Customer_useraddress.Text= DatabaseTable.CurrentRow.Cells[3].Value.ToString();
            } else if (recordView == 2) {
                //// if  the flag value is 1 then we display the record of the movie
                videoid_rental.Text= DatabaseTable.CurrentRow.Cells[0].Value.ToString();
                textBox_video_name.Text= DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                textBox_stars.Text= DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                textBox_year.Text= DatabaseTable.CurrentRow.Cells[3].Value.ToString();
                textBox_copies.Text= DatabaseTable.CurrentRow.Cells[4].Value.ToString();
                textBox_plot.Text= DatabaseTable.CurrentRow.Cells[6].Value.ToString();
                textBox_production.Text= DatabaseTable.CurrentRow.Cells[7].Value.ToString();


            }
            else if (recordView == 3) {
                // if  the flag value is 1 then we display the record of the Booking 
                lblRental_Id.Text= DatabaseTable.CurrentRow.Cells[0].Value.ToString();
                videoid_rental.Text= DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                userid_rental.Text= DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                BookingDtp.Text= DatabaseTable.CurrentRow.Cells[3].Value.ToString();

            }
            recordView = 0;

        }

        private void rated_movie_Click(object sender, EventArgs e)
        {

            //get the name of the best rated movie from the customer 
            DataTable tblData = new DataTable();

            tblData = lnk.Record("select * from Movie_data");
            int x = 0, y = 0, cunt = 0;
            String Name = "";
            //using the concept of highest value from the booking video 
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 =lnk.Record("select * from Booking_data where Movie_Id=" + Convert.ToInt32(tblData.Rows[x]["Movie_Id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Name = tblData.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show(Name);



        }

        private void best_customer_Click(object sender, EventArgs e)
        {

            //get the name of the best rated movie from the customer 
            DataTable tblData = new DataTable();

            tblData = lnk.Record("select * from Customer_data");
            int x = 0, y = 0, cunt = 0;
            String Name = "";
            //using the concept of highest value from the booking customer 
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = lnk.Record("select * from Booking_data where Customer_Id=" + Convert.ToInt32(tblData.Rows[x]["Customer_Id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Name = tblData.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show(Name);


        }
    }
}
