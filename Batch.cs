using System;
using System.Collections.Generic;
using System.Text;

namespace pharmacy
{
    /// <summary>
    /// Партия
    /// </summary>
    public class Batch
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id товара
        /// </summary>
        public int GoodId { get; set; }

        /// <summary>
        /// Id склада
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double Quantity { get; set; }
    }
}
