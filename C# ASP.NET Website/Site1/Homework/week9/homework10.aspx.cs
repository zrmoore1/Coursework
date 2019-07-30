using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 3/10/2019
 * Abstract: Allows user to create a file to store a list of CDs, then display
 *  the list in a label
 */ 

public partial class Homework_week9_homework10 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear the form on page refresh
        if (!Page.IsPostBack)
        {
            ClearForm();
        }
    }
    /// <summary>
    /// Adds the CD information on the form to CDInfo.txt and saves it in MiscFiles. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Get rid of the list
        lblAllCDs.Text = string.Empty;

        // Create the MiscFiles folder if it doesn't exist
        if (!System.IO.Directory.Exists(MapPath("~/MiscFiles")))
        {
            System.IO.Directory.CreateDirectory(MapPath("~/MiscFiles"));
        }

        if (System.IO.Directory.Exists(MapPath("~/MiscFiles")))
        {
            // Are the fields filled?
            if (!string.IsNullOrWhiteSpace(txtCDTitle.Text)
                && !string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                
                // Add new CD
                System.IO.File.AppendAllText( MapPath("~/MiscFiles/CDInfo.txt"), 
                    "Title: " + txtCDTitle.Text + Environment.NewLine
                    + "Artist: " + txtArtist.Text + Environment.NewLine + Environment.NewLine);

                // Report success
                ClearForm();
                lblErrorMessage.CssClass = "success";
                lblErrorMessage.Text = "CD added!";
            }
            else
            {
                lblErrorMessage.Text = "Enter a CD Title and Artist.";
            }

        }
        else
        {
            lblErrorMessage.Text = "Failed to create directory.";
        }

    }
    /// <summary>
    /// Displays all CDs in CDInfo.txt in a label. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnList_Click(object sender, EventArgs e)
    {
        // Get rid of any error messages
        ClearForm();

        // Does the directory exist?
        if (System.IO.Directory.Exists(MapPath("~/MiscFiles")))
        {
            // Does the file exist?
            if (System.IO.File.Exists(MapPath("~/MiscFiles/CDInfo.txt")))
            {
                // Yes, post the list in the label
                string strAllCDs = "<h1>All CDs</h1>" + System.IO.File.ReadAllText(MapPath("~/MiscFiles/CDInfo.txt"));
                strAllCDs = strAllCDs.Replace( Environment.NewLine, "<br/>");
                lblAllCDs.Text = strAllCDs;
               
            }
            else
            {
                // No, the file doesn't exist
                lblErrorMessage.Text = "No CDs have been entered!";
            }

        }
        else
        {
            // No, the directory doesn't exist
            lblErrorMessage.Text = "No CDs have been entered!";
        }
    }
    /// <summary>
    /// Resets the form. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    /// <summary>
    /// Empties all textboxes and resets all labels.
    /// </summary>
    private void ClearForm()
    {
        txtArtist.Text = string.Empty;
        txtCDTitle.Text = string.Empty;
        lblErrorMessage.Text = string.Empty;
        lblErrorMessage.CssClass = "error";
        lblAllCDs.Text = string.Empty;
    }
}