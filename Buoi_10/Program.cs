using System;
using Buoi_10.DTA.Interface;
using Buoi_10.DTA.Employ;
using Buoi_10.DTA.DTO;

namespace Buoi_10.Program
{
    public class Employee
    {
        private readonly IQuanLyNhanVien manager;

        public Employee()
        {
            manager = new QuanLyNhanVien();
        }

        public static void Main()
        {
            Employee program = new Employee();
            while (true)
            {
                program.DisplayMenu();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Chức năng không hợp lệ, vui lòng chọn lại!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        program.AddEmployee();
                        break;

                    case 2:
                        program.ProcessProductionOutput();
                        break;

                    case 3:
                        program.ExportReport();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Chức năng không hợp lệ, vui lòng chọn lại!");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Thêm nhân viên");
            Console.WriteLine("2. Tạo sản lượng theo công đoạn của từng nhân viên");
            Console.WriteLine("3. Xuất và hiển thị báo cáo");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn chức năng: ");
        }
        

        private void AddEmployee()
        {
  
            manager.AddEmployy();
        }

        private void ProcessProductionOutput()
        {
            Console.Write("Nhập ID nhân viên: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID nhân viên không hợp lệ.");
                return;
            }

            Console.Write("Nhập mã công đoạn: ");
            string stageCode = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stageCode))
            {
                Console.WriteLine("Mã công đoạn không được để trống.");
                return;
            }

            Console.Write("Nhập tên công đoạn: ");
            string stageName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stageName))
            {
                Console.WriteLine("Tên công đoạn không được để trống.");
                return;
            }

            Console.Write("Nhập số lượng sản phẩm: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Số lượng sản phẩm không được nhỏ hơn 0.");
                return;
            }

            Stage stage = new Stage(stageCode, stageName, quantity);
            manager.Generateoutput(id, stage);
        }

        private void ExportReport()
        {
            manager.ExportReport();
        }
    }
}
