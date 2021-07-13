using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!(Page.IsPostBack))
        {
            FillCapctha();
        }
    
    }
    public void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "Generate-captcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {


            throw;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Session["captcha"].ToString() != txtCaptcha.Text)
        {
            Response.Write("<script>alert('Invalid Captcha Code')</script>");
        }
        else
        {
            SqlConnection cn = new SqlConnection("Data Source=localhost;Initial Catalog=Easytaxi;Integrated Security=True");
            cn.Open();

            //SqlCommand cmd = new SqlCommand("Select *from Drivers", cn);
            SqlCommand cmd = new SqlCommand("Select *from Account", cn);
            //SqlDataReader dr1 = cmd1.ExecuteReader();
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                {
                    Session["name"] = dr["username"].ToString();
                    Session["name"] = txtusername.Text;
                    Session["pwd"] = txtpassword.Text;

                    if (txtusername.Text == "Admin" && txtpassword.Text == "Admin123")
                    {
                        Response.Redirect("Admin.aspx");
                    }

                    else if (dr["userName"].ToString() == txtusername.Text && dr["Password"].ToString() == txtpassword.Text)
                    {

                        Response.Redirect("Homepage.aspx");
                    }
                   

                    else if (txtusername.Text == "" && txtpassword.Text == "")
                    {
                        Response.Write("Please eneter login & password");
                    }
                    else
                    {

                        Response.Write("<script>alert('Invalid username & Password')</script>");
                    }
                }
            }
        }
        
    }

    protected void btnsignup_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        FillCapctha();
    }
}
