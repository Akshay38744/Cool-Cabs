using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class Home : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    int cnt;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Homepage.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Response.Redirect("Homepage.aspx");
    }



    protected void btnbook_Click(object sender, EventArgs e)
    {
        try
        {
            if (validation() == true)
            {
                    cn.Open();
                    cmd = new SqlCommand("proc_Account", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@mode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Mode"].Value = "Register";
                    cmd.Parameters.Add("@username", txtusername.Text);
                    cmd.Parameters.Add("@password", txtpassword.Text);
                    cmd.Parameters.Add("@email", txtEmail.Text);
                    cmd.Parameters.Add("@mobile", txtmobile.Text);
                    cmd.Parameters.Add("@location", txtloacation.Text);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Registered Sucessfully')</script>");
                     cn.Close();
            }
    }
        catch
        {

        }
        finally
        {
           
        }
       
    }

    public bool checkusername()
    {
        cnt = 0;
        cn.Open();
        cmd = new SqlCommand("proc_Account", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters.Add("@username", txtusername.Text);
        cmd.Parameters["@mode"].Value = "checkuser";
        cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cn.Close();
        if (cnt > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool validation()
    {

        if (string.IsNullOrEmpty(txtusername.Text.Trim()))
        {
            Error.Text = "Please Enter a Username";
            txtusername.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtusername.Text.Trim()) && !Regex.IsMatch(txtusername.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Username, should contains the alphabets and space !!";
            txtusername.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtusername.Text.Trim()) && txtusername.Text.Length < 6)
        {
            Error.Text = "Username should have at least 6 charactors !!";
            txtusername.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtusername.Text.Trim()) && txtusername.Text.Length > 100)
        {
            Error.Text = "Username should be lesser than the 100 charactors !!";
            txtusername.Focus();
            return false;
        }
        else if (checkusername() == true)
        {
            Error.Text = "Username already used";
            txtusername.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
        {
            Error.Text = "Please Enter a Password";
            txtpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtpassword.Text.Trim()) && !Regex.IsMatch(txtpassword.Text, "^[a-z.A-Z,0-9 ]+$"))
        {
            Error.Text = "Invalid Password, should contains the alphabets and space !!";
            txtpassword.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtpassword.Text.Trim()) && txtpassword.Text.Length < 6)
        {
            Error.Text = "Password should have at least 6 charactors !!";
            txtpassword.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtpassword.Text.Trim()) && txtpassword.Text.Length > 100)
        {
            Error.Text = "Password should be lesser than the 100 charactors !!";
            txtpassword.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            Error.Text = "Email Id cannot be Blank !!";
            txtEmail.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtEmail.Text) & !Regex.IsMatch(txtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            Error.Text = "Your email address is not in correct format !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text) & txtEmail.Text.Length > 100)
        {
            Error.Text = "Email contain maximum 100 character !!";
            txtEmail.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtmobile.Text.Trim()))
        {
            Error.Text = "Mobile no should not be blank!";
            txtmobile.Focus();
            txtmobile.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtmobile.Text) && !Regex.IsMatch(txtmobile.Text, "^[0-9]+$"))
        {
            Error.Text = "Invalid Mobile no, should be digits !!";
            txtmobile.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtmobile.Text) && txtmobile.Text.Trim().Length < 10)
        {
            Error.Text = "Mobile number should contain 10 digits !!";
            txtmobile.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtmobile.Text) && txtmobile.Text.Trim().Length > 10)
        {
            Error.Text = "Mobile number should contain 10 digits !!";
            txtmobile.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtmobile.Text) && !Regex.IsMatch(txtmobile.Text, "^[7-9]{1}[0-9]{9}"))
        {
            Error.Text = "Invalid Mobile no, should start with 7, 8 or 9 !!";
            txtmobile.Focus();
            return false;
        }

        else if (string.IsNullOrEmpty(txtloacation.Text.Trim()))
        {
            Error.Text = "Please Enter a Location";
            txtloacation.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtloacation.Text.Trim()) && !Regex.IsMatch(txtloacation.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Location, should contains the alphabets and space !!";
            txtloacation.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtloacation.Text.Trim()) && txtloacation.Text.Length < 6)
        {
            Error.Text = "Location should have at least 6 charactors !!";
            txtloacation.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtloacation.Text.Trim()) && txtloacation.Text.Length > 100)
        {
            Error.Text = "Location should be lesser than the 100 charactors !!";
            txtloacation.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtusername.Text = "";
        txtpassword.Text = "";
        txtEmail.Text = "";
        txtmobile.Text = "";
        txtloacation.Text = "";
    }

}