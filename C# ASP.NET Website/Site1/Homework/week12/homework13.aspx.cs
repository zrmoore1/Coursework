using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Name: Zach Moore
 * Class: CPDM 152-400
 * Date: 4/2/2019
 * Abstract: Populates the gridview based on user choice.
 */

public partial class Homework_week12_homework13 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grdCategoriesProducts.DataBind();
    }
    protected void btnShowCategories_Click(object sender, EventArgs e)
    {
        CategoryServiceReference.CategoriesandProducts csrCategoriesAndProducts = new CategoryServiceReference.CategoriesandProducts();
        grdCategoriesProducts.DataSource = csrCategoriesAndProducts.GetCategories();
        grdCategoriesProducts.DataBind();
    }
    protected void btnShowProducts_Click(object sender, EventArgs e)
    {
        CategoryServiceReference.CategoriesandProducts csrCategoriesAndProducts = new CategoryServiceReference.CategoriesandProducts();
        grdCategoriesProducts.DataSource = csrCategoriesAndProducts.GetProducts();
        grdCategoriesProducts.DataBind();
    }
}