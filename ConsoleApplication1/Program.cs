using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region " PDA "
            //string strRFID = "4AT00A008001090RL00{S2031701A01{12000{1046{44748.0{0";
            //string strQRCode = "AT00A00800{1090{12000{M{ {W2031701A01{R{1046{K";
            //string strOneCode = "W2031701A01";
            //string strOutSale = "XA1940261@1";

            //string ss = Console.ReadLine();

            //char[] cc = { '{', '@' };

            ////string[] arr = ss.Split(new char[2] { '{', '@' }, StringSplitOptions.RemoveEmptyEntries);
            //string[] arr = ss.Split(cc);

            ////  length < 2 --> @
            //if (arr.Length < 3)
            //{
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        Console.WriteLine(arr[i]);
            //    }
            //}
            ////length > 2-- > " { "
            //else
            //{
            //    //上線用的程式
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        string s = arr[i].Substring(0, 1);
            //        if (s == "W")
            //        {
            //            Console.WriteLine(arr[i].ToString());
            //            break;
            //        }
            //        else if (s == "R")
            //        {
            //            Console.WriteLine(arr[i].ToString());
            //            break;
            //        }
            //        else if (s == "S")
            //        {
            //            Console.WriteLine(arr[i].ToString());
            //            break;
            //        }
            //        else if (s == "T")
            //        {
            //            Console.WriteLine(arr[i].ToString());
            //            break;
            //        }
            //    }
            //}
            #endregion

            #region "測試讀檔案重組字串"

            //變數
            //int counter = 0;
            //string line;
            ////比對資料
            ////複製圖檔
            ////讀取檔案
            //System.IO.StreamReader file = new StreamReader(@"c:\test_source\p21.txt");

            ////建資料夾
            //string strDir21 = @"C:\test_source\21";
            //DirectoryInfo di20 = Directory.CreateDirectory(strDir21);
            //string strDir = "";

            //while ((line = file.ReadLine()) != null)
            //{
            //    //組字串
            //    string strFileName = "";   //由資料庫組成的字串，這邊依照來源資料不同而變化
            //    string serverName = "P206427";
            //    string strSRCING = "SRCING";
            //    string strLastName = "2000";

            //    string[] arr = line.Split(',');
            //    string strCoilID = arr[0].ToString().PadLeft(8, '0');  //產品id
            //    string strCamera = arr[2].ToString().PadLeft(2, '0');  //相機編號
            //    string strClass = arr[1].ToString();  //瑕疵的分類

            //    //strFileName = serverName + "-" + strCoilID + "-" + strCamera + "-" + strSRCING + "-" + strLastName;  //正式字串
            //    strFileName = serverName + "-" + strCoilID + "-" + strCamera + "-" + strSRCING;   //測試使用

            //    //圖檔的來源路徑
            //    string strSourcePath = @"C:\test_source\B1MJ97JWW491JEWBV75000\022818777";
            //    //將圖檔存入陣列
            //    string[] picList = Directory.GetFiles(strSourcePath);  //圖檔位子

            //    //比對資料
            //    //以"FileName"為主去搜尋"圖檔資料"，並將資料歸納到arr的陣列[2]
            //    foreach (var item in picList)
            //    {
            //        //先處理圖檔資料的字串
            //        string[] ss = item.Split('\\');
            //        string strPicName = ss.ToString();

            //        //比對並分類
            //        if(strPicName == strFileName)
            //        {
            //            strDir = @"C:\test_source\" + "\\" + strClass;
            //            if(Directory.Exists(strDir))
            //            {
            //                //複製檔案
            //                File.Copy(,strDir)
            //            }
            //            else
            //            {
            //                //建立資料夾
            //                DirectoryInfo dir = Directory.CreateDirectory(strDir);
            //                //複製檔案
            //            }
            //        }
            //    }



            //    Console.WriteLine(strFileName);

            //    counter++;
            //}
            //file.Close();

            #endregion

            #region "Auto Process"

            //while (true)
            //{

            //    string i = Console.ReadLine();
            //    int j = Convert.ToInt32(i);
            //    switch(j)
            //    {
            //        case 0:
            //        case 1:
            //        case 2:
            //        case 3:
            //        case 4:
            //        case 5:
            //        case 6:
            //        case 7:
            //        case 8:
            //        case 9:
            //            Console.WriteLine("case is {0}", i);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            #endregion

            #region "create db table"

            string con = "Data Source=10.10.3.26;Initial Catalog=chrisTest;User ID=sa;Password=yfyoljk@";

            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();

                Submit_Tsql_NonQuery(cn, "Create-Tables", Build_2_Tsql_CreateTables());
            }

            #endregion

            Console.Read();
        }

        static string Build_2_Tsql_CreateTables()
        {
            return @"
        CREATE TABLE chrisTable4
        (
            Snum  nchar(100),
            Cnum  nchar(100),
            Score nchar(100)
        );";
        }

        static void Submit_Tsql_NonQuery(SqlConnection connection, string tsqlPurpose,string tsqlSourceCode, string parameterName = null, string parameterValue = null)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("T-SQL to {0}...", tsqlPurpose);

            using (var command = new SqlCommand(tsqlSourceCode, connection))
            {
                if (parameterName != null)
                {
                    command.Parameters.AddWithValue(parameterName, parameterValue);
                }
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " = rows affected.");
            }
        }
    }
}
