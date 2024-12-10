using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GAME
{
    internal class BXH
    {

        static void LuuKetQUa(string Ten, int score)
        {
            if (Ten != "" && !String.IsNullOrWhiteSpace(Ten))
            {
                bool ContainName = false;
                File.AppendAllText("KetQuaNguoiChoi.txt", "");
                string[] OpenSaveFile = File.ReadAllLines("KetQuaNguoiChoi.txt");

                for (int i = 0; i < OpenSaveFile.Length / 3; i += 3)
                {
                    if (OpenSaveFile[i * 3].Contains(Ten))
                    {
                        if (score > int.Parse(OpenSaveFile[i + 1]))
                        {

                            OpenSaveFile[i * 3 + 1] = score.ToString();
                            OpenSaveFile[i * 3 + 2] = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                        }
                        ContainName = true;
                    }
                    if (ContainName) break;
                }
                if (!ContainName)
                    OpenSaveFile = OpenSaveFile.Concat(new string[] { Ten, score.ToString(), DateTime.Now.ToString("HH:mm dd/MM/yyyy") }).ToArray();

                File.WriteAllLines("KetQuaNguoiChoi.txt", OpenSaveFile);
            }
        }
        static void XepHang(int[] ViTriTen, int[] ViTriDiem, int[] ViTriNgayGio, int DoDaiCot)
        {
            File.AppendAllText("DinosaurResult.txt", "");
            string[] OpenSaveFile = File.ReadAllLines("DinosaurResult.txt");
            string[] temp = new string[3];
            for (int h = 0; h < Math.Pow(OpenSaveFile.Length / 3, 2); h++)
                for (int i = 0; i < OpenSaveFile.Length / 3 - 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                        temp[j] = OpenSaveFile[i * 3 + j];

                    if (int.Parse(OpenSaveFile[i * 3 + 1]) < int.Parse(OpenSaveFile[i * 3 + 4]))
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            OpenSaveFile[i * 3 + j] = OpenSaveFile[i * 3 + j + 3];
                            OpenSaveFile[i * 3 + j + 3] = temp[j];
                        }
                    }
                }
            if (OpenSaveFile.Length / 3 > DoDaiCot)
            {
                string[] temparray = new string[DoDaiCot * 3];
                for (int i = 0; i < temparray.Length; i++)
                    temparray[i] = OpenSaveFile[i];

                OpenSaveFile = temparray;
            }

            Display.Clear(ViTriTen[0], ViTriTen[1], 30, Display.LengthOfTheColumn, "");
            for (int i = 0; i < OpenSaveFile.Length / 3; i++)
            {
                Display.Print(ViTriTen[0] + 3 - (i + 1).ToString().Length, ViTriTen[1] + i, (i + 1) + "  " + OpenSaveFile[i * 3], "", "");
                Display.Print(ViTriDiem[0], ViTriDiem[1] + i, OpenSaveFile[i * 3 + 1], "", "");
                Display.Print(ViTriNgayGio[0], ViTriTen[1] + i, OpenSaveFile[i * 3 + 2], "", "");
            }
        }

        class Display
        {
            public static int
                TheNumberOfTrexImages = 0,      // Số lượng image của cho T-rex
                LenghtOfTheRoad = 0,            // Độ dài image con đường
                WidthOfTheTrex = 0,             // Chiều rộng
                BufferWidth = Console.BufferWidth,
                BufferHeigth = Console.BufferHeight;

            public static int[] PreviousPositionOfTrex = new int[2] { 0, 0 };     // Vị trí trước đó của T-re

            private static List<int> PreviousPositionOfCacti = new List<int>(); // Vị trí trước đó của các cây xương rồng mọc trên đường, dùng để xoá vết in khi các cây xương rồng dịch chuyển
            private static List<int> PreviousPositionOfPteroes = new List<int>(); // Vị trí trước đó của thằn lằn bay, tương tự xương rồng

            public static int[] BasePositionOfObjects = { 1, Console.BufferHeight / 2 + 3 }; // Vị trí gốc cho toàn bộ đối tượng

            // Cho một luồng truy cập vào một đoạn code khi sử dụng với từ khoá 'lock'
            // Khi luồng này truy cập vào thì các luồng khác sẽ đợi khi luồng đó truy cập xong rồi mới được truy cập
            private static readonly object locker = new object();

            public static void Reset(ref int[] BasePositionOfTheTrex)
            {
                PreviousPositionOfCacti = new List<int>();
                PreviousPositionOfPteroes = new List<int>();

                BasePositionOfTheTrex = new int[] { BasePositionOfObjects[0] + 15, BasePositionOfObjects[1] - 1 };
            }


            public static int[] PositionName = new int[2];
            public static int[] PositionScore = new int[2];
            public static int[] PositionDateTime = new int[2];
            public static int LengthOfTheColumn = 0;
            public static void Bangxephang()
            {
                string[] bangxephang = new string[]
                {
                @"                                   BẢNG XẾP HẠNG                                    ",
                @"  \━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━  ",
                @"   \\   / /                                                               / /   |   ",
                @" ==>/  / /                                                               / /    <== ",
                @"   /  / /                                                               / /    /    ",
                @" ==>   /\                                                                 \   /<==  ",
                @"    \/   \                                                                 \ / /    ",
                @" ==>/     \                                                                /  /<==  ",
                @"   / /   /                                                                /  /      ",
                @" ==> \  /                                                                /  / \ <== ",
                @"    \ \/                                                                  \ \  \    ",
                @"  ==>\                                                                    /\ \  \<==",
                @"     /  \                                                                /  \ \/ \  ",
                @" ==>/  \ \                                                              /    \/<==  ",
                @"    \   \ \                                                           \\ \   /\     ",
                @"  ==>\   \ \                                                            \ \ /<==    ",
                @"     ━━━━\━━\━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━/━━━━━━  ",
                };
                int vt1 = (Console.BufferWidth - bangxephang[0].Length) / 2,
                    vt2 = (Console.BufferHeight - bangxephang.Length) / 2;
                PositionName[0] = vt1 + 16;
                PositionName[1] = vt2 + 2;
                PositionScore[0] = vt1 + 45;
                PositionScore[1] = vt2 + 2;
                PositionDateTime[0] = vt1 + 52;
                PositionDateTime[1] = vt2 + 2;
                LengthOfTheColumn = bangxephang.Length - 3;

                Print(vt1, vt2, bangxephang, "", "DarkYellow");
            }

            private static Dictionary<string, int[,]> SavePrints = new Dictionary<string, int[,]>();

            public static void Print<T>(int x, int y, T print, string NameImage, string color)
            {
            Return:;
                try
                {
                    lock (locker)
                    {
                        ConsoleColor ColorOfImage = new ConsoleColor();
                        if (Enum.TryParse(color, out ColorOfImage))
                            Console.ForegroundColor = ColorOfImage;

                        int[,] MarkOfPrint = new int[0, 0];
                        if (print is string)
                        {
                            if (x >= 0 && y >= 0 && x + ((dynamic)print).Length < Console.BufferWidth && y < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write(print);

                                MarkOfPrint = new int[1, 3];
                                MarkOfPrint[0, 0] = x;
                                MarkOfPrint[0, 1] = y;
                                MarkOfPrint[0, 2] = ((dynamic)print).Length;
                            }
                        }
                        if (print is string[])
                        {
                            MarkOfPrint = new int[((dynamic)print).Length, 3];
                            for (int i = 0; i < ((dynamic)print).Length; i++)
                            {
                                if (x >= 0 && y >= 0 && x + ((dynamic)print)[i].Length < Console.BufferWidth && y + ((dynamic)print).Length < Console.BufferHeight)
                                {
                                    Console.SetCursorPosition(x, y + i);
                                    Console.Write(((dynamic)print)[i]);

                                    MarkOfPrint[i, 0] = x;
                                    MarkOfPrint[i, 1] = y + i;
                                    MarkOfPrint[i, 2] = ((dynamic)print)[i].Length;
                                }
                            }
                        }
                        if (!(print is string) && !(print is string[]))
                            throw new Exception("Kiểu dữ liệu không hợp lệ, phải là kiểu string hoặc string[].");

                        if (NameImage != "" && MarkOfPrint != null)
                        {
                            if (!SavePrints.ContainsKey(NameImage))
                                SavePrints.Add(NameImage, MarkOfPrint);
                        }
                        Console.ResetColor();
                    }
                    if (BufferWidth != Console.BufferWidth || BufferHeigth != Console.BufferHeight)
                        throw new Exception();
                }
                catch
                {
                    BufferWidth = Console.BufferWidth;
                    BufferHeigth = Console.BufferHeight;
                    Console.Clear();
                    if (Console.BufferWidth < 120 || Console.BufferHeight < 30)
                    {
                        string message = "Kích thước cửa sổ quá nhỏ!";
                        if (Console.BufferWidth > message.Length) Print((Console.BufferWidth - message.Length) / 2, Console.BufferHeight / 2, message, "", "Red");
                    }
                    while (Console.BufferWidth < 120 || Console.BufferHeight < 30) { };
                    goto Return;
                }
            }
            // Xoá một khoảng trên màn hình ở vị trí (x, y), độ dài chiều ngang, dọc (w, h); hoặc sử dụng 'NameImage' đã lưu để xoá nhanh một hình
            public static void Clear(int x, int y, int w, int h, string NameImage)
            {
            Return:;
                try
                {
                    lock (locker)
                    {
                        string c = "";

                        for (int i = 0; i < w; i++)
                            c += " ";
                        for (int i = 0; i < h; i++)
                            if (x + w < Console.BufferWidth && y + i < Console.BufferHeight)
                            {
                                Console.SetCursorPosition(x, y + i);
                                Console.Write(c);
                            }

                        if (SavePrints.ContainsKey(NameImage))
                        {
                            for (int i = 0; i < SavePrints[NameImage].GetLength(0); i++)
                                Clear(SavePrints[NameImage][i, 0], SavePrints[NameImage][i, 1], SavePrints[NameImage][i, 2], 1, "");
                            SavePrints.Remove(NameImage);
                        }
                    }
                }
                catch
                {
                    while (Console.BufferWidth < 120 || Console.BufferHeight < 30) { };
                    goto Return;
                }
            }
        }
    }
}

