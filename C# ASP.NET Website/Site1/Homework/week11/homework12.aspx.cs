using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 3/24/2019
 * Abstract: Populates the dropdownlist and two gridviews with information
 *  about customers from the NorthWind dataset.
 */ 
public partial class Homework_week11_homework12 : System.Web.UI.Page
{
    /// <summary>
    /// Fills the dropdownlist with the name of each customer. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlDataReader sdrReader;
            SqlConnection conConnection = new SqlConnection();
            conConnection.ConnectionString = ConfigurationManager.ConnectionStrings["strNorthWindConnectionString"].ConnectionString;

            SqlCommand scdCommand = new SqlCommand();
            scdCommand.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            scdCommand.CommandType = CommandType.Text;
            scdCommand.Connection = conConnection;

            scdCommand.Connection.Open();
            sdrReader = scdCommand.ExecuteReader(CommandBehavior.CloseConnection);

            ddlCustomers.DataSource = sdrReader;
            ddlCustomers.DataTextField = "CompanyName";
            ddlCustomers.DataValueField = "CustomerID";
            ddlCustomers.DataBind(); 
            ddlCustomers.Items.Insert(0, new ListItem("- Select a Customer -", "-1"));
            ddlCustomers.SelectedIndex = 0;

            scdCommand.Dispose();
            conConnection.Dispose();
        }
    }

    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCustomers.SelectedIndex != 0)
        {
            // Bind the customer info
            BindCustomerInfo();
            // Bind the order info
            BindOrderInfo();
        }
        else 
        {
            // Hide the grids if nothing selected
            grdCustomerInfo.DataBind();
            grdCustomerOrders.DataBind();
        }
    }

    protected void BindCustomerInfo()
    {
        BindGridView( grdCustomerInfo, "SELECT * FROM Customers WHERE CustomerID = @CUSTOMER" );
    }

    protected void BindOrderInfo()
    {
        BindGridView(grdCustomerOrders, "EXEC CustOrderHist @CustomerID = @CUSTOMER;");
    }
        /// <summary>
        /// Binds data to the selected gridview using the command with the selected customer. 
        /// </summary>
        /// <param name="grdGridView"></param>
        /// <param name="strCommand"></param>
        protected void BindGridView(GridView grdGridView, String strCommand)
        {
            SqlDataReader sdrReader;
            SqlConnection conConnection = new SqlConnection();
            conConnection.ConnectionString = ConfigurationManager.ConnectionStrings["strNorthWindConnectionString"].ConnectionString;
            SqlParameter parSelectedCustomerID;

            SqlCommand scdCommand = new SqlCommand();
            scdCommand.CommandText = strCommand;
            scdCommand.CommandType = CommandType.Text;
            scdCommand.Connection = conConnection;

            parSelectedCustomerID = new SqlParameter();
            parSelectedCustomerID.ParameterName = "@CUSTOMER";
            parSelectedCustomerID.SqlDbType = SqlDbType.VarChar;
            parSelectedCustomerID.Direction = ParameterDirection.Input;
            parSelectedCustomerID.Value = ddlCustomers.SelectedValue;

            scdCommand.Parameters.Add(parSelectedCustomerID);

            scdCommand.Connection.Open();
            sdrReader = scdCommand.ExecuteReader(CommandBehavior.CloseConnection);

            grdGridView.DataSource = sdrReader;
            grdGridView.DataBind();

            scdCommand.Dispose();
            conConnection.Dispose();
        }
}