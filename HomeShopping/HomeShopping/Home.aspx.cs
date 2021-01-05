using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeShopping.BLL;
using HomeShopping.BLL.RoomsByCategory;

namespace HomeShopping
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblUserName")).Text = Session["UserName"].ToString();
            hdnUserName.Value = ((Label)Master.FindControl("lblUserName")).Text;

            if(!(Page.IsPostBack))
            {
                BindRoomsCategory();
            }
            else
            {
                hdnRoomCategory.Value = ddlRoomCategory.SelectedValue;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int selectedCategory = Convert.ToInt32(ddlRoomCategory.SelectedValue);
            string UserName = hdnUserName.Value;

            DataSet dataSet = HomeLogicsBLL.GetProductsByRoomCategoryBLL(UserName, selectedCategory);
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                lblSelectRoomCategory.Text = string.Empty;
            }
            else
            {
                lblSelectRoomCategory.Text = Messages.NOPRODUCTINDB;
            }
            gvProductsByRoomCategory.DataSource = dataSet;
            gvProductsByRoomCategory.DataBind();
            ControlGetProductsByRoomCategory(false);
        }

        private void BindRoomsCategory()
        {
            DataSet dataSet;
            dataSet = ListItemsByCategoryBLL.GetRoomsCategoryDAL();
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                ddlRoomCategory.DataSource = dataSet;
                ddlRoomCategory.DataTextField = "texts";
                ddlRoomCategory.DataValueField = "value";
                ddlRoomCategory.DataBind();
                ddlRoomCategory.Items.Insert(0, new ListItem("All Rooms", "0"));
            }
        }

        private void ControlGetProductsByRoomCategory(bool visible)
        {
            gvProductsByRoomCategory.Columns[0].Visible = visible;
            gvProductsByRoomCategory.Columns[1].Visible = visible;
            gvProductsByRoomCategory.Columns[3].Visible = visible;
            gvProductsByRoomCategory.Columns[7].Visible = visible;
            gvProductsByRoomCategory.Columns[9].Visible = visible;
            gvProductsByRoomCategory.Columns[12].Visible = visible;
            gvProductsByRoomCategory.Columns[13].Visible = visible;
            gvProductsByRoomCategory.Columns[14].Visible = visible;
            gvProductsByRoomCategory.Columns[15].Visible = visible;
            gvProductsByRoomCategory.Columns[16].Visible = visible;
        }
    }
}