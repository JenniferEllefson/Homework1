using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
	{
		public frmInvMaint()
		{
			InitializeComponent();
		}

        // Add a statement here that declares the list of items.
        List<InvItem> invItem = new List<InvItem>();

		private void frmInvMaint_Load(object sender, System.EventArgs e)
		{
            // Add a statement here that gets the list of items.
            invItem = InvItemDB.GetItems();
			FillItemListBox();
		}

		private void FillItemListBox()
		{
			lstItems.Items.Clear();
            // Add code here that loads the list box with the items in the list.
            foreach (InvItem i in invItem)
            {
                lstItems.Items.Add(i.GetDisplayText("\t"));
            }
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            // Add code here that creates an instance of the New Item form
            frmNewItem newItemForm = new frmNewItem();
            // and then gets a new item from that form.
            InvItem invItems = newItemForm.GetNewItem();

            if (invItem != null)
            {
                invItems.Add(invItem);
                InvItemDB.SaveItems(invItem);
                FillItemListBox();
            }
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			int i = lstItems.SelectedIndex;
			if (i != -1)
			{
                // Add code here that displays a dialog box to confirm
                // the delection and then removes the item from the list,
                // saves the list of products, and refreshes the list box
                // if the deletion is confirmed.
                InvItem invItems = invItem[i];
                string strMessage = "Are you sure you want to delete " + invItems.Description + "?";
                DialogResult button = MessageBox.Show(strMessage, "Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    invItem.Remove(invItems);
                    InvItemDB.SaveItems(invItem);
                    FillItemListBox();
                }
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}