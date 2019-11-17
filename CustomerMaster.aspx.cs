using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class CustomerMaster : System.Web.UI.Page
{
    clsCustomerMaster obj = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = 1;
        if (!IsPostBack)
        {
            this.BindGridView();
        }
    }

    private void BindGridView()
    {
        obj = new clsCustomerMaster();
        gvCustomer.DataSource = obj.SelectCustomer(0);
        gvCustomer.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        obj = new clsCustomerMaster();
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        string hdf = (gvr.FindControl("hdfCustomerIDft") as HiddenField).Value;
        obj.CustomerID = (hdf == string.Empty || hdf == "0") ? 0 : Convert.ToInt32(hdf);
        obj.Name = (gvr.FindControl("txtName") as TextBox).Text.Trim();
        obj.MobileNo = (gvr.FindControl("txtMobileNo") as TextBox).Text.Trim();
        obj.EmailID = (gvr.FindControl("txtEmailID") as TextBox).Text.Trim();
        obj.Gender = (gvr.FindControl("rdbGender") as RadioButtonList).SelectedItem.Text;
        obj.UserID = Convert.ToInt32(Session["UserID"]);
        if (obj.InsertUpdateCustomer(obj) > 0)
        {
            lblmsg.Text = "Record " + ((hdf == string.Empty || hdf == "0") ? "Inserted" : "Updated") + " Successfully";
            Clear(gvr);
            this.BindGridView();
        }
        else
        {
            lblmsg.Text = "Opertation Failed!!!";
        }
    }

    private void Clear(GridViewRow gvr)
    {
        (gvr.FindControl("hdfCustomerIDft") as HiddenField).Value = "0";
        (gvr.FindControl("txtName") as TextBox).Text = string.Empty;
        (gvr.FindControl("txtMobileNo") as TextBox).Text = string.Empty;
        (gvr.FindControl("txtEmailID") as TextBox).Text = string.Empty;
        (gvr.FindControl("rdbGender") as RadioButtonList).Items.FindByValue("Male").Selected = true;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        Clear(gvr);
        lblmsg.Text = string.Empty;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        obj = new clsCustomerMaster();
        obj.CustomerID = Convert.ToInt32(gvCustomer.DataKeys[gvr.RowIndex]["CustomerID"].ToString());
        obj.UserID = Convert.ToInt32(Session["UserID"]);
        if (obj.DeleteCustomer(obj) > 0)
        {
            lblmsg.Text = "Record Deleted Successfully";
            this.BindGridView();
        }
        else
        {
            lblmsg.Text = "Opertation Failed!!!";
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        GridViewRow gvr = ((Button)sender).Parent.Parent as GridViewRow;
        obj = new clsCustomerMaster();
        DataTable dt = obj.SelectCustomer(Convert.ToInt32(gvCustomer.DataKeys[gvr.RowIndex]["CustomerID"].ToString()));
        if (dt.Rows.Count > 0)
        {
            (gvCustomer.FooterRow.FindControl("hdfCustomerIDft") as HiddenField).Value = dt.Rows[0]["CustomerID"].ToString();
            (gvCustomer.FooterRow.FindControl("txtName") as TextBox).Text = dt.Rows[0]["Name"].ToString();
            (gvCustomer.FooterRow.FindControl("txtMobileNo") as TextBox).Text = dt.Rows[0]["MobileNo"].ToString();
            (gvCustomer.FooterRow.FindControl("txtEmailID") as TextBox).Text = dt.Rows[0]["EmailID"].ToString();
            (gvCustomer.FooterRow.FindControl("rdbGender") as RadioButtonList).Items.FindByValue(dt.Rows[0]["Gender"].ToString()).Selected = true;
        }
    }
}