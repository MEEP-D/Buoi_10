using System;
using System.Collections.Generic;
using Buoi_10.DTA.DTO;
using Buoi_10.DTA.Interface;
using Buoi_10.Program;

namespace Buoi_10.DTA.Employ
{
    public class QuanLyNhanVien : IQuanLyNhanVien
    {
        private readonly List<Employy> employys;

        public QuanLyNhanVien()
        {
            employys = new List<Employy>();
        }
        public void AddEmployy(Employy employy)
        {
            try
            {
                Console.Write("Nhập ID: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("ID không hợp lệ.");
                    return;
                }
                employy.Id = id;

                Console.Write("Nhập tên: ");
                employy.Name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(employy.Name))
                {
                    Console.WriteLine("Tên không được để trống.");
                    return;
                }

                Console.Write("Nhập giới tính: ");
                employy.Gender = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(employy.Gender))
                {
                    Console.WriteLine("Giới tính không được để trống.");
                    return;
                }

                Console.Write("Nhập tuổi: ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Tuổi phải lớn hơn 0.");
                    return;
                }
                employy.Age = age;

                Console.Write("Nhập lương cơ bản: ");
                if (!double.TryParse(Console.ReadLine(), out double baseSalary) || baseSalary <= 0)
                {
                    Console.WriteLine("Lương cơ bản phải lớn hơn 0.");
                    return;
                }
                employy.BaseSalary = baseSalary;

                Console.Write("Nhập hệ số lương: ");
                if (!double.TryParse(Console.ReadLine(), out double salaryCoefficient) || salaryCoefficient <= 0)
                {
                    Console.WriteLine("Hệ số lương phải lớn hơn 0.");
                    return;
                }
                employy.SalaryCoefficient = salaryCoefficient;

                Console.Write("Nhập phụ cấp: ");
                if (!double.TryParse(Console.ReadLine(), out double allowance) || allowance < 0)
                {
                    Console.WriteLine("Phụ cấp không được nhỏ hơn 0.");
                    return;
                }
                employy.Allowance = allowance;

                if (!employys.Exists(nv => nv.Id == employy.Id))
                {
                    employys.Add(employy);
                    Console.WriteLine("Thêm nhân viên thành công.");
                }
                else
                {
                    Console.WriteLine("Nhân viên đã tồn tại hoặc thông tin không hợp lệ.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Dữ liệu nhập vào không hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        public Employy SearchEmployy(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("ID không hợp lệ. Vui lòng nhập ID lớn hơn 0.");
                return null;
            }

            var employy = employys.Find(nv => nv.Id == id);
            if (employy == null)
            {
                Console.WriteLine("Không tìm thấy nhân viên với ID này.");
            }
            return employy;
        }

        public void Generateoutput(int id, Stage stage)
        {
            var employy = SearchEmployy(id);
            if (employy != null && stage != null)
            {
                employy.Stages.Add(stage);
            }
            else
            {
                Console.WriteLine("Nhân viên không tồn tại hoặc thông tin công đoạn không hợp lệ.");
            }
        }

        public void ExportReport()
        {
            foreach (var employy in employys)
            {
                Console.WriteLine($"Nhân viên: {employy.Name}, Tổng lương: {employy.TotalSalary}");
                Console.WriteLine("Công đoạn: ");
                foreach (var stage in employy.Stages)
                {
                    Console.WriteLine($"Mã công đoạn: {stage.Stagecode}, Tên công đoạn: {stage.Stagename}, Số lượng sản phẩm: {stage.Quantity}");
                }
                Console.WriteLine();
            }
        }
    }
}
