using System;
using System.Collections.Generic;
using System.Text;

namespace pharmacy
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class Pharmacy
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
    }
}
