using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 3/8/2019
 * Abstract: Handles the visibility and updates the gridview
 */

public partial class Homework_week9_homework9 : System.Web.UI.Page
{ 
    protected void btnNewProduct_Click(object sender, EventArgs e)
    {
        // Hide the gridview to make inserting easier.
        grdProducts.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Show the gridview when no longer inserting.
        grdProducts.Visible = true;
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        // Show the gridview when done inserting.
        grdProducts.Visible = true;
    }
    protected void fmvNewProduct_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        // Refresh the gridview upon successful insert. 
        grdProducts.DataBind();
    }
}