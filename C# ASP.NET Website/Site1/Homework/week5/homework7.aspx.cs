using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 2/10/2019
 * Abstract: Code behind for homework7.aspx.  
 */

public partial class Homework_week5_homework7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblErrorMessage.Text = string.Empty;
    }
    protected void fmvRegions_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            this.lblErrorMessage.Text = e.Exception.Message;
            e.ExceptionHandled = true;
        }
    }
    protected void fmvRegions_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            this.lblErrorMessage.Text = e.Exception.Message;
            e.ExceptionHandled = true;
        }
    }
    protected void fmvRegions_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            this.lblErrorMessage.Text = e.Exception.Message;
            e.ExceptionHandled = true;
        }
    }
}