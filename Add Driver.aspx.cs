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

public partial class Registration : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"].ToString() != "Admin" && Session["pwd"].ToString() != "Admin123")
        {
            Response.Redirect("Homepage.aspx");
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if(validation() == true)
            {
                cn.Open();
                string s = @"~\img\" + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(s));
                cmd = new SqlCommand("proc_drivers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@id", txtCabNo.Text);
                cmd.Parameters.AddWithValue("@Name", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@Cabmodel", txtCarmodel.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@mobilenumber", TxtMobileNumber.Text);
                cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                cmd.Parameters.AddWithValue("@experiance", txtExperiance.Text + " months");
                cmd.Parameters.AddWithValue("@rate", txtRate.Text + " @Km/h");
                cmd.Parameters.AddWithValue("@image", s);
                cmd.Parameters.AddWithValue("@Cardetails", txtdesc.Text);
                cmd.Parameters["@mode"].Value = "Add driver";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data insereted Sucessfully')</script>");
            }
           
        }
        catch
        {

        }
        finally
        {

        }
       

    }

    public bool validation()
    {
        if (string.IsNullOrEmpty(txtCabNo.Text.Trim()))
        {
            lblerror.Text = "Taxi no should not be blank!";
            txtCabNo.Focus();
            txtCabNo.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCabNo.Text) && !Regex.IsMatch(txtCabNo.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Taxi no, should be digits !!";
            txtCabNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCabNo.Text) && txtCabNo.Text.Trim().Length < 4)
        {
            lblerror.Text = "Taxi number should contain 10 digits !!";
            txtCabNo.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtCabNo.Text) && txtCabNo.Text.Trim().Length > 4)
        {
            lblerror.Text = "Taxi number should contain 10 digits !!";
            txtCabNo.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtCarmodel.Text.Trim()))
        {
            lblerror.Text = "Please Enter a Carmodel name";
            txtCarmodel.Focus();
            txtCarmodel.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCarmodel.Text.Trim()) && !Regex.IsMatch(txtCarmodel.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid Carmodel name, should contains the alphabets and space !!";
            txtCarmodel.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCarmodel.Text.Trim()) && txtCarmodel.Text.Length < 6)
        {
            lblerror.Text = "Carmodel name should have at least 6 charactors !!";
            txtCarmodel.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtCarmodel.Text.Trim()) && txtCarmodel.Text.Length > 12)
        {
            lblerror.Text = "Carmodel name should be lesser than the 100 charactors !!";
            txtCarmodel.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtDriverName.Text.Trim()))
        {
            lblerror.Text = "Please Enter a Driver name";
            txtDriverName.Focus();
            txtDriverName.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtDriverName.Text.Trim()) && !Regex.IsMatch(txtDriverName.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid Driver name, should contains the alphabets and space !!";
            txtDriverName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtDriverName.Text.Trim()) && txtDriverName.Text.Length < 6)
        {
            lblerror.Text = "Driver name should have at least 6 charactors !!";
            txtDriverName.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtDriverName.Text.Trim()) && txtDriverName.Text.Length > 100)
        {
            lblerror.Text = "Driver name should be lesser than the 100 charactors !!";
            txtDriverName.Focus();
            return false;
        }
        
        else if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
        {
            lblerror.Text = "Please Enter a Address";
            txtAddress.Focus();
            txtAddress.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && !Regex.IsMatch(txtAddress.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid Address, should contains the alphabets and space !!";
            txtAddress.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && txtAddress.Text.Length < 6)
        {
            lblerror.Text = "Address should have at least 6 charactors !!";
            txtAddress.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtAddress.Text.Trim()) && txtAddress.Text.Length > 100)
        {
            lblerror.Text = "Address should be lesser than the 100 charactors !!";
            txtAddress.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtCity.Text.Trim()))
        {
            lblerror.Text = "Please Enter a City name";
            txtCity.Focus();
            txtCity.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCity.Text.Trim()) && !Regex.IsMatch(txtCity.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid City name, should contains the alphabets and space !!";
            txtCity.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtCity.Text.Trim()) && txtCity.Text.Length < 6)
        {
            lblerror.Text = "City name should have at least 6 charactors !!";
            txtCity.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtCity.Text.Trim()) && txtCity.Text.Length > 12)
        {
            lblerror.Text = "City name should be lesser than the 100 charactors !!";
            txtCity.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(TxtMobileNumber.Text.Trim()))
        {
            lblerror.Text = "Mobile no should not be blank!";
            TxtMobileNumber.Focus();
            TxtMobileNumber.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(TxtMobileNumber.Text) && !Regex.IsMatch(TxtMobileNumber.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Mobile no, should be digits !!";
            TxtMobileNumber.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(TxtMobileNumber.Text) && TxtMobileNumber.Text.Trim().Length < 10)
        {
            lblerror.Text = "Mobile number should contain 10 digits !!";
            TxtMobileNumber.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(TxtMobileNumber.Text) && TxtMobileNumber.Text.Trim().Length > 10)
        {
            lblerror.Text = "Mobile number should contain 10 digits !!";
            TxtMobileNumber.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(TxtMobileNumber.Text) && !Regex.IsMatch(TxtMobileNumber.Text, "^[7-9]{1}[0-9]{9}"))
        {
            lblerror.Text = "Invalid Mobile no, should start with 7, 8 or 9 !!";
            TxtMobileNumber.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(TxtEmail.Text))
        {
            lblerror.Text = "Email Id cannot be Blank !!";
            TxtEmail.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(TxtEmail.Text) & !Regex.IsMatch(TxtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblerror.Text = "Your email address is not in correct format !!";
            TxtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(TxtEmail.Text) & TxtEmail.Text.Length > 100)
        {
            lblerror.Text = "Email contain maximum 100 character !!";
            TxtEmail.Focus();
            return false;
        }
       else if (string.IsNullOrEmpty(txtExperiance.Text.Trim()))
        {
            lblerror.Text = "Experiance no should not be blank!";
            txtExperiance.Focus();
            txtExperiance.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtExperiance.Text) && !Regex.IsMatch(txtExperiance.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Experiance, should be digits !!";
            txtExperiance.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtExperiance.Text) && txtExperiance.Text.Trim().Length < 1)
        {
            lblerror.Text = "Experiance should contain 2 digits !!";
            txtExperiance.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtExperiance.Text) && txtExperiance.Text.Trim().Length > 2)
        {
            lblerror.Text = "Experiance should contain 2 digits !!";
            txtExperiance.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtRate.Text.Trim()))
        {
            lblerror.Text = "Rate no should not be blank!";
            txtRate.Focus();
            txtRate.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtRate.Text) && !Regex.IsMatch(txtRate.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Rate, should be digits !!";
            txtRate.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtRate.Text) && txtRate.Text.Trim().Length < 1)
        {
            lblerror.Text = "Rate should contain 2 digits !!";
            txtRate.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtRate.Text) && txtRate.Text.Trim().Length > 3)
        {
            lblerror.Text = "Rate should contain 2 digits !!";
            txtRate.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtCabNo.Text = "";
        txtDriverName.Text = "";
        //txtPassword.Text = "";
        txtCarmodel.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        TxtMobileNumber.Text = "";
        TxtEmail.Text = "";
        txtExperiance.Text = "";
        txtRate.Text = "";
    }
  
}