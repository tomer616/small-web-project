using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using website.models;

namespace website
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            }
        }
        protected void Send_Click(object sender, EventArgs e) // User click on send button
        {
            // TODO: VALIDATE LENGTHS OF FIELDS AND EMAIL VALIDATION (IS EXISTS)
            dbHandler dbh = new dbHandler();
            if (!UserName.Text.Equals("") && !Password.Text.Equals("") && !ConfirmPassword.Text.Equals("") &&
                !LastName.Text.Equals("") && !FirstName.Text.Equals("") && !Email.Text.Equals(""))
            {
                bool isLenghtOK = true;

                if (UserName.Text.Length > 50)
                {
                    isLenghtOK = false;
                    UserName.BackColor = Color.Red;
                    UserName.ForeColor = Color.White;
                    Response.Write("<script>alert('שם המשתמש שכתבת ארוך מדי. נא לכתוב מקסימום 50 תווים');</script>");
                }
                else
                {
                    UserName.BackColor = Color.White;
                    UserName.ForeColor = Color.Black;
                }
                if (Password.Text.Length > 10)
                {
                    isLenghtOK = false;
                    Password.BackColor = Color.Red;
                    Password.ForeColor = Color.White;
                    Response.Write("<script>alert('הסיסמא שכתבת ארוכה מדי. נא לכתוב מקסימום 10 תווים');</script>");
                }
                else
                {
                    Password.BackColor = Color.White;
                    Password.ForeColor = Color.Black;
                }

                if(Password.Text!=ConfirmPassword.Text)
                {
                    isLenghtOK = false;
                    Password.BackColor = Color.Red;
                    Password.ForeColor = Color.White;
                    Response.Write("<script>alert('Password is different than confirm password');</script>");
                }
                else
                {
                    Password.BackColor = Color.White;
                    Password.ForeColor = Color.Black;
                }

                if (isLenghtOK)
                {
                    string checkUserInDBResult = dbh.isUserExists(UserName.Text, Email.Text);
                    if (checkUserInDBResult != "")
                        Response.Write("<script>alert('" + checkUserInDBResult + "');</script>");
                    else
                    {
                        //user does not exist-->can be saved
                        if(dbh.insertNewUser(UserName.Text,FirstName.Text,LastName.Text,Password.Text,Email.Text))
                        {
                            Response.Write("<script>alert('הרשמתך הסיימה בהצלחה');window.open('StudentPage.html','_self');</script>");
                            clsUser currUser = new clsUser();
                            currUser.Email = Email.Text;
                            currUser.FirstName = FirstName.Text;
                            currUser.IsBlocked = false;
                            currUser.IsManager = false;
                            currUser.IsStatus = 0;
                            currUser.LastName = LastName.Text;
                            currUser.UserName = UserName.Text;
                            Session["userInformation"] = currUser;
                        }
                        else
                        {
                            Response.Write("<script>alert('עכב תקלת מערכת, הרשמתך נכשלה. לנסות שוב');</script>");
                        }
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Some fields are empty');</script>");
            }

        }

        protected void Back_Click(object sender, EventArgs e) // User click on back button
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