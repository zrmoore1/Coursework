using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Name: Zachary Moore
 * Class: CPDM 152-400
 * Date: 3/7/2019
 * Abstract: Uses LINQ to populate a gridview with IDs and descriptions from the 
 *           northern territories (RegionID = 3) in the Northwind dataset. 
 */

public partial class Homework_week6_homework8 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NorthwindEntities nweNorthwind = new NorthwindEntities();

        var qryQuery = from pjnTerritories in nweNorthwind.Territories
                       where pjnTerritories.RegionID == 3
                       orderby pjnTerritories.TerritoryDescription
                       select new { pjnTerritories.TerritoryID, pjnTerritories.TerritoryDescription };

        this.grdNorthTerritories.DataSource = qryQuery.ToList();
        this.grdNorthTerritories.DataBind();
    }
}