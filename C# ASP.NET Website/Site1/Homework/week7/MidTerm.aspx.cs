using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 2/25/2019
 * Abstract: Code behind for MidTerm.aspx - dynamically populates dropdown lists
 *  and a detailsview based on user selection
 */

public partial class Homework_week7_MidTerm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           NorthwindEntities nweNorthwind = new NorthwindEntities();

            var qryqryQuery = from pjnCustomers in nweNorthwind.Customers
                           orderby pjnCustomers.CompanyName
                           select new { pjnCustomers.CustomerID, pjnCustomers.CompanyName };

            this.ddlCustomers.DataSource = qryqryQuery.ToList();
            this.ddlCustomers.DataTextField = "CompanyName";
            this.ddlCustomers.DataValueField = "CustomerID";
            this.ddlCustomers.DataBind();
            this.ddlCustomers.Items.Insert(0, new ListItem("- Choose a customer -", "-1"));
            this.ddlCustomers.SelectedIndex = 0;
        }
    }

    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        NorthwindEntities nweNorthwind = new NorthwindEntities();

        var qryqryQuery = from pjnCustomerOrders in nweNorthwind.Orders
                       orderby pjnCustomerOrders.OrderID
                       where pjnCustomerOrders.CustomerID == ddlCustomers.SelectedItem.Value
                       select new { pjnCustomerOrders.OrderID };

        this.ddlOrders.DataSource = qryqryQuery.ToList();
        this.ddlOrders.DataTextField = "OrderID";
        this.ddlOrders.DataValueField = "OrderID";
        this.ddlOrders.DataBind();
        this.ddlOrders.Items.Insert(0, new ListItem("- Choose an order -", "-1"));
        this.ddlOrders.SelectedIndex = 0;


        lblOrders.Text = ddlCustomers.SelectedItem.Text + "'s Orders:";

        if (ddlOrders.Visible == false) { ddlOrders.Visible = true; }
        if (ddlCustomers.SelectedIndex == 0) { ddlOrders.Visible = false; lblOrders.Text = ""; }
        dtvOrderDetails.Visible = false;

        lblDetails.Text = "";
    }

    protected void ddlOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        NorthwindEntities nweNorthwind = new NorthwindEntities();

        var strOrderDetails = nweNorthwind.CustOrdersDetail(Convert.ToInt32(ddlOrders.SelectedItem.Value));

        this.dtvOrderDetails.DataSource = strOrderDetails.ToList();
        this.dtvOrderDetails.DataBind();

        if (dtvOrderDetails.Visible == false) { dtvOrderDetails.Visible = true; }
        if (ddlOrders.SelectedIndex != 0) { lblDetails.Text = "Order " + ddlOrders.SelectedItem.Text + ":"; }
        else{ lblDetails.Text = "";}
    }
}