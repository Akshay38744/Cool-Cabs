using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class VIewProfile : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlDataAdapter da;
    SqlCommand cmd;
    DataSet ds;
    string id;
    string name;
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

    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Response.Redirect("Homepage.aspx");
    }

    public void grid() 
    {
        cn.Open();
        cmd = new SqlCommand("proc_Account", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters.Add("@username", Session["name"]);
        cmd.Parameters["@mode"].Value = "select";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        DataList1.DataSource = ds;
        DataList1.DataBind();
        cn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewBookings.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["name"] = null;
        Response.Redirect("Homepage.aspx");
    }
}


