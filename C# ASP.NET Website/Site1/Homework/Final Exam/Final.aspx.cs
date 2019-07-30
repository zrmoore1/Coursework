using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homework_Final_Exam_Final : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Load the dropdown list
            LoadContactsList();
                
        }
        // Clear existing errors
        lstErrors.Items.Clear();
    }

    /// <summary>
    /// Brings up the panel to add new contact. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNewContact_Click(object sender, EventArgs e)
    {
        // Ensure no existing contact selected
        ddlContacts.SelectedIndex = -1;
        CloseViewContact();
        pnlAddEditContactInfo.Visible = true;
    }

    /// <summary>
    /// Brings up the panel to edit an existing contact.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        CloseViewContact();
        pnlAddEditContactInfo.Visible = true;
        ContactsDataContext cdcContacts = new ContactsDataContext();
        var qryQuery = from c in cdcContacts.TContacts
                    where c.intContactID == Convert.ToInt32(ddlContacts.SelectedValue)
                    select c;
        txtFirstName.Text = qryQuery.First().strFirstName;
        txtLastName.Text = qryQuery.First().strLastName;
        txtEmail.Text = qryQuery.First().strEmailAddress;
        txtPhone.Text = qryQuery.First().strPhoneNumber;
        chkActive.Checked = qryQuery.First().blnActive;
    }

    /// <summary>
    /// Deletes the record being currently viewed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ContactsDataContext cdcContacts = new ContactsDataContext();

        var recContact = cdcContacts.TContacts.Single(c => c.intContactID == Convert.ToInt32(ddlContacts.SelectedValue));
        cdcContacts.TContacts.DeleteOnSubmit(recContact);
        cdcContacts.SubmitChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    /// <summary>
    /// Views the record associated with the selected item on the dropdownlist.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlContacts.SelectedIndex > 0)
        {
            ContactsDataContext cdcContacts = new ContactsDataContext();

            var qryQuery = from c in cdcContacts.TContacts
                        where c.intContactID == Convert.ToInt32(ddlContacts.SelectedValue)
                        select c;

            CloseAddContact();
            pnlViewContact.Visible = true;
            lblFirstName.Text = qryQuery.First().strFirstName;
            lblLastName.Text = qryQuery.First().strLastName;
            lblEmail.Text = qryQuery.First().strEmailAddress;
            lblPhone.Text = qryQuery.First().strPhoneNumber;
            lblActive.Text = (qryQuery.First().blnActive ? "True" : "False");
        }
        else { CloseViewContact(); }
    }

    /// <summary>
    /// After validation, adds a new record or updates an existing record. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // check all fields
        if (IsValidContact())
        {
            ContactsDataContext cdcContacts = new ContactsDataContext();


            if (ddlContacts.SelectedIndex > 0)
            {
                // Updating contact record
                var recContact = cdcContacts.TContacts.Single(c => c.intContactID == Convert.ToInt32(ddlContacts.SelectedValue));
                recContact.strFirstName = txtFirstName.Text;
                recContact.strLastName = txtLastName.Text;
                recContact.strEmailAddress = txtEmail.Text;
                recContact.strPhoneNumber = txtPhone.Text;
                recContact.blnActive = chkActive.Checked;
            }
            else
            {
                // Adding new contact
                TContact con = new TContact
                {
                    strFirstName = txtFirstName.Text,
                    strLastName = txtLastName.Text,
                    strEmailAddress = txtEmail.Text,
                    strPhoneNumber = txtPhone.Text,
                    blnActive = chkActive.Checked
                };
                cdcContacts.TContacts.InsertOnSubmit(con);
            }

            cdcContacts.SubmitChanges();
            CloseAddContact();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }

    /// <summary>
    /// Abort attempt to add or edit a record. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlContacts.SelectedIndex = 0;
        CloseAddContact();
    }
    /// <summary>
    /// Add active or inactive contacts to the dropdownlist, depending on whether the checkbox is checked. 
    /// </summary>
    private void LoadContactsList()
    {
        ContactsDataContext cdcContacts = new ContactsDataContext();

        var qryQuery = from c in cdcContacts.TContacts
                    where c.blnActive != chkShowInactive.Checked
                    orderby c.strLastName
                    select new
                    {
                        c.intContactID,
                        strName = c.strLastName + ", " + c.strFirstName
                    };
        ddlContacts.DataSource = qryQuery;
        ddlContacts.DataTextField = "strName";
        ddlContacts.DataValueField = "intContactID";
        ddlContacts.DataBind();
        ddlContacts.Items.Insert(0, new ListItem("- Choose Contact -", "-1"));
        ddlContacts.SelectedIndex = 0;
    }

    /// <summary>
    /// Checks that all fields are filled and that email and phone are valid.
    /// </summary>
    /// <returns>bool indicating if contact is valid.</returns>
    private bool IsValidContact()
    {
        bool blnIsValid = true;
        List<string> lstrErrors = new List<string>();

        
        if (txtFirstName.Text == "") { lstrErrors.Add("First Name cannot be blank."); blnIsValid = false; }
        if (txtLastName.Text == "") { lstrErrors.Add("Last Name cannot be blank."); blnIsValid = false; }

        if (!Regex.IsMatch(txtEmail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase)) 
        {
            lstrErrors.Add("Email is invalid"); blnIsValid = false;
        }

        if (!Regex.IsMatch(txtPhone.Text, @"^\(?\d{3}\)?[\s\-\.]?\d{3}[\s\-\.]?\d{4}$", RegexOptions.IgnoreCase))
        {
            lstrErrors.Add("Phone Number is invalid."); blnIsValid = false;
        }

        // Show the errors list
        if (blnIsValid != true)
        {
            foreach (string strError in lstrErrors)
            {
                lstErrors.Items.Add(strError);
            }
        }

        return blnIsValid;
    }

    /// <summary>
    /// Clears the contact info on the form and hides the add contact panel.
    /// </summary>
    private void CloseAddContact()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        chkActive.Checked = false;
        pnlAddEditContactInfo.Visible = false;
    }

    /// <summary>
    /// Hides the contact viewer.
    /// </summary>
    private void CloseViewContact()
    {
        lblFirstName.Text = "";
        lblLastName.Text = "";
        lblEmail.Text = "";
        lblPhone.Text = "";
        lblActive.Text = "";
        pnlViewContact.Visible = false;
    }

    /// <summary>
    /// Switches to viewing inactive contacts.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkShowInactive_CheckedChanged(object sender, EventArgs e)
    {
        CloseAddContact();
        CloseViewContact();
        udpNewContact.Update();
        LoadContactsList();
    }
}