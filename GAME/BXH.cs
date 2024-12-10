using System;
using System.Collections.Generic;
using System.Linq;
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
        /*static void XepHang(int[] ViTriTen, int[] ViTriDiem, int[] ViTriNgayGio, int DoDaiCot)
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
            }*/
        }
    }

