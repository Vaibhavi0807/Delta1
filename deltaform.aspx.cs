using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeltaWare
{
    public partial class deltaform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }
        public void btnFetch_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();

        }
        private void PopulateGridView();
        {
        string apiUrl = "http://localhost:44371/api/DeltaController";
        object input = new
        {
            Name = txtProductId.Text.Trim(),
        };
        
        }
    }
}