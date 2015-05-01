using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class InvItem
    {
        //declared the fields
        private string strItemNo;
        private string strDescription;
        private decimal decPrice;

        //declared constructors
        public InvItem(){}
        public InvItem(string itemNo, string description, decimal price)
        {
            this.ItemNo = strItemNo;
            this.Description = strDescription;
            this.Price = decPrice;
        }

        //declaring Item number property
        public string ItemNo
        {
            get
            {
                return strItemNo;
            }
            set
            {
                strItemNo = "";
            }
        }

        //declaring description property
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = "";
            }
        }

        //declaring price property
        public decimal Price
        {
            get
            {
                return decPrice;
            }
            set
            {
                decPrice = 0m;
            }
        }

        /// <summary>
        /// Method that displays the text
        /// </summary>
        /// <param name="sep"></param>
        /// <returns>string</returns>
        public string GetDisplayText(string sep)
        {
            return strItemNo + sep + decPrice.ToString("c") + sep + strDescription;
        }
    }
}
