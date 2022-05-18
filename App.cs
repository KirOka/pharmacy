using System;
using System.Collections.Generic;
using System.Text;

namespace pharmacy
{
    public static class App
    {
        /// <summary>
        /// Создать товар
        /// </summary>
        public static void CreateGood(string name)
        {
            Good good = new Good();
            good.Name = name;
            Repository.SqlCreateGood(good);
        }

        /// <summary>
        /// Удалить товар
        /// </summary>
        public static void DeleteGood(int id)
        {
            Repository.SqlDeleteGood(id);
        }

        /// <summary>
        /// Создать аптеку
        /// </summary>
        public static void CreatePharmacy(string name, string address, string phone)
        {
            Pharmacy pharmacy = new Pharmacy();
            pharmacy.Name = name;
            pharmacy.Address = address;
            pharmacy.Phone = phone;
            Repository.SqlCreatePharmacy(pharmacy);
        }

        /// <summary>
        /// Удалить аптеку
        /// </summary>
        public static void DeletePharmacy(int id)
        {
            Repository.SqlDeletePharmacy(id);
        }

        /// <summary>
        /// Получить список товаров в аптеке с остатками
        /// </summary>
        public static List<string> PharmacyContentList(int id)
        {
            return Repository.SqlPharmacyContentList(id);
        }

        /// <summary>
        /// Создать склад
        /// </summary>
        public static void CreateWarehouse(int PharmacyId, string name)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.PharmacyId = PharmacyId;
            warehouse.Name = name;
            Repository.SqlCreateWarehouse(warehouse);
        }

        /// <summary>
        /// Удалить склад
        /// </summary>
        public static void DeleteWarehouse(int id)
        {
            Repository.SqlDeleteWarehouse(id);
        }

        /// <summary>
        /// Создать партию
        /// </summary>
        public static void CreateBatch(int GoodId, int WarehouseId, double qty)
        {
            Batch batch = new Batch();
            batch.GoodId = GoodId;
            batch.WarehouseId = WarehouseId;
            batch.Quantity = qty;
            Repository.SqlCreateBatch(batch);
        }

        /// <summary>
        /// Удалить партию
        /// </summary>
        public static void DeleteBatch(int id)
        {
            Repository.SqlDeleteBatch(id);
        }
    }
}
