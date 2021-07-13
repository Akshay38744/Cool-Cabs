using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class ViewBookings : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!(Page.IsPostBack))
        {
            Grid();
        }

        if (Session["name"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

            
        }
    }

    public void Grid()
    {
        cn.Open();
        cmd = new SqlCommand("Proc_booking", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters["@mode"].Value = "Select";
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        cn.Close();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["name"] = null;
        Response.Redirect("Homepage.aspx");
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        cn.Open();
        cmd = new SqlCommand("proc_booking", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters["@mode"].Value = "Delete";
        cmd.Parameters.Add("@id", (Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString())));
        cmd.ExecuteNonQuery();
        cn.Close();
        Grid();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.PageIndex = 1;
        Grid();
    }



    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        cn.Open();
        cmd = new SqlCommand("proc_booking", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters.Add("@name", (GridView1.Rows[e.RowIndex].FindControl("txtname") as TextBox).Text.Trim());
        //cmd.Parameters.Add("@email", (GridView1.Rows[e.RowIndex].FindControl("txtemail") as TextBox).Text.Trim());
        cmd.Parameters.Add("@place", (GridView1.Rows[e.RowIndex].FindControl("txtplace") as TextBox).Text.Trim());
        cmd.Parameters.Add("@date", (GridView1.Rows[e.RowIndex].FindControl("txtdate") as TextBox).Text.Trim());
        cmd.Parameters.Add("@amount", (GridView1.Rows[e.RowIndex].FindControl("txtamount") as TextBox).Text.Trim());
        cmd.Parameters.Add("@time", (GridView1.Rows[e.RowIndex].FindControl("txttime") as TextBox).Text.Trim());
        cmd.Parameters.Add("@id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        cmd.Parameters["@mode"].Value = "update";
        cmd.ExecuteNonQuery();
        GridView1.EditIndex = -1;
        cn.Close();
        Grid();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.PageIndex = 1;
        Grid();
    }
}