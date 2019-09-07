using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace website
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            }
        }
        protected void Get_Click(object sender, EventArgs e) // // בדיקה עם המסד נתונים שהסיסמה והיוזר של המשתמש מתאימים
        {
            dbHandler dal = new dbHandler();
            Hashtable prms = new Hashtable();
            prms.Add("UsernameOrEmail", UserName.Text);
            DataSet ds = dal.GetData("usp_getUserEmail", prms);
            if(ds!=null && ds.Tables!=null && ds.Tables[0].Rows.Count>0)
            {
                //UserName or Email recognized
                if (clsMail.SendMail(ds.Tables[0].Rows[0]["Email"].ToString(), "Password Reminder", ""))
                {
                    Response.Write("<script>alert('Your Password will be send to you in a couple of minutes');</script>");
                    Response.Redirect(@"/Login.aspx");
                }
                else
                    Response.Write("<script>alert('Sending your password to your email failed. Please Make sure you have SMTP server on you server and try again');</script>");
            }
            else
                Response.Write("<script>alert('The value you have inserted is not an Email not UserName in our dB');</script>");


            //Response.Redirect(@"/ResetPassword.aspx");
        }
        protected void Back_Click(object sender, EventArgs e) // // בדיקה עם המסד נתונים שהסיסמה והיוזר של המשתמש מתאימים
        {
            if (ViewState["PreviousPageUrl"] != null && !string.IsNullOrEmpty(ViewState["PreviousPageUrl"].ToString()))
            {
                try
                {
                    string prevPageFullPath = ViewState["PreviousPageUrl"].ToString();
                    int startpos = prevPageFullPath.LastIndexOf(@"/");
                    Response.Redirect(@"/" + prevPageFullPath.Substring(startpos + 1, prevPageFullPath.Length - startpos - 1));
                }
                catch { }
            }
        }
    }
}