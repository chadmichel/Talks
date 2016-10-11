using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPLRef.eCommerce.Database
{
    static class SeedData
    {
        public static void Add(string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sellerId = CreateSeller(conn);
                var catalogid = CreateCatalog(conn, sellerId, "TEST_CATALOG");
                var productId = CreateProduct(conn, catalogid);
                catalogid = CreateCatalog(conn, sellerId, "TEST_CATALOG_2");
            }
        }

        static int CreateSeller(SqlConnection connection)
        {
            var sql = @"
                insert into Sellers
                    (Name, UserName)
                values
                    (@name, 'bsmith') 

                select scope_identity()
            ";

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("name", "TEST_SELLER");
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    var id = Convert.ToInt32(reader[0]);
                    return id;
                }
            }
        }

        static int CreateCatalog(SqlConnection connection, int sellerId, string catalogName)
        {
            var sql = @"
                insert into Catalogs
                    (Name, SellerId)
                values
                    (@name, @sellerid) 

                select scope_identity()
            ";

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("name", catalogName);
                cmd.Parameters.AddWithValue("sellerid", sellerId);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    var id = Convert.ToInt32(reader[0]);
                    return id;
                }
            }
        }

        static int CreateProduct(SqlConnection connection, int catalogId)
        {
            var sql = @"
                insert into Products
                    (Name, CatalogId, IsDownloadable, Price, shippingweight, IsAvailable)
                values
                    (@name, @catalogid, 1, 5, 0, 1) 

                select scope_identity()
            ";

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("name", "TEST_PRODUCT");
                cmd.Parameters.AddWithValue("catalogid", catalogId);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    var id = Convert.ToInt32(reader[0]);
                    return id;
                }
            }
        }
    }
}
