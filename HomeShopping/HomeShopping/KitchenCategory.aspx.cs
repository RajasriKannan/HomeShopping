using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HomeShopping.BLL.RoomsByCategory;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace HomeShopping
{
    public partial class KitchenCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblUserName")).Text = Session["UserName"].ToString();
            hdnUserName.Value = ((Label)Master.FindControl("lblUserName")).Text;
            AddNewItemsVisibility("none");
            AddNewItemsNotInListVisibilityButton("none");
            AddNewItemsNotInListVisibility("none");
            EditItemsVisibility("none");

            if (!Page.IsPostBack)
            {
                BindKitchenCategory();
                BindListItemsByCategory();
            }
            else
            {
                hdnKitchenCategory.Value = ddlKitchenCategory.SelectedValue;
                hdnListItemsByCategory.Value = ddlListItemsByCategory.SelectedValue;
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);
            int ListItemsByCategoryID = Convert.ToInt32(hdnListItemsByCategory.Value);
            string userName = hdnUserName.Value;
            

            if (KitchenCategoryID == -1 || ListItemsByCategoryID == -1)
            {
                lblSelectCategory.Text = Messages.CATEGORYBINDER;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
                gvAddNewProducts.DataSource = null;
                gvAddNewProducts.DataBind();
            }
            else if(ListItemsByCategoryID == 1)
            {
                lblSelectCategory.Text = string.Empty;
                //dataSet = KitchenCategoryLogicsBLL.GetKitchenProductsByCategoryBLL(KitchenCategoryID, ListItemsByCategoryID, userName);
                BindGVAddProducts();
                ControlAddNewItemCategory(false);
            }
            else if (ListItemsByCategoryID > 1)
            {
                lblSelectCategory.Text = string.Empty;
                ControlEditItemCategory(false);
                BindGVToEditProducts();
                //gvEditProducts.DataSource = dataSet;
                //gvEditProducts.DataBind();

                //gvAddNewProducts.DataSource = null;
                //gvAddNewProducts.DataBind();

                //if (!(dataSet.Tables[0].Rows.Count == 0))
                //{
                //    gvEditProducts.DataSource = dataSet;
                //    gvEditProducts.DataBind();
                //}
                //else
                //{
                //    lblSelectCategory.Text = Messages.NOPRODUCTINDB;
                //    gvEditProducts.DataSource = null;
                //    gvEditProducts.DataBind();
                //}
                //gvAddNewProducts.DataSource = null;
                //gvAddNewProducts.DataBind();
            }
        }

        private void BindGVToEditProducts()
        {
            AddNewItemsNotInListVisibilityButton("block");

            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);
            int ListItemsByCategoryID = Convert.ToInt32(hdnListItemsByCategory.Value);
            string userName = hdnUserName.Value;

            DataSet dataSet;
            dataSet = KitchenCategoryLogicsBLL.GetKitchenProductsByCategoryToEditBLL(KitchenCategoryID, ListItemsByCategoryID, userName);
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                gvEditProducts.DataSource = dataSet;
                gvEditProducts.DataBind();
                gvAddNewProducts.DataSource = null;
                gvAddNewProducts.DataBind();
            }
            else
            {
                lblSelectCategory.Text = Messages.NOPRODUCTINDB;
                gvAddNewProducts.DataSource = null;
                gvAddNewProducts.DataBind();
                gvEditProducts.DataSource = null;
                gvEditProducts.DataBind();
            }
        }

        private void BindGVAddProducts()
        {
            AddNewItemsNotInListVisibilityButton("block");

            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);
            int ListItemsByCategoryID = Convert.ToInt32(hdnListItemsByCategory.Value);
            string userName = hdnUserName.Value;

            DataSet dataSet;
            dataSet = KitchenCategoryLogicsBLL.GetKitchenProductsByCategoryBLL(KitchenCategoryID, ListItemsByCategoryID, userName);
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                gvAddNewProducts.DataSource = dataSet;
                gvAddNewProducts.DataBind();
                gvEditProducts.DataSource = null;
                gvEditProducts.DataBind();
            }
            else
            {
                lblSelectCategory.Text = Messages.NOPRODUCTINDB;
                gvAddNewProducts.DataSource = null;
                gvAddNewProducts.DataBind();
                gvEditProducts.DataSource = null;
                gvEditProducts.DataBind();
            }

                
        }

        private void BindGVProducts(int ListItemsByCategoryID)
        {
            if(ListItemsByCategoryID == 1)
            {
                BindGVAddProducts();
            }
            else
            {
                BindGVToEditProducts();
            }
        }
        
        private void BindKitchenCategory()
        {
            DataSet dataSet;
            dataSet = KitchenCategoryLogicsBLL.GetKitchenCategoryBLL();
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                ddlKitchenCategory.DataSource = dataSet;
                ddlKitchenCategory.DataTextField = "texts";
                ddlKitchenCategory.DataValueField = "value";
                ddlKitchenCategory.DataBind();
                ddlKitchenCategory.Items.Insert(0, new ListItem("--Select Category--", "-1"));
            }
        }

        private DataSet  BindInStock()
        {
            DataSet dataSet;
            dataSet = ListItemsByCategoryBLL.GetInStockBLL();
            return dataSet;
        }

        private DataSet BindAddToCart()
        {
            DataSet dataSet;
            dataSet = ListItemsByCategoryBLL.GetAddToCartBLL();
            return dataSet;
        }

        private void BindListItemsByCategory()
        {
            DataSet dataSet;
            dataSet = ListItemsByCategoryBLL.GetListItemsByCategoryBLL();
            if (!(dataSet.Tables[0].Rows.Count == 0))
            {
                ddlListItemsByCategory.DataSource = dataSet;
                ddlListItemsByCategory.DataTextField = "texts";
                ddlListItemsByCategory.DataValueField = "value";
                ddlListItemsByCategory.DataBind();
                ddlListItemsByCategory.Items.Insert(0, new ListItem("--Select Category--", "-1"));
            }
        }

        
        protected void btnAddNewItemInList_Click(object sender, EventArgs e)
        {
            CleargvAddNewProductsBorderStyle();
            DataSet dataSetInStock = BindInStock();
            if (!(dataSetInStock.Tables[0].Rows.Count == 0))
            {
                ddlAddInStock.DataSource = dataSetInStock;
                ddlAddInStock.DataTextField = "texts";
                ddlAddInStock.DataValueField = "value";
                ddlAddInStock.DataBind();
            }
            DataSet dataSetAddToCart = BindAddToCart();
            if (!(dataSetAddToCart.Tables[0].Rows.Count == 0))
            {
                ddlAddAddTOCart.DataSource = dataSetAddToCart;
                ddlAddAddTOCart.DataTextField = "texts";
                ddlAddAddTOCart.DataValueField = "value";
                ddlAddAddTOCart.DataBind();
            }

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                row.BorderStyle = BorderStyle.Ridge;
                row.BorderColor = Color.DarkOliveGreen;

                txtAddProduct.Text = row.Cells[2].Text;
                txtAddQuantity.Text = row.Cells[3].Text;
                txtComments.Text = string.Empty;
            }
            AddNewItemsVisibility("block");
            AddNewItemsNotInListVisibilityButton("none");
            AddNewItemsNotInListVisibility("none");
            EditItemsVisibility("none");
        }

        protected void btnInsertProductInList_Click(object sender, EventArgs e)
        {
            //AddNewItemsVisibility("block");
            string userName = hdnUserName.Value;
            string Products = txtAddProduct.Text;
            int InStockID = Convert.ToInt32(ddlAddInStock.SelectedValue);
            int Quantity = Convert.ToInt32(txtAddQuantity.Text);
            int AddToCart = Convert.ToInt32(ddlAddAddTOCart.SelectedValue);
            string Comments = txtComments.Text;
            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);

            int result = KitchenCategoryLogicsBLL.InsertKitchenProductsBLL(userName, KitchenCategoryID, Products, Quantity, InStockID, AddToCart, Comments);
            if (result > 0)
            {
                BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
                lblSelectCategory.Text = Messages.ADDPRODUCTSUCCESS;
                lblSelectCategory.ForeColor = System.Drawing.Color.DarkOliveGreen;
                
                //DataSet dataSet = BindGVAddProducts();
                //gvAddNewProducts.DataSource = dataSet;
                //gvAddNewProducts.DataBind();
                //BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
            }
            else
            {
                lblSelectCategory.Text = Messages.ADDPRODUCTFAILURE;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelNewProductInList_Click(object sender, EventArgs e)
        {
            //BindGVAddProducts();
            BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
            lblSelectCategory.Text = string.Empty;
        }

        protected void btnAddNewItemsNotInList_Click(object sender, EventArgs e)
        {
            CleargvAddNewProductsBorderStyle();
            DataSet dataSetInStock = BindInStock();
            if (!(dataSetInStock.Tables[0].Rows.Count == 0))
            {
                ddlNITInStock.DataSource = dataSetInStock;
                ddlNITInStock.DataTextField = "texts";
                ddlNITInStock.DataValueField = "value";
                ddlNITInStock.DataBind();
            }
            DataSet dataSetAddToCart = BindAddToCart();
            if (!(dataSetAddToCart.Tables[0].Rows.Count == 0))
            {
                ddlNITAddToCart.DataSource = dataSetAddToCart;
                ddlNITAddToCart.DataTextField = "texts";
                ddlNITAddToCart.DataValueField = "value";
                ddlNITAddToCart.DataBind();
            }
            txtNITProduct.Text = string.Empty;
            txtNITQuantity.Text = string.Empty;
            txtNITComments.Text = string.Empty;
            lblSelectCategory.Text = string.Empty;

            AddNewItemsVisibility("none");
            AddNewItemsNotInListVisibilityButton("block");
            AddNewItemsNotInListVisibility("block");
            EditItemsVisibility("none");
        }

        protected void btnInsertProductNotInList_Click(object sender, EventArgs e)
        {
            string userName = hdnUserName.Value;
            string Products = txtNITProduct.Text;
            int InStockID = Convert.ToInt32(ddlNITInStock.SelectedValue);
            int Quantity =  Convert.ToInt32(txtNITQuantity.Text);
            int AddToCart = Convert.ToInt32(ddlNITAddToCart.SelectedValue);
            string Comments = (txtNITComments.Text != string.Empty) ? txtNITComments.Text : null;
            int KitchenCategory = Convert.ToInt32(hdnKitchenCategory.Value);

            int result = KitchenCategoryLogicsBLL.InsertKitchenProductsNotInListBLL(userName, KitchenCategory, Products, Quantity, InStockID, AddToCart, Comments);

            //DataSet dataSet = BindGVAddProducts();
            //gvAddNewProducts.DataSource = dataSet;
            //gvAddNewProducts.DataBind();
            BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));

            if (result > 0)
            {
                lblSelectCategory.Text = Messages.ADDPRODUCTSUCCESS;
                lblSelectCategory.ForeColor = System.Drawing.Color.DarkOliveGreen;
            }
            else if(result == -1)
            {
                lblSelectCategory.Text = Messages.ADDPRODUCTWARNING;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblSelectCategory.Text = Messages.ADDPRODUCTFAILURE;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelNewProductNotInList_Click(object sender, EventArgs e)
        {
            //BindGVAddProducts();
            BindGVProducts (Convert.ToInt32(hdnListItemsByCategory.Value));
            lblSelectCategory.Text = string.Empty;
        }

        protected void btnEditItem_Click(object sender, EventArgs e)
        {
            CleargvEditProductsBorderStyle();
            DataSet dataSetInStock = BindInStock();
            if (!(dataSetInStock.Tables[0].Rows.Count == 0))
            {
                ddlEditInStock.DataSource = dataSetInStock;
                ddlEditInStock.DataTextField = "texts";
                ddlEditInStock.DataValueField = "value";
                ddlEditInStock.DataBind();
            }
            DataSet dataSetAddToCart = BindAddToCart();
            if (!(dataSetAddToCart.Tables[0].Rows.Count == 0))
            {
                ddlEditAddToCart.DataSource = dataSetAddToCart;
                ddlEditAddToCart.DataTextField = "texts";
                ddlEditAddToCart.DataValueField = "value";
                ddlEditAddToCart.DataBind();
            }
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                row.BorderStyle = BorderStyle.Ridge;
                row.BorderColor = Color.DarkOliveGreen;

                txtEditProduct.Text = row.Cells[3].Text;
                txtEditQuantity.Text = row.Cells[4].Text;
                if(row.Cells[9].Text == "&nbsp;")
                {
                    txtEditComments.Text = string.Empty;
                }
                else
                {
                    txtEditComments.Text = row.Cells[9].Text;
                }
                var itemsAddToCart = ddlEditAddToCart.Items.FindByText(row.Cells[8].Text);
                if(itemsAddToCart != null)
                {
                    itemsAddToCart.Selected = true;
                }
                var itemsInStock = ddlEditInStock.Items.FindByText(row.Cells[6].Text);
                if(itemsInStock != null)
                {
                    itemsInStock.Selected = true;
                }
            }
            AddNewItemsVisibility("none");
            AddNewItemsNotInListVisibilityButton("none");
            AddNewItemsNotInListVisibility("none");
            EditItemsVisibility("block");
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            string EditProduct = txtEditProduct.Text;
            int EditQuantity = (txtEditQuantity.Text != null)? Convert.ToInt32(txtEditQuantity.Text ): 0;
            string EditComments = txtEditComments.Text;
            int EditInStockID = Convert.ToInt32(ddlEditInStock.SelectedValue);
            int EditAddToCart = Convert.ToInt32(ddlEditAddToCart.SelectedValue);
            string userName = hdnUserName.Value;
            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);

            int result = KitchenCategoryLogicsBLL.UpdateKitchenProductsBLL(userName, KitchenCategoryID, EditProduct, EditQuantity, EditInStockID, EditAddToCart, EditComments);
            BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
            if (result > 0)
            {
                lblSelectCategory.Text = Messages.UPDATEPRODUCTSUCCESS;
                lblSelectCategory.ForeColor = System.Drawing.Color.DarkOliveGreen;
            }
            else
            {
                lblSelectCategory.Text = Messages.UPDATEPRODUCTFAILURE;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
            }
            //BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
        }

        protected void btnUpdateDeleteItem_Click(object sender, EventArgs e)
        {
            string userName = hdnUserName.Value;
            int KitchenCategoryID = Convert.ToInt32(hdnKitchenCategory.Value);
            string DeleteProduct = txtEditProduct.Text;

            int results = KitchenCategoryLogicsBLL.DeleteKitchenProductsBLL(userName, KitchenCategoryID, DeleteProduct);
            BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
            if (results > 0)
            {
                lblSelectCategory.Text = Messages.DELETEPRODUCTSUCCESS;
                lblSelectCategory.ForeColor = System.Drawing.Color.DarkOliveGreen;
            }
            else
            {
                lblSelectCategory.Text = Messages.DELETEPRODUCTFAILURE;
                lblSelectCategory.ForeColor = System.Drawing.Color.Red;
            }
            //BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
        }

        protected void btnUpdateCancelItem_Click(object sender, EventArgs e)
        {
            BindGVProducts(Convert.ToInt32(hdnListItemsByCategory.Value));
            lblSelectCategory.Text = string.Empty;
        }

        private void ControlAddNewItemCategory(bool visible)
        {
            gvAddNewProducts.Columns[0].Visible = visible;
            gvAddNewProducts.Columns[1].Visible = visible;
            gvAddNewProducts.Columns[5].Visible = visible;
            gvAddNewProducts.Columns[6].Visible = visible;
            gvAddNewProducts.Columns[7].Visible = visible;
            gvAddNewProducts.Columns[8].Visible = visible;
        }

        private void ControlEditItemCategory(bool visible)
        {
            gvEditProducts.Columns[0].Visible = visible;
            gvEditProducts.Columns[1].Visible = visible;
            gvEditProducts.Columns[2].Visible = visible;
            gvEditProducts.Columns[5].Visible = visible;
            gvEditProducts.Columns[7].Visible = visible;
            gvEditProducts.Columns[10].Visible = visible;
            gvEditProducts.Columns[11].Visible = visible;
            gvEditProducts.Columns[12].Visible = visible;
            gvEditProducts.Columns[13].Visible = visible;
            gvEditProducts.Columns[14].Visible = visible;
        }

        private void CleargvAddNewProductsBorderStyle()
        {
            foreach (GridViewRow gvr in gvAddNewProducts.Rows)
            {
                gvr.BorderStyle = BorderStyle.None;
                gvr.BorderColor = Color.Empty;
            }
        }

        private void CleargvEditProductsBorderStyle()
        {
            foreach (GridViewRow gvr in gvEditProducts.Rows)
            {
                gvr.BorderStyle = BorderStyle.None;
                gvr.BorderColor = Color.Empty;
            }
        }

        private void AddNewItemsVisibility(string display)
        {
            if (display == "block")
            {
                AddNewItems.Attributes.Add("style", "display:block");
            }
            else
            {
                AddNewItems.Attributes.Add("style", "display:none");
            }
        }
        private void AddNewItemsNotInListVisibilityButton(string display)
        {
            if (display == "block")
            {
                btnAddNewItemsNotInList.Attributes.Add("style", "display:block");
            }
            else
            {
                btnAddNewItemsNotInList.Attributes.Add("style", "display:none");
            }
        }

        private void AddNewItemsNotInListVisibility(string display)
        {
            if (display == "block")
            {
                AddNewItemsNotInList.Attributes.Add("style", "display:block");
            }
            else
            {
                AddNewItemsNotInList.Attributes.Add("style", "display:none");
            }
        }

        private void EditItemsVisibility(string display)
        {
            if (display == "block")
            {
                EditIems.Attributes.Add("style", "display:block");
            }
            else
            {
                EditIems.Attributes.Add("style", "display:none");
            }
        }

    }
}