using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace pharmacy
{
    /// <summary>
    /// Хранилище
    /// </summary>
    public static class Repository
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public static string connectionString = @"packet size=4096;user id=sa;password=vrn3K8;data source=192.168.134.120\SQLEXPRESS;persist security info=True;initial catalog=pharmacy;Connect Timeout=10";

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        public static SqlConnection connect;

        /// <summary>
        /// Открыть подключение
        /// </summary>
        public static void openConnect()
        {
            try
            {
                if ((connect == null) || (connect.State != ConnectionState.Open))
                {
                    connect = new SqlConnection(connectionString);
                    connect.Open();
                }
            }
            catch
            {
                throw new Exception("Не удалось подключиться к БД.");
            }
        }

        /// <summary>
        /// Закрыть подключение
        /// </summary>
        public static void closeConnect()
        {
            try
            {
                connect.Close();
            }
            catch
            {
                throw new Exception("Не удалось отключиться от БД.");
            }
        }

        /// <summary>
        /// SQL запрос создания товара
        /// </summary>
        /// <param name="good">Товар</param>
        public static void SqlCreateGood(Good good)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("CreateGood");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@name", good.Name));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос создания аптеки
        /// </summary>
        /// <param name="pharmacy">Аптека</param>
        public static void SqlCreatePharmacy(Pharmacy pharmacy)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("CreatePharmacy");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@name", pharmacy.Name));
            Cmd.Parameters.Add(new SqlParameter("@address", pharmacy.Address));
            Cmd.Parameters.Add(new SqlParameter("@phone", pharmacy.Name));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос создания склада
        /// </summary>
        /// <param name="warehouse">Склад</param>
        public static void SqlCreateWarehouse(Warehouse warehouse)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("CreateWarehouse");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@PharmacyId", warehouse.PharmacyId));
            Cmd.Parameters.Add(new SqlParameter("@name", warehouse.Name));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос создания партии
        /// </summary>
        /// <param name="batch">Партия</param>
        public static void SqlCreateBatch(Batch batch)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("CreateBatch");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@GoodId", batch.GoodId));
            Cmd.Parameters.Add(new SqlParameter("@WarehouseId", batch.WarehouseId));
            Cmd.Parameters.Add(new SqlParameter("@qty", batch.Quantity));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос удаления товара
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public static void SqlDeleteGood(int id)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("DeleteGood");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@id", id));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос удаления аптеки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public static void SqlDeletePharmacy(int id)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("DeletePharmacy");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@id", id));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос удаления склада
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public static void SqlDeleteWarehouse(int id)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("DeleteWarehouse");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@id", id));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос удаления партии
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public static void SqlDeleteBatch(int id)
        {
            openConnect();

            SqlCommand Cmd = new SqlCommand("DeleteBatch");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@id", id));
            Cmd.ExecuteNonQuery();

            closeConnect();
        }

        /// <summary>
        /// SQL запрос списка товаров и его количеств в аптеке
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public static List<string> SqlPharmacyContentList(int id)
        {
            List<string> res = new List<string>();
            openConnect();

            SqlCommand Cmd = new SqlCommand("PharmacyContentList");
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = connect;
            Cmd.Parameters.Add(new SqlParameter("@id", id));
            using (SqlDataReader dr = Cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string good = dr.GetString("Good");
                    decimal qty = dr.GetDecimal("Qty");
                    res.Add(good + "\t" + qty.ToString());
                }
                dr.Close();
            }

            closeConnect();

            return res;
        }
    }
}
