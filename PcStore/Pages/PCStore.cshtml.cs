using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PcStore.Pages
{
    public class PCStoreModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "You must enter your name!")]
        public string ClientName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You must enter your email address!")]
        public string ClientEmail { get; set; }

        [BindProperty]
        public string CPU { get; set; }

        [BindProperty]
        public bool AddRAM { get; set; }

        [BindProperty]
        public bool AddWaterCooling { get; set; }

        [BindProperty]
        public DateTime BuildCollectionDateTime { get; set; } = System.DateTime.Now;

        [BindProperty]
        public string SelectedOutlet { get; set; }

        public string ClientInfo;
        public string BuildOrderInfo;

        private float totalBuildCost;
        public string TotalBuildCostString;

        public string[] Outlets = { "Sim Lim Square", "Funan", "VivoCity", "Harbourfront Center", "Plaza Singapura" };

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            ClientInfo = ClientName + ", " + ClientEmail;

            BuildOrderInfo = CPU;
            if (CPU == "Intel i7")
            {
                totalBuildCost = 450.00f;
            }
            else if (CPU == "AMD Ryzen 7")
            {
                totalBuildCost = 420.00f;
            }
            else if (CPU == "Intel i5")
            {
                totalBuildCost = 350.00f;
            }

            if (AddRAM == true)
            {
                BuildOrderInfo += ", add RAM";
                totalBuildCost += 95.00f;
            }

            if (AddWaterCooling == true)
            {
                BuildOrderInfo += ", add Water Cooling";
                totalBuildCost += 75.00f;
            }

            TotalBuildCostString = "$" + totalBuildCost.ToString("N2");
        }
    }
}
