using System;
using System.Collections.Generic;
using System.Text;

namespace pharmacy
{
    /// <summary>
    /// Склад
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Аптеки
        /// </summary>
        public int PharmacyId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}
