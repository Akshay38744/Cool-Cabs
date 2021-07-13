using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Details : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!(Page.IsPostBack))
        {
            grid();
        }
               
        if (Session["name"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
           
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            Response.Redirect("ViewDetails.aspx?id=" + e.CommandArgument.ToString());
        }

       else if (e.CommandName == "Book")
        {
            Response.Redirect("Book.aspx?id=" + e.CommandArgument.ToString());
        }
    }

    public void grid()
    {     
            cn.Open();
            cmd = new SqlCommand("Proc_drivers", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
            cmd.Parameters["@mode"].Value = "Select";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            DataList1.DataSource = dt;
            DataList1.DataBind();
            cn.Close();  
    }
    protected void Vdetails_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // Response.Redirect("Book.aspx");
    }
}