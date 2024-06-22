using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //create new sqlconnection and connection to database by using connection string from web.config file  
        SqlConnection con = new SqlConnection(strcon);
        con.Open();
        if (!this.IsPostBack)
        {
            refreshdata();

        }
    }

    public void refreshdata()
    {
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            conn.Open();
            string sql = "select * from Person2";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }


            //stored procedure
            // the stored procedure

            //using (SqlCommand cmd = new SqlCommand("SelectAllCustomers", conn))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    sda.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "INSERT INTO Person2(ID,LastName,FirstName,Age,Marks) VALUES (@ID,@LastName,@FirstName,@Age,@Marks)";
        try
        {
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ID", 1);
                    cmd.Parameters.AddWithValue("@LastName", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@FirstName", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Age", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Marks", TextBox4.Text);
                    cmd.ExecuteNonQuery();
                }
            }
         refreshdata();
         clear();
        }
        catch (SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
    }

    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    TextBox1.Text = GridView1.SelectedRow.Cells[0].Text;
    //    TextBox2.Text = GridView1.SelectedRow.Cells[1].Text;
    //    TextBox3.Text = GridView1.SelectedRow.Cells[2].Text;
    //    TextBox4.Text = GridView1.SelectedRow.Cells[3].Text;
    //    HiddenField1.Value = GridView1.SelectedRow.Cells[4].Text;
    //}

   
    public void  clear()
    {
       TextBox1.Text="";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    }
    //protected void GridView1_RowDataBound(object sender, GridViewCommandEventArgs e)
    //{



    //    if (e.CommandName == "Select")
    //    {
    //        //Determine the RowIndex of the Row whose Button was clicked.
    //        int rowIndex = Convert.ToInt32(e.CommandArgument);

    //        //Reference the GridView Row.
    //        GridViewRow row = GridView1.Rows[rowIndex];   
          

    //        TextBox1.Text = row.Cells[0].Text;
    //        TextBox2.Text= row.Cells[1].Text;
    //        TextBox3.Text = row.Cells[2].Text;
    //        TextBox4.Text = row.Cells[3].Text;
    //        HiddenField1.Value = row.Cells[4].Text;

            
    //    }
    //}



    protected void Button2_Click1(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            conn.Open();
            string sql = "select * from Person2 where FirstName like '%" +TextBox5.Text+ "%'";
           
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = "delete from  Person2 where ID=@ID";
        try
        {

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ID", HiddenField1.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            refreshdata();
            clear();
        }
        catch (SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        string sql = "update  Person2 set FirstName='"+TextBox2.Text+"', LastName='"+TextBox1.Text+"' where ID=@ID";
        try
        {

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@ID", HiddenField1.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            refreshdata();
            clear();
        }
        catch (SqlException ex)
        {
            
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = GridView1.Rows[rowIndex];


            TextBox1.Text = row.Cells[0].Text;
            TextBox2.Text = row.Cells[1].Text;
            TextBox3.Text = row.Cells[2].Text;
            TextBox4.Text = row.Cells[3].Text;
            HiddenField1.Value = row.Cells[4].Text;


        }
    }

    protected void FileUpload1_DataBinding(object sender, EventArgs e)
    {

    }
}