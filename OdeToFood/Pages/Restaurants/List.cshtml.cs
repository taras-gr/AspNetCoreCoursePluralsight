using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ILogger<ListModel> Logger { get; }

        public ListModel(IConfiguration config,
                        IRestaurantData restaurantData,
                        ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            Logger = logger;
        }
        public void OnGet()
        {
            Logger.LogError("Executing ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}