using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website.models;

namespace website
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                string[] pathArr = path.Split('/');//////every "/" split.
                string pageName = pathArr[pathArr.Length - 1];

                ManageUsers.Visible = false;
                if (Session["userInformation"] != null)
                {
                    clsUser currUser = (clsUser)Session["userInformation"];
                    if (currUser.IsManager)
                    {
                        ManageUsers.Visible = true;
                        Home.NavigateUrl = "WELCOME2!.aspx";
                    }
                }

                    generateNavLinks(pageName);

                bool userIsLogged = checkLoggedUser();

                if (!userIsLogged)
                {
                    if (!pageName.Equals("Register.aspx") && !pageName.Equals("Login.aspx") && !pageName.Equals("ForgotPassword.aspx") && !pageName.Equals("ResetPassword.aspx"))
                    {
                    Response.Redirect(@"/Login.aspx");
                    }
                }
                else
                {
                    clsUser currUser = (clsUser)Session["userInformation"];
                    lblCurrUserName.Text = currUser.UserName;
                    if (pageName.Equals("Register") || pageName.Equals("Login") || pageName.Equals("ForgotPassword") || pageName.Equals("ResetPassword"))
                    {
                        Response.Redirect(@"/WELCOME!.aspx");
                    }
                }
            }
        }

        private bool checkLoggedUser()
        {
            if (Session["userInformation"] == null)
                return false;
            return true;
        }

        private void generateNavLinks(string pageName)
        {
            //List<String> linksIDs = new List<String>();
            //linksIDs.Add("Home");
            //linksIDs.Add("Guide");
            //linksIDs.Add("Articles");
            //linksIDs.Add("Forum");
            //linksIDs.Add("AddingNewSet");
            //linksIDs.Add("ChooseExistSetOfFilters");
            //linksIDs.Add("UsingOurAlgorithm");

            if (pageName.Equals("Register") || pageName.Equals("Login") || pageName.Equals("ResetPassword") || pageName.Equals("ForgotPassword"))
            {
                Home.Visible = false;
                Guide.Visible = false;

                Forum.Visible = false;
                AddingNewSet.Visible = false;
                ChooseExistSetOfFilters.Visible = false;
                UsingOurAlgorithm.Visible = false;
                LogoutButton.Visible = false;
                ManageUsers.Visible = false;
            }
            else if (pageName.Equals("WELCOME!") || pageName.Equals("welcome2!"))
            {
                
                Home.Visible = true;
                Guide.Visible = true;

                Forum.Visible = true;
                AddingNewSet.Visible = false;
                ChooseExistSetOfFilters.Visible = false;
                UsingOurAlgorithm.Visible = false;
                LogoutButton.Visible = true;
                ManageUsers.Visible = true;
                if (pageName.Equals("WELCOME!"))
                {
                    ManageUsers.Visible= false;
         
                }
            }
            else if (Home.ID.Equals(pageName))
            {
                Home.NavigateUrl = "";
                Home.CssClass = "nav-link currentPage";
            }
            else if (Guide.ID.Equals(pageName))
            {
                Guide.NavigateUrl = "";
                Guide.CssClass = "nav-link currentPage";
            }

            else if (Forum.ID.Equals(pageName))
            {
                Forum.NavigateUrl = "";
                Forum.CssClass = "nav-link currentPage";
            }
            else if (Guide.ID.Equals(pageName))
            {
                Guide.NavigateUrl = "";
                Guide.CssClass = "nav-link currentPage";
            }
            else if (AddingNewSet.ID.Equals(pageName))
            {
                AddingNewSet.NavigateUrl = "";
                AddingNewSet.CssClass = "nav-link currentPage";
            }
            else if (ChooseExistSetOfFilters.ID.Equals(pageName))
            {
                ChooseExistSetOfFilters.NavigateUrl = "";
                ChooseExistSetOfFilters.CssClass = "nav-link currentPage";
            }
            else if (UsingOurAlgorithm.ID.Equals(pageName))
            {
                UsingOurAlgorithm.NavigateUrl = "";
                UsingOurAlgorithm.CssClass = "nav-link currentPage";
            }

        }
        protected void onClickLogOut(object sender, EventArgs e)
        {
            clsUser currUser = (clsUser)Session["userInformation"];
            if (currUser != null)
            {
                dbHandler dbh = new dbHandler();
                dbh.changeIsStatus(currUser.UserName, Convert.ToByte(currUser.IsStatus));
                Session.Remove("userInformation");
                Session.Abandon();
                Response.Redirect(@"/Login.aspx");
            }
        }

    }
}
