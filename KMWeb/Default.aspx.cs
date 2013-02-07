using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KMWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                HyperLinkKM.NavigateUrl = "CategoryView.aspx?CategoryId=1";
                HyperLinkWEBP.NavigateUrl = "CategoryView.aspx?CategoryId=2";
                HyperLinkStatistika.NavigateUrl = "CategoryView.aspx?CategoryId=3";
                HyperLinkNoCat.NavigateUrl = "CategoryView.aspx?CategoryId=4";

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/NewArticle.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Administration/NewArticle.aspx");
        }
    }
}
