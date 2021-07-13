using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Product_Details : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"];
        if (!(Page.IsPostBack))
        {
            databind();
        }

    }
    public void databind()
    {
        cn.Open();
        cmd = new SqlCommand("proc_drivers", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters["@mode"].Value = "Details";
        ds = new DataSet();
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DataList1.DataSource = ds;
        DataList1.DataBind();
        cmd.ExecuteNonQuery();
        cn.Close();
    }


    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName == "Book")
        {
            Response.Redirect("Book.aspx?id=" + e.CommandArgument.ToString());
        }
    }
}
