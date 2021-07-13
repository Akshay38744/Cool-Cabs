using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class Edit_Driver : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"].ToString() != "Admin" && Session["pwd"].ToString() != "Admin123")
        {
            Response.Redirect("Homepage.aspx");
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        cn.Open();
        cmd = new SqlCommand("proc_drivers", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters["@mode"].Value = "Update";
        FileUpload fuPhoto = GridView1.Rows[e.RowIndex].FindControl("fuPhoto") as FileUpload;
        Guid FileName = Guid.NewGuid();
        fuPhoto.SaveAs(Server.MapPath("~/img/" + FileName + ".jpg"));
        cmd.Parameters.Add("@cardetails",(GridView1.Rows[e.RowIndex].FindControl("txtcardetails")as TextBox).Text.Trim());
        cmd.Parameters.Add("@image", "~/Images/" + FileName + ".jpg"  );
        cmd.Parameters.Add("@id", (Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString())));
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}