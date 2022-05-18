using System;
using System.Collections.Generic;

namespace pharmacy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "create":
                            if (args.Length > 1)
                            {
                                switch (args[1])
                                {
                                    case "good":
                                        //1.Создать товар
                                        if (args.Length > 2)
                                        {
                                            App.CreateGood(args[2]);
                                            Console.WriteLine("Создан товар: " + args[2]);
                                        }
                                        break;
                                    case "pharmacy":
                                        //1.Создать аптеку
                                        if (args.Length > 4)
                                        {
                                            App.CreatePharmacy(args[2], args[3], args[4]);
                                            Console.WriteLine("Создана аптека: " + args[2]);
                                        }
                                        break;
                                    case "warehouse":
                                        //1.Создать склад
                                        if (args.Length > 3)
                                        {
                                            App.CreateWarehouse(Convert.ToInt32(args[2]), args[3]);
                                            Console.WriteLine("Создан склад: " + args[3]);
                                        }
                                        break;
                                    case "batch":
                                        //1.Создать партию
                                        if (args.Length > 4)
                                        {
                                            App.CreateBatch(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToDouble(args[4]));
                                            Console.WriteLine("Создана новая партия.");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Не верный объект.");
                                        break;
                                }
                            }
                            break;
                        case "delete":
                            if (args.Length > 1)
                            {
                                switch (args[1])
                                {
                                    case "good":
                                        //2.Удалить товар(удалить товар и все партии во всех аптеках, связанные с этим товаром)
                                        if (args.Length > 2)
                                        {
                                            App.DeleteGood(Convert.ToInt32(args[2]));
                                            Console.WriteLine("Удален товар: " + args[2]);
                                        }
                                        break;
                                    case "pharmacy":
                                        //2.Удалить аптеку(удалить аптеку, все склады аптеки и партии в складах)
                                        if (args.Length > 2)
                                        {
                                            App.DeletePharmacy(Convert.ToInt32(args[2]));
                                            Console.WriteLine("Удалена аптека: " + args[2]);
                                        }
                                        break;
                                    case "warehouse":
                                        //2.Удалить склад(удалить склад, все данные о партиях в этом складе)
                                        if (args.Length > 2)
                                        {
                                            App.DeleteWarehouse(Convert.ToInt32(args[2]));
                                            Console.WriteLine("Удален Склад: " + args[2]);
                                        }
                                        break;
                                    case "batch":
                                        //2.Удалить партию
                                        if (args.Length > 2)
                                        {
                                            App.DeleteBatch(Convert.ToInt32(args[2]));
                                            Console.WriteLine("Удалена партия: " + args[2]);
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Не верный объект.");
                                        break;
                                }
                            }
                            break;
                        case "list":
                            //1.Вывести на экран весь список товаров и его количество в выбранной аптеке(количество товара во всех складах аптеки)
                            if (args.Length > 1)
                            {
                                List<string> strs = App.PharmacyContentList(Convert.ToInt32(args[1]));
                                Console.WriteLine("Наименование\tКоличество");
                                foreach (string str in strs)
                                {
                                    Console.WriteLine(str);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Команда отсутствует.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Нажмите ввод чтобы закрыть окно.");
            Console.ReadLine();
        }
    }
}
