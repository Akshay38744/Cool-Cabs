using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (Session["name"] == null)
        {
            btnlogin.Visible = true;
            A1.Visible = true;
        }

       if (Session["name"] == "Admin" && Session["pwd"] == "Admin123")
        {
            A2.Visible = true;
        }

    }

    
}
