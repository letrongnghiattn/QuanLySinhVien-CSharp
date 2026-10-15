using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlisinhvien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // 1. Nhập số lượng sinh viên
            int n = 0;
            do
            {
                Console.Write("Nhập số lượng sinh viên (n > 0): ");
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Số lượng không hợp lệ! Vui lòng nhập số nguyên > 0.\n");
                }
            } while (n <= 0);

            string[] hoTen = new string[n];
            double[] diem = new double[n];

            // 2. Nhập thông tin sinh viên
            Console.WriteLine("\n=== NHẬP THÔNG TIN SINH VIÊN ===");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nSinh viên thứ {i + 1}:");

                do
                {
                    Console.Write(" - Họ và tên: ");
                    hoTen[i] = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(hoTen[i]))
                    {
                        Console.WriteLine("   Họ tên không được để trống!");
                    }
                } while (string.IsNullOrEmpty(hoTen[i]));

                do
                {
                    Console.Write(" - Điểm số (0 - 10): ");
                    if (!double.TryParse(Console.ReadLine(), out diem[i]) || diem[i] < 0 || diem[i] > 10)
                    {
                        Console.WriteLine("   Điểm không hợp lệ! Nhập số từ 0 đến 10.");
                        diem[i] = -1;
                    }
                } while (diem[i] < 0 || diem[i] > 10);
            }

            // 3. Tính điểm trung bình
            double tongDiem = 0;
            for (int i = 0; i < n; i++)
            {
                tongDiem += diem[i];
            }
            double diemTB = tongDiem / n;

            // 4. Tìm điểm cao nhất
            double diemMax = diem[0];
            for (int i = 1; i < n; i++)
            {
                if (diem[i] > diemMax)
                {
                    diemMax = diem[i];
                }
            }

            // 5. Đếm số lượng đạt (Điểm >= 5.0)
            int soLuongDat = 0;
            for (int i = 0; i < n; i++)
            {
                if (diem[i] >= 5.0)
                {
                    soLuongDat++;
                }
            }

            // 6. In bảng danh sách và kết quả
            Console.WriteLine("\n=============================================");
            Console.WriteLine("          DANH SÁCH SINH VIÊN CẢ LỚP         ");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-5} | {1,-25} | {2,-8}", "STT", "Họ và tên", "Điểm");
            Console.WriteLine("---------------------------------------------");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-8:F2}", i + 1, hoTen[i], diem[i]);
            }
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine($"\n► Điểm trung bình cả lớp: {diemTB:F2}");

            Console.WriteLine($"► Điểm cao nhất lớp: {diemMax:F2}");
            Console.WriteLine("  Các sinh viên đạt điểm cao nhất:");
            for (int i = 0; i < n; i++)
            {
                if (diem[i] == diemMax)
                {
                    Console.WriteLine($"   - {hoTen[i]}");
                }
            }

            Console.WriteLine($"► Số lượng sinh viên đạt (Điểm >= 5.0): {soLuongDat}/{n} sinh viên");
            Console.WriteLine("=============================================");

            Console.WriteLine("\nẤn phím bất kỳ để thoát...");
            Console.ReadKey();

        }
        }
    }
