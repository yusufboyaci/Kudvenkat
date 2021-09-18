using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsDemo
{
    public partial class MyWebForm : Page
    {
        protected void Page_Load(object
            sender, EventArgs e)
        {
            Response.Write("Hello My webForms");
        }
    }
}