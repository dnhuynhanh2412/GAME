using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; //Ghi Tiếng Việt dùng thư viện Text
                                                    //Console.WriteLine("Nhap ten cua ban: ");
                                                    //string tenNguoichoi = NhapTenNguoiChoi();
        int[] IndexOfSaveBox = new int[2];
        /*Display.Print(0, 0, "<Tab> để xem bảng xếp hạng", "MessageTab", "");
        Program.InputNameBox(ref IndexOfSaveBox);
        string YourName = "";*/
        string tenNguoiChoi = NhapTenNguoiChoi();
        LuaChon();
        LuuKetQua(tenNguoiChoi, diem);
        Display.Bangxephang();
    }
    //public static int MaximumLengthOfPlayersName = 0;
    /*public static void InputNameBox(ref int[] IndexOfSaveBox)
    {
        string[] savebox = new string[]
        {
                "   Thông tin người chơi  ",
                "┏━━━━━━━━━━━━━━━━━━━━━━━┓",
                "┃ Tên:                  ┃",
                "┗━━━━━━━━━━━━━━━━━━━━━━━┛",
                "  Nhấn <Enter> hoàn tất  "
        };

        int x = (Console.WindowWidth - savebox[0].Length) / 2,
            y = (Console.WindowHeight - savebox.Length) / 2;

        MaximumLengthOfPlayersName = savebox[0].Length - 9;
        Display.Print(x, y, savebox, "SaveBox", "");
        Console.SetCursorPosition(x + 7, y + 2);
        IndexOfSaveBox[0] = x + 7;
        IndexOfSaveBox[1] = y + 2;
    }*/
    private static string NhapTenNguoiChoi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Chào mừng đến với trò chơi VUA PHÂN LOẠI RÁC!");
        Console.ResetColor();
        Console.WriteLine("Vui lòng nhập tên của bạn: ");

        string tenNguoiChoi;
        do
        {
            tenNguoiChoi = Console.ReadLine()?.Trim(); // Đọc và loại bỏ khoảng trắng thừa
            if (string.IsNullOrWhiteSpace(tenNguoiChoi)) // Kiểm tra tên hợp lệ
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tên không được để trống, vui lòng nhập lại:");
                Console.ResetColor();
            }
        } while (string.IsNullOrWhiteSpace(tenNguoiChoi));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Chào {tenNguoiChoi}, bắt đầu trò chơi nào!");
        Console.ResetColor();
        return tenNguoiChoi;
    }

    private static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.Clear();
        Console.Write("~");
        Console.SetCursorPosition(10, 5);
        Console.WriteLine("------------------------------");
        Console.SetCursorPosition(10, 6);
        Console.WriteLine("|      VUA PHÂN LOẠI RÁC     |");
        Console.SetCursorPosition(10, 7);
        Console.WriteLine("------------------------------");
        Console.SetCursorPosition(10, 9); Console.ResetColor();

        Console.WriteLine("1. Bắt đầu chơi");
        Console.SetCursorPosition(10, 10);
        Console.WriteLine("2. Hướng dẫn");
        Console.SetCursorPosition(10, 11);
        //Console.WriteLine("3. Âm thanh");
        //Console.SetCursorPosition(10, 12);
        Console.WriteLine("Nhấn 3 hoặc ESC để thoát");
        Console.SetCursorPosition(10, 12);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Nhập số để lựa chọn: ");

        Console.ResetColor();
    }


    private static void XuLyLuaChon(char luaChon)
    {
        switch (luaChon)
        {
            case '1':
                ChoiTroChoi();
                break;
            case '2':
                HuongDanChoi();
                break;
            /*case '3':
                QuanLyNhac();
                break;*/
            case '3':
            case '\u001b':
                Environment.Exit(0);
                break;
        }
    }

    static void LuaChon()
    {
        /*Thread nhac = new Thread(NhacNen);
        if (dangBatNhacNen)
            nhac.Start();*/
        do
        {
            Menu();
            char luaChon = Console.ReadKey().KeyChar;
            Console.Clear();
            XuLyLuaChon(luaChon);
        } while (true);
    }

    /*static void QuanLyNhac()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        GoToXY(10, 5);
        Console.WriteLine("1. Tắt nhạc nền");
        GoToXY(10, 6);
        Console.WriteLine("2. Bật nhạc nền");
        GoToXY(10, 8);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Nhấn ESC để thoát");
        Console.ResetColor();
        char luaChonNhac = Console.ReadKey().KeyChar;
        switch (luaChonNhac)
        {
            case '1':
                if (dangBatNhacNen)
                {
                    dangBatNhacNen = false;
                }
                return;
            case '2':
                if (!dangBatNhacNen)
                {
                    dangBatNhacNen = true;
                }
                return;
            case '\u001b': // Là nhấn esc
                return;
            default: QuanLyNhac(); return;
        }
    }*/

    private static void HuongDanChoi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\t\tHƯỚNG DẪN");
        Console.WriteLine("Khi bạn bấm vào chơi thì máy sẽ ngẫu nhiên đưa ra 1 câu hỏi trong bộ câu hỏi có sẵn. ");
        Console.WriteLine("Sau đó bạn sẽ suy nghĩ và chọn đáp án đúng.");
        Console.WriteLine("Do đây là mô hình phân loại 7 nên sẽ quy ước: \r\n1. Chất lỏng\r\n2. Thực phẩm thừa\r\n3. Kim loại\r\n4. Nhựa tái chế\r\n5. Giấy\r\n6. Hộp sữa \r\n7. Rác thải còn lại. \r\n");
        Console.WriteLine("1 round sẽ gồm 5 phút để chơi: trả lời đúng 1 câu sẽ được 1 điểm");
        Console.WriteLine("NHỚ TẮT BỘ GÕ TIẾNG VIỆT TRƯỚC KHI CHƠI");
        Console.WriteLine("\nNhấn ESC để thoát hướng dẫn");

        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            HuongDanChoi();
            return;
        }
    }

    //private string traloi;
    // Biến toàn cục
    static int diem = 0; // Điểm số
    static int diemCaoNhat = 0; // Điểm cao nhất

    private static void XuLyChoi()
    {
        Console.Clear();
        string[,] cauhoi = new string[2, 5] {
        {"Chai nhựa thuộc phân loại rác nào?", "Rác tái chế", "Rác thải thừa", "Chất lỏng", "Thực phẩm thừa"},
        {"Sữa thuộc phân loại rác nào?", "Rác thải còn lại", "Kim loại", "Rác thải thừa", "Giấy"}
    };

        string[] dapAnDung = { "A", "C" }; // Đáp án đúng
        bool daSuDung5050 = false; // Đánh dấu quyền trợ giúp 50/50
        int soCauHoi = cauhoi.GetLength(0); // Lưu số lượng câu hỏi vào biến

        for (int i = 0; i < soCauHoi; i++)
        {
            Console.WriteLine("\nCâu hỏi số {0}: {1}", i + 1, cauhoi[i, 0]);
            Console.WriteLine("A. {0}", cauhoi[i, 1]);
            Console.WriteLine("B. {0}", cauhoi[i, 2]);
            Console.WriteLine("C. {0}", cauhoi[i, 3]);
            Console.WriteLine("D. {0}", cauhoi[i, 4]);

            string chon5050 = " ";
            while (true)
            {
                // Hỏi người chơi xem có muốn sử dụng 50/50 không
                try
                {
                    Console.WriteLine("\nBạn có muốn sử dụng quyền trợ giúp 50/50 không? (Y/N)");
                    chon5050 = Console.ReadLine()?.ToUpper();
                    if (chon5050 == "Y" || chon5050 == "N")
                        break;
                    else
                        throw new Exception("Mời bạn nhập đúng Y hoặc N");
                }
                catch (Exception loi)
                {
                    Console.WriteLine(loi.Message);
                }
            }
            if (chon5050 == "Y" && !daSuDung5050)
            {
                daSuDung5050 = true;

                // Sử dụng quyền trợ giúp 50/50
                List<string> options = new List<string> { cauhoi[i, 1], cauhoi[i, 2], cauhoi[i, 3], cauhoi[i, 4] };
                string correctAnswer = cauhoi[i, dapAnDung[i] == "A" ? 1 : (dapAnDung[i] == "B" ? 2 : (dapAnDung[i] == "C" ? 3 : 4))];

                UseFiftyFifty(options, correctAnswer);

                // Hiển thị lại câu hỏi với 2 đáp án còn lại
                Console.WriteLine("\nSau khi sử dụng quyền trợ giúp 50/50:");
                DisplayOptions(options);
            }
            else if (chon5050 == "Y")
            {
                Console.WriteLine("Bạn đã sử dụng quyền trợ giúp 50/50 trước đó.");
            }

            Console.Write("\nNhập câu trả lời của bạn (A/B/C/D): ");
            string traloi = Console.ReadLine()?.ToUpper();

            if (traloi == dapAnDung[i])
            {
                Console.WriteLine("Bạn đã chọn đáp án đúng.");
                diem++;
            }
            else
            {
                Console.WriteLine("Sai rồi. Đáp án đúng là: {0}.", dapAnDung[i]);
            }
        }

        Console.WriteLine("\nBạn đã hoàn thành trò chơi với số điểm: {0}/{1}", diem, soCauHoi);

        // Sau khi trò chơi kết thúc, gọi hàm KetThucGame
        KetThucGame(diem);
    }

    // Hàm hiển thị các lựa chọn
    static void DisplayOptions(List<string> options)
    {
        char optionLetter = 'A'; // Đánh dấu các lựa chọn từ A, B, C, D
        for (int i = 0; i < options.Count; i++)
        {
            if (!string.IsNullOrEmpty(options[i]))
            {
                Console.WriteLine($"{optionLetter}. {options[i]}");
            }
            optionLetter++;
        }
    }

    // Hàm trợ giúp 50/50: Loại bỏ 2 đáp án sai
    static void UseFiftyFifty(List<string> options, string correctAnswer)
    {
        Random rand = new Random();

        // Tìm chỉ số của đáp án đúng
        int correctIndex = options.IndexOf(correctAnswer);

        // Tìm các chỉ số của các đáp án sai
        List<int> incorrectIndexes = new List<int>();
        for (int i = 0; i < options.Count; i++)
        {
            if (i != correctIndex) // Bỏ qua đáp án đúng
            {
                incorrectIndexes.Add(i);
            }
        }

        // Chọn ngẫu nhiên 2 đáp án sai để loại bỏ
        var randomIncorrectIndexes = incorrectIndexes.OrderBy(x => rand.Next()).Take(2).ToList();

        // Loại bỏ các đáp án sai được chọn
        foreach (var index in randomIncorrectIndexes)
        {
            options[index] = null; // Gán null để ẩn đáp án sai
        }

        Console.ReadKey();
    }

    // Hàm kết thúc trò chơi
    static void KetThucGame(int diem)
    {
        Console.Clear();
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine("\t\t------ TRÒ CHƠI KẾT THÚC ------");
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine($"\t\tĐiểm của bạn là: {diem}");
        if (diem > 1)
        {
            diemCaoNhat = diem;
            Console.WriteLine("\t\tXin chúc mừng bạn đã được 2 điểm rèn luyện\n");
        }
        Console.WriteLine("\t\tNhấn phím Enter để quay lại bảng chọn hoặc nhấn r để chơi lại");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\t\tĐIỂM CAO NHẤT: {diemCaoNhat}");
        Console.ResetColor();

        bool nenThoat = false;

        while (!nenThoat)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    nenThoat = true;
                    break;
                default:
                    if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                    {
                        ChoiTroChoi();
                        nenThoat = true;
                    }
                    break;
            }
        }
    }

    // Hàm bắt đầu trò chơi
    static void ChoiTroChoi()
    {
        diem = 0;
        XuLyChoi(); // Gọi hàm xử lý trò chơi
    }

    static void KetThucGame(string tenNguoiChoi)
    {
        Console.Clear();
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine("\t\t------ TRÒ CHƠI KẾT THÚC ------");
        Console.WriteLine("\t\t-------------------------------");
        Console.WriteLine($"\t\tĐiểm của bạn là: {diem}");
        if (diem > 1)
        {
            diemCaoNhat = diem;
            Console.WriteLine($"\t\tXin chúc mừng {tenNguoiChoi} đã được 2 điểm rèn luyện\n");
        }
        Console.WriteLine("\t\tNhấn phím Enter để quay lại bảng chọn hoặc nhấn r để chơi lại");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\t\tĐIỂM CAO NHẤT: {diemCaoNhat}");
        Console.ResetColor();

        bool nenThoat = false;

        while (!nenThoat)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    nenThoat = true;
                    break;
                default:
                    if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                    {
                        ChoiTroChoi();
                        nenThoat = true;
                    }
                    break;
            }
        }
    }

    /*static void LuuKetQua(string tenNguoiChoi, int diem)
    {
        if (tenNguoiChoi != "" && !String.IsNullOrWhiteSpace(tenNguoiChoi))
        {
            bool ContainName = false;
            File.AppendAllText("KetQuaNguoiChoi.txt", "");
            string[] OpenSaveFile = File.ReadAllLines("KetQuaNguoiChoi.txt");

            for (int i = 0; i < OpenSaveFile.Length / 3; i += 3)
            {
                if (OpenSaveFile[i * 3].Contains(tenNguoiChoi))
                {
                    if (diem > int.Parse(OpenSaveFile[i + 1]))
                    {

                        OpenSaveFile[i * 3 + 1] = diem.ToString();
                        OpenSaveFile[i * 3 + 2] = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
                    }
                    ContainName = true;
                }
                if (ContainName) break;
            }
            if (!ContainName)
                OpenSaveFile = OpenSaveFile.Concat(new string[] { tenNguoiChoi, diem.ToString(), DateTime.Now.ToString("HH:mm dd/MM/yyyy") }).ToArray();

            File.WriteAllLines("KetQuaNguoiChoi.txt", OpenSaveFile);
        }
    }

    static void LuuKetQua(string tenNguoiChoi, int diem)
    {
        string filePath = "KetQuaNguoiChoi.txt";

        // Tạo tệp nếu chưa tồn tại
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close(); // Đảm bảo tệp được tạo và đóng
        }

        // Đọc dữ liệu hiện tại từ tệp
        List<string> danhSachKetQua = File.ReadAllLines(filePath).ToList();

        bool daCapNhat = false;

        for (int i = 0; i < danhSachKetQua.Count; i += 3)
        {
            if (i + 2 < danhSachKetQua.Count && danhSachKetQua[i].Trim() == tenNguoiChoi)
            {
                int diemCu = int.Parse(danhSachKetQua[i + 1]);

                if (diem > diemCu)
                {
                    danhSachKetQua[i + 1] = diem.ToString(); // Cập nhật điểm
                    danhSachKetQua[i + 2] = DateTime.Now.ToString("HH:mm dd/MM/yyyy"); // Cập nhật thời gian
                }

                daCapNhat = true;
                break;
            }
        }

        // Nếu chưa có tên người chơi, thêm mới
        if (!daCapNhat)
        {
            danhSachKetQua.Add(tenNguoiChoi);
            danhSachKetQua.Add(diem.ToString());
            danhSachKetQua.Add(DateTime.Now.ToString("HH:mm dd/MM/yyyy"));
        }

        // Ghi lại tệp
        File.WriteAllLines(filePath, danhSachKetQua);
    }*/


    static void LuuKetQua(string tenNguoiChoi, int score)
    {
        if (tenNguoiChoi != "" && !String.IsNullOrWhiteSpace(tenNguoiChoi))
        {
            bool ContainName = false;
            File.AppendAllText("KetQuaNguoiChoi.txt", "");
            string[] OpenSaveFile = File.ReadAllLines("KetQuaNguoiChoi.txt");

            for (int i = 0; i < OpenSaveFile.Length / 3; i += 3)
            {
                if (OpenSaveFile[i * 3].Contains(tenNguoiChoi))
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
                OpenSaveFile = OpenSaveFile.Concat(new string[] { tenNguoiChoi, score.ToString(), DateTime.Now.ToString("HH:mm dd/MM/yyyy") }).ToArray();

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


