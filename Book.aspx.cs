using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class Book : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    int cnt = 0;
    int i;
    int j;
    int k;
    string time;
    protected void Page_Load(object sender, EventArgs e)
    {
       

        string id;
        id = Request.QueryString["id"];

        if (!(Page.IsPostBack))
        {
            getdate();
            bindid();
            DropDownList1.SelectedValue = id;
            
        }

        if (Session["name"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
        
           
        }
       
    }


    public string getdate()
    {
       
        for (i = 1; i < 13; i++)
        {
            string s = i.ToString();

            ddltime.Items.Add(s);
        }
        for(j = 1;j<61;j++)
        {
            string t = j.ToString();
            ddlt.Items.Add(t);
        }
        time = ddltime.SelectedValue + ddlt.SelectedValue + ddlt1.SelectedValue;
        return time;
    }
    protected void bindid()
    {
        cn.Open();
        SqlCommand cmd = new SqlCommand("Proc_drivers", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        cmd.Parameters["@mode"].Value = "selectid";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
     
      
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
        cn.Close();
    }

    public bool checkcab()
    {
       try
        {
                cn.Open();
                cmd = new SqlCommand("proc_insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Parameters["@mode"].Value = "Book";
                cnt = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch
        {

        }
        finally
        {

        }
        if (cnt == 0)
        {
            return true;
        }
        else
        {
            SqlDataReader dr = cmd.ExecuteReader();
            {
                dr.Read();
                {
                    if (DropDownList1.SelectedItem.Text == dr["id"].ToString())
                    {
                        Response.Write("<script>alert('Cab is already booked by Someone')</script>");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        cn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(checkcab() == true)
        {
            Response.Write("<script>alert('U can booked a cab')</script>"); 
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Homepage.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["name"] = null;
        Response.Redirect("Homepage.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
         Session["name"] = null;
         Response.Redirect("Homepage.aspx");
    }
    public bool validation()
    {
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblerror.Text = "Please Enter a name";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !Regex.IsMatch(txtName.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid name, should contains the alphabets and space !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text.Trim()) && txtName.Text.Length < 6)
        {
            lblerror.Text = "name should have at least 6 charactors !!";
            txtName.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtName.Text.Trim()) && txtName.Text.Length > 12)
        {
            lblerror.Text = "name should be lesser than the 12 charactors !!";
            txtName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            lblerror.Text = "Email Id cannot be Blank !!";
            txtEmail.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtEmail.Text) & !Regex.IsMatch(txtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblerror.Text = "Your email address is not in correct format !!";
            txtEmail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtEmail.Text) & txtEmail.Text.Length > 100)
        {
            lblerror.Text = "Email contain maximum 100 character !!";
            txtEmail.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtPlace.Text.Trim()))
        {
            lblerror.Text = "Please Enter a Place";
            txtPlace.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtPlace.Text.Trim()) && !Regex.IsMatch(txtPlace.Text, "^[a-z.A-Z ]+$"))
        {
            lblerror.Text = "Invalid Place, should contains the alphabets and space !!";
            txtPlace.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtPlace.Text.Trim()) && txtPlace.Text.Length < 6)
        {
            lblerror.Text = "Place should have at least 6 charactors !!";
            txtPlace.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtPlace.Text.Trim()) && txtPlace.Text.Length > 12)
        {
            lblerror.Text = "Place should be lesser than the 12 charactors !!";
            txtPlace.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
        {
            lblerror.Text = "Amount no should not be blank!";
            txtAmount.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAmount.Text) && !Regex.IsMatch(txtAmount.Text, "^[0-9]+$"))
        {
            lblerror.Text = "Invalid Amount, should be digits !!";
            txtAmount.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtAmount.Text) && txtAmount.Text.Trim().Length < 1)
        {
            lblerror.Text = "Amount should contain 1 digits !!";
            txtAmount.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtAmount.Text) && txtAmount.Text.Trim().Length > 6)
        {
            lblerror.Text = "Amount should contain 6 digits !!";
            txtAmount.Focus();
            return false;
        }

        else if (string.IsNullOrEmpty(txtdate.Text.Trim()))
        {
            lblerror.Text = "Please Select a pickup date";
            txtdate.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtdate.Text.Trim()) & !Regex.IsMatch(txtdate.Text, "^[0-9]{1,2}[/][0-9]{1,2}[/][0-9]{2,4}?$"))
        {
            lblerror.Text = "Please enter valid date format !!";
            txtdate.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtdate.Text.Trim()) && date_check(txtdate.Text.Trim()) == 1)
        {
            lblerror.Text = "Please enter valid date format !!";
            txtdate.Focus();
            return false;
        }
        //else if (string.IsNullOrEmpty(txttime.Text.Trim()))
        //{
        //    lblerror.Text = "Please Enter a Time";
        //    txttime.Focus();
        //    return false;
        //}
        //else if (!string.IsNullOrEmpty(txttime.Text.Trim()) && !Regex.IsMatch(txttime.Text, "^[0-9]+$"))
        //{
        //    lblerror.Text = "Invalid Time, should contains the alphabets and space !!";
        //    txttime.Focus();
        //    return false;
        //}
        else
        {
            return true;
        }
    }


    public int date_check(string date2)
    {

        string date3 = date2;
        string[] temp1 = date3.Split('/');
        int mm = Convert.ToInt32(temp1[1]);
        int dd = Convert.ToInt32(temp1[0]);
        int yy = Convert.ToInt32(temp1[2]);

        date3 = mm.ToString() + "/" + dd.ToString() + "/" + yy.ToString();

        if (mm > 12)
        {
            return 0;
        }
        if (mm == 2)
        {
            if (!((yy % 4 == 0 && yy % 100 != 0) || yy % 400 == 0))
            {
                if (dd > 28)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (dd > 29)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
        if (mm == 4 | mm == 6 | mm == 9 | mm == 11)
        {
            if (dd > 30)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        else
        {
            if (dd > 31)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }


    protected void btnbook_Click(object sender, EventArgs e)
    {
      
        if (validation() == true)
            {
                cn.Open();
                cmd = new SqlCommand("proc_booking", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@id", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Place", txtPlace.Text);
                cmd.Parameters.AddWithValue("@date", txtdate.Text);
                cmd.Parameters.AddWithValue("@Time", time);
                cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
                cmd.Parameters["@mode"].Value = "book";
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Cab Booked Sucessfully')</script>");
                cn.Close();
            }
    
        
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtPlace.Text  = "";
        txtAmount.Text = "";
        txtdate.Text = "";
       // txttime.Text = "";
    }
}
        
  

        
            
    

