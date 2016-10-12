using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Managers;
using System;
using DPLRef.eCommerce.Contracts.WebStore.Catalog;

namespace DPLRef.eCommerce.Client.WebStore
{
    public class Program
    {
        static void Main()
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
                    case 1: // Show the catalog
                        ShowCatalog(1);
                        break;
                    case 2: // Show catalog not found
                        ShowCatalog(-1);
                        break;
                    case 3: // Show product detail
                        ShowProductDetail(1);
                        break;
                    case 4: // Show product not found
                        ShowProductDetail(-1);
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
            Console.WriteLine(" 1: Show the catalog");
            Console.WriteLine(" 2: Show catalog not found");
            Console.WriteLine(" 3: Show product details");
            Console.WriteLine(" 4: Show product not found");
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

        private static void ShowCatalog(int catalogId)
        {
            var context = new AmbientContext() { SellerId = 1, CatalogId = catalogId};
            var managerFactory = new ManagerFactory(context);
            var webStoreCatalogManager = managerFactory.CreateManager<IWebStoreCatalogManager>();
            var response = webStoreCatalogManager.ShowCatalog();
            ShowResponse(response, Common.Utilities.StringUtilities.DataContractToJson<WebStoreCatalog>(response.Catalog));
        }

        private static void ShowProductDetail(int productId)
        {
            var context = new AmbientContext() { SellerId = 1};
            var managerFactory = new ManagerFactory(context);
            var webStoreCatalogManager = managerFactory.CreateManager<IWebStoreCatalogManager>();
            var response = webStoreCatalogManager.ShowProduct(productId);
            ShowResponse(response, Common.Utilities.StringUtilities.DataContractToJson<ProductDetail>(response.Product));
        }
    }
}
