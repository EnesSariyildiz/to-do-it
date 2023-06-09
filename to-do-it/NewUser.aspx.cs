﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace to_do_it
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblWarning.Visible = false;
            LblWarningAdmin.Visible = false;        
        }
        

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "admin")
            {
                LblWarningAdmin.Visible = true;
            }

            else if (string.IsNullOrEmpty(TxtUsername.Text) || string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                // TextBox'ların boş olup olmadığını kontrol ediyor. Boş ise uyarı yazısı ekliyoruz.
                LblWarning.Visible = true;
                
            }            
            else
            {
                // Boş değilse veri tabanına kullanıcıyı ekleme yapıyoruz.
                DataSet1TableAdapters.tbl_usersTableAdapter dt = new DataSet1TableAdapters.tbl_usersTableAdapter();
                dt.InsertUsers(TxtUsername.Text, TxtEmail.Text, TxtPassword.Text);
                Response.Redirect("Login.aspx");
                
            }

        }
    }
}
