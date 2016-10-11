using System;
using System.Net;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Common.Utilities;
using DPLRef.eCommerce.Contracts.Admin.Catalog;
using DPLRef.eCommerce.Managers;

namespace DPLRef.eCommerce.Client.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;
            // get the first menu selection
            int menuSelection = InitConsoleMenu();

            while (menuSelection != 99)
            {
                switch (menuSelection)
                {
                    case 0:
                        Console.WriteLine("Please enter a valid menu selection.");
                        Console.WriteLine();
                        break;
                    case 1: // Show the seller catalogs
                        FindCatalogs("MyToken");
                        break;
                    case 2: // Show seller not authenticated
                        FindCatalogs("");
                        break;
                    case 3: // Show a specific catalog
                        ShowCatalog(1);
                        break;
                    case 4: // Show catalog not found
                        ShowCatalog(-1);
                        break;
                    case 5:
                        ShowProduct(1);
                        break;
                    case 99:
                        exitApp = true;
                        break;
                }

                // check to see if we want to exit the app
                if (exitApp)
                {
                    break; // exit the while loop
                }

                // re-initialize the menu selection
                menuSelection = InitConsoleMenu();
            }
        }

        private static int InitConsoleMenu()
        {
            int result;

            Console.WriteLine("Select desired option:");
            Console.WriteLine(" 1: Show the list of seller catalogs");
            Console.WriteLine(" 2: Show seller not authenticated");
            Console.WriteLine(" 3: Show a specific catalog");
            Console.WriteLine(" 4: Show catalog not found");
            Console.WriteLine(" 5: Show product");
            Console.WriteLine(" 99: exit");
            string selection = Console.ReadLine();
            if (int.TryParse(selection, out result) == false)
            {
                result = 0;
            }

            return result;
        }

        private static void ShowResponse(ResponseBase response, String result)
        {
            Console.WriteLine($"Result: { response.Success}");
            Console.WriteLine($"Message: {response.Message}");
            Console.WriteLine(result);
        }

        private static void FindCatalogs(string authToken)
        {
            var context = new AmbientContext() { SellerId = 1, SellerAuthToken = authToken};
            var managerFactory = new ManagerFactory(context);
            var adminCatalogManager = managerFactory.CreateManager<IAdminCatalogManager>();
            var response = adminCatalogManager.FindCatalogs();
            ShowResponse(response, StringUtilities.DataContractToJson<WebStoreCatalog[]>(response.Catalogs));
        }

        private static void ShowCatalog(int catalogId)
        {
            var context = new AmbientContext() { SellerId = 1, CatalogId = catalogId, SellerAuthToken = "MyToken"};
            var managerFactory = new ManagerFactory(context);
            var adminCatalogManager = managerFactory.CreateManager<IAdminCatalogManager>();
            var response = adminCatalogManager.ShowCatalog();
            ShowResponse(response, StringUtilities.DataContractToJson<WebStoreCatalog>(response.Catalog));
        }

        private static void ShowProduct(int productId)
        {
            Console.WriteLine("Oops! Not implemented yet!");
        }
    }
}
