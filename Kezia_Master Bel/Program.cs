using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component;
using Database;
using System.Data;
using System.Data.OleDb;
using System.Threading;


namespace Kezia_MasterBel
{
    class Program
    {
        public static AccessDatabaseHelper DB = new AccessDatabaseHelper("./schoolbellsc.accdb");

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //untuk menghilangkan kursor di tampilan
            //--------------------------------------

            //SplashS.screen();

            //BOX 1 HEADER =============================================================



            //Kotak box1 = new Kotak();
            //box1.SetXY(0, 0).SetWidthAndHeight(115, 6);
            //box1.SetForeColor(ConsoleColor.Yellow);
            //box1.Tampil();

            new Clear(0, 0, 116, 7).SetBackColor(ConsoleColor.Yellow).Tampil();

           
            string[] schoolname = new string[6];
            schoolname[0] = "███████╗ ██████╗██╗  ██╗ ██████╗  ██████╗ ██╗         ██████╗ ███████╗██╗     ██╗     ";
            schoolname[1] = "██╔════╝██╔════╝██║  ██║██╔═══██╗██╔═══██╗██║         ██╔══██╗██╔════╝██║     ██║     ";
            schoolname[2] = "███████╗██║     ███████║██║   ██║██║   ██║██║         ██████╔╝█████╗  ██║     ██║     ";
            schoolname[3] = "╚════██║██║     ██╔══██║██║   ██║██║   ██║██║         ██╔══██╗██╔══╝  ██║     ██║     ";
            schoolname[4] = "███████║╚██████╗██║  ██║╚██████╔╝╚██████╔╝███████╗    ██████╔╝███████╗███████╗███████╗";
            schoolname[5] = "╚══════╝ ╚═════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝    ╚═════╝ ╚══════╝╚══════╝╚══════╝"; 

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < schoolname.Length; i++)
            {
                Console.SetCursorPosition(16, 1 + i);
                Console.WriteLine(schoolname[i]);
            }

            //BOX 2 FOOTER =============================================================

            new Clear(0, 25, 116, 4).SetBackColor(ConsoleColor.Yellow).Tampil();

            string[] uu = new string[3];
            uu[0] = "╔══════════════════════════════════════════════════════════╗";
            uu[1] = "║                 KEZIA D. LUFFY @ 2023                    ║";
            uu[2] = "╚══════════════════════════════════════════════════════════╝";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int y = 0; y < uu.Length; y++) 
            {
                Console.SetCursorPosition(25, 26 + y);
                Console.WriteLine(uu[y]);
            }
                //Kotak box2 = new Kotak();
                //box2.SetXY(0, 25).SetWidthAndHeight(115, 4);
                //box2.SetForeColor(ConsoleColor.Black);
                //box2.Tampil();


            //Tulisan ownname = new Tulisan();
            //ownname.SetXY(0, 27).SetLength(114);
            //ownname.SetBackColor(ConsoleColor.Yellow).SetForeColor(ConsoleColor.DarkBlue);
            //ownname.Text = "BY: Kezia Putri Berliani";
            //ownname.TampilTengah();

            //Tulisan clsprogram = new Tulisan();
            //clsprogram.SetForeColor(ConsoleColor.Magenta);
            //clsprogram.SetText("~ INFORMATIKA II ~").SetXY(0, 28).SetLength(114).TampilTengah();

            //BOX 3 LEFT COLUMN ====================== FOR MENU =======================

            new Clear(0, 7, 25, 17).SetBackColor(ConsoleColor.DarkRed).Tampil();

            //Kotak box3 = new Kotak();
            //box3.SetXY(0, 7).SetWidthAndHeight(25, 17);
            //box3.Tampil();


            //BOX 4 RIGHT COLUMN ========================= ISIAN ======================


            new Clear(25, 7, 91, 17).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            //Kotak box4 = new Kotak();
            //box4.SetXY(26,7).SetWidthAndHeight(89, 17).SetForeColor(ConsoleColor.DarkYellow).SetBackColor(ConsoleColor.DarkYellow);
            //box4.Tampil();

            // Loading
            //Loading.loading(20, 1);

            // MAIN MENU RIGHT HERE !! =================================================


            Tulisan xx = new Tulisan();
            xx.SetXY(2, 10);
            xx.SetText("~~~~~~ MENU ~~~~~~");
            xx.ForeColor = ConsoleColor.Black;
            xx.BackColor = ConsoleColor.DarkRed;
            xx.Tampil();

            Menu menu = new Menu("╔ RUN PROGRAM ╗",
                                 "║  VIEW DATA  ║",
                                 "║  ADD DATA   ║",
                                 "║  EDIT DATA  ║",
                                 "║ DELETE DATA ║",
                                 "╚    EXIT     ╝");
            menu.SetXY(4, 12);
            menu.ForeColor = ConsoleColor.Black;
            menu.BackColor = ConsoleColor.DarkRed;
            menu.SelectedBackColor = ConsoleColor.Yellow;
            menu.SelectedForeColor = ConsoleColor.Black;
            menu.Tampil();

            Tulisan yy = new Tulisan();
            yy.SetXY(2, 19);
            yy.SetText("~~~~~~~~~~~~~~~~~~");
            yy.ForeColor = ConsoleColor.Black;
            yy.BackColor = ConsoleColor.DarkRed;
            yy.Tampil();

            //*Cursor Selected Up and Down 

            bool runningmenu = true;

            while (runningmenu)
            {
                ConsoleKeyInfo Tombol = Console.ReadKey(true);

                if (Tombol.Key == ConsoleKey.DownArrow)  //Down Cursor//
                {
                    menu.Next();
                    menu.Tampil();
                }

                else if (Tombol.Key == ConsoleKey.UpArrow) //Up Cursor
                {
                    menu.Prev();
                    menu.Tampil();
                }

                else if (Tombol.Key == ConsoleKey.Enter) //enter
                {
                    int selectmenu = menu.SelectedIndex;

                    if (selectmenu == 0) //for menu RUN PROGRAM
                    {
                        RUNPROGRAM();
                    }
                    else if (selectmenu == 1) //for menu VIEW DATA  
                    {
                        VIEWDATA();
                    }
                    else if (selectmenu == 2) //for menu ADD DATA
                    {
                        ADDDATA();
                    }
                    else if (selectmenu == 3) // for menu EDIT DATA
                    {
                        EDITDATA();
                    }
                    else if (selectmenu == 4) // for menu DELETE DATA
                    {
                        DELETEDATA();
                    }
                    else if (selectmenu == 5) // for menu EXIT
                    {
                        runningmenu = false;
                    }
                }
            }
        }

        //MASUK KE CLASS MENU2

        static void RUNPROGRAM() //=======================================================
        {
            new Clear(27, 8, 88, 15).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            Tulisan title = new Tulisan();
            title.SetXY(27, 8).SetText("             ♥♥ *. SCHOOL BELL IS RUNNING .* ♥♥               ").SetLength(88);
            title.SetBackColor(ConsoleColor.DarkYellow);
            title.SetForeColor(ConsoleColor.Black);
            title.TampilTengah();

            Tulisan nowday = new Tulisan().SetXY(30, 10);
            Tulisan nowtime = new Tulisan().SetXY(30, 11);

            string QSelect = "SELECT * FROM tbschedule WHERE hari=@hari AND jam=@jam;";

            DB.Connect();

            bool Play = true;

            while (Play)
            {

                DateTime today = DateTime.Now;

                nowday.SetText
                ("TODAY (DAY)     : " + today.ToString("dddd"));
                nowday.SetBackColor(ConsoleColor.DarkYellow);
                nowday.SetForeColor(ConsoleColor.Black);
                nowday.Tampil();

                nowtime.SetText
                ("TODAY (TIME)    : " + today.ToString("HH:mm:ss"));
                nowtime.SetBackColor(ConsoleColor.DarkYellow);
                nowtime.SetForeColor(ConsoleColor.Black);
                nowtime.Tampil();

                DataTable DT = DB.RunQuery(QSelect,
                    new OleDbParameter("@hari", today.ToString("dddd")),
                    new OleDbParameter("@jam", today.ToString("HH:mm:ss")));

                if(DT.Rows.Count > 0)
                {
                    Audio soundbell = new Audio();
                    soundbell.File = "./Suara/" + DT.Rows[0]["sound"];
                    soundbell.Play();

                    new Tulisan().SetXY(27, 20).SetText("THE BELL IS RINGING!!").
                        SetBackColor(ConsoleColor.White).
                        SetForeColor(ConsoleColor.Magenta).
                        SetLength(88).TampilTengah();
                         
                    new Tulisan().SetXY(27, 21).SetText(DT.Rows[0]["ket"].ToString()).
                        SetForeColor(ConsoleColor.Blue).SetLength(88).TampilTengah();

                    Play = false;

                }

                if(Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo Tombol = Console.ReadKey(true);

                    if (Tombol.Key == ConsoleKey.Escape)  //Down Cursor//
                    {
                        Play = false;
                    }
                }

                //Thread.Sleep(1000); // delay satuannya milisecond
                // Loading
                Tulisan loading = new Tulisan();

                loading.SetText ("BEL SEKOLAH SEDANG DIJALANKAN").SetXY(29,16).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).SetLength(88).TampilTengah();
                
                for (int kanan = 0; kanan < 5; kanan++)
                {
                    loading.SetText("▓▓▓▓▓").SetXY(19 + kanan * 5, 18).SetForeColor(ConsoleColor.DarkYellow).SetBackColor(ConsoleColor.Yellow).SetLength(88).TampilTengah();
                    Thread.Sleep(91);
                }
                for (int kiri = 0; kiri < 5; kiri++)
                {
                    loading.SetText("░░░░░").SetXY(39 - kiri * 5, 18).SetForeColor(ConsoleColor.Yellow).SetBackColor(ConsoleColor.Magenta).SetLength(88).TampilTengah();
                    Thread.Sleep(91);
                }
            }

            new Clear(27, 8, 88, 15).SetBackColor(ConsoleColor.DarkYellow).Tampil();


        }
        static void VIEWDATA() //=======================================================
        {
            new Clear(25, 7, 91, 17).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            Tulisan title = new Tulisan();
            title.SetXY(27, 8).SetText(" ♥♥ *. VIEW DATA SCHEDULE SCHOOL .* ♥♥ ").SetLength(88);
            title.SetBackColor(ConsoleColor.DarkYellow);
            title.SetForeColor(ConsoleColor.Black);
            title.TampilTengah();
       

            DB.Connect();
            DataTable DT = DB.RunQuery("SELECT * FROM tbschedule;");

            new Tulisan("╒═════╤════════════╤══════════╤══════════════════════════════════════════════════════╕").SetXY(28, 10).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).Tampil();
            new Tulisan("│ N0  │     DAY    │   TIME   │                    DESCRIPTION                       │").SetXY(28, 11).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).Tampil();
            new Tulisan("├─────┼────────────┼──────────┼──────────────────────────────────────────────────────┤").SetXY(28, 12).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            for (int i = 0; i < DT.Rows.Count; i++) //untuk jarak tulisan isi dari tabel
            {
                string ID = DT.Rows[i]["ID"].ToString();
                string DAY = DT.Rows[i]["hari"].ToString();
                string TIME = DT.Rows[i]["jam"].ToString();
                string ADDITIONAL = DT.Rows[i]["ket"].ToString();

                String domain = String.Format("│{0, -5}│{1, -12}│{2, -10}│{3, -54}│", ID, DAY, TIME, ADDITIONAL);
                new Tulisan(domain).SetXY(28, 13 + i).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            }

            new Tulisan("╘═════╧════════════╧══════════╧══════════════════════════════════════════════════════╛").SetXY(28, 13 + DT.Rows.Count).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow).Tampil();
        }

        static void ADDDATA() // =======================================================
        {
            new Clear(25, 7, 91, 17).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            Tulisan title = new Tulisan();
            title.SetXY(27, 8).SetText("             ♥♥ *. ADD DATA .* ♥♥               ").SetLength(88);
            title.SetBackColor(ConsoleColor.DarkYellow);
            title.SetForeColor(ConsoleColor.Black);
            title.TampilTengah();

        

            Inputan dayinput = new Inputan();
            dayinput.Text 
            = ".* ENTERY DAY          : ";
            dayinput.SetXY(30, 10).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Inputan timeinput = new Inputan();
            timeinput.Text 
            = ".* ENTERY TIME         : ";
            timeinput.SetXY(30, 11).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Inputan addinput = new Inputan();
            addinput.Text 
            = ".* ENTERY DESCRIPTION  : ";
            addinput.SetXY(30, 12).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Pilihan SoundInput = new Pilihan();
            SoundInput.SetPilihans(
                "5 Menit Akhir Istirahat I.wav",
                "5 Menit Akhir Istirahat II.wav",
                "5 Menit Akhir Kegiatan Keagamaan.wav", 
                "5 Menit Awal Kegiatan Keagamaan.wav",
                "5 Menit Awal Upacara.wav",
                "Akhir Pekan 1.wav",
                "Akhir Pekan 2.wav",
                "Akhir Perjalanan A.wav",
                "Akhir Pelajaran B.wav",
                "awal jam ke 1.wav",
                "Istirahat I.wav",
                "Istirahat II.wav",
                "Pelajaran ke 1.wav",
                "Pelajaran ke 2.wav" ,
                "Pelajaran ke 3.wav",
                "Pelajaran ke 4.wav",
                "Pelajaran ke 5.wav",
                "Pelajaran ke 6.wav",
                "Pelajaran ke 7.wav",
                "Pelajaran ke 8.wav",
                "Pelajaran ke 9.wav",
                "pembuka.wav");

            SoundInput.Text
            = ".* ENTERY SOUND        : ";
            SoundInput.SetXY(30, 13).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            string day = dayinput.Read();
            string time = timeinput.Read();
            string add = addinput.Read();
            string sound = SoundInput.Read();


            DB.Connect();
            DB.RunNonQuery("INSERT INTO tbschedule ( hari, jam, ket, sound ) VALUES ( @hari, @jam, @ket, @sound );",
                new OleDbParameter("@hari", day),
                new OleDbParameter("@jam", time),
                new OleDbParameter("@ket", add),
                new OleDbParameter("@sound", sound)
                );

            DB.Disconnect();
            new Tulisan().SetXY(27, 15).SetText("YOUR DATA IS SAVED").
                SetBackColor(ConsoleColor.Black).SetForeColor(ConsoleColor.DarkYellow).
                SetLength(88).TampilTengah();


        }

        static void EDITDATA() //=======================================================
        {
            new Clear(25, 7, 91, 17).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            Tulisan title = new Tulisan();
            title.SetXY(27, 8).SetText("             ♥♥ *. EDIT DATA .* ♥♥               ").SetLength(88);
            title.SetBackColor(ConsoleColor.DarkYellow);
            title.SetForeColor(ConsoleColor.Black);
            title.TampilTengah();

            Inputan IDchangeinput = new Inputan();
            IDchangeinput.Text
            = "ENTER THE ID TO CHANGE : ";
            IDchangeinput.SetXY(30, 10).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Inputan dayinput = new Inputan();
            dayinput.Text 
            = ".* NEW DAY             : ";
            dayinput.SetXY(30, 11).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Inputan timeinput = new Inputan();
            timeinput.Text 
            = ".* NEW TIME            : ";
            timeinput.SetXY(30, 12).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Inputan addinput = new Inputan();
            addinput.Text 
            = ".* NEW DESCRIPTION     : ";
            addinput.SetXY(30, 13).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            Pilihan SoundInput = new Pilihan();
            SoundInput.SetPilihans(
                "5 Menit Akhir Istirahat I.wav",
                "5 Menit Akhir Istirahat II.wav",
                "5 Menit Akhir Kegiatan Keagamaan.wav",
                "5 Menit Awal Kegiatan Keagamaan.wav",
                "5 Menit Awal Upacara.wav",
                "Akhir Pekan 1.wav",
                "Akhir Pekan 2.wav",
                "Akhir Perjalanan A.wav",
                "Akhir Pelajaran B.wav",
                "awal jam ke 1.wav",
                "Istirahat I.wav",
                "Istirahat II.wav",
                "Pelajaran ke 1.wav",
                "Pelajaran ke 2.wav",
                "Pelajaran ke 3.wav",
                "Pelajaran ke 4.wav",
                "Pelajaran ke 5.wav",
                "Pelajaran ke 6.wav",
                "Pelajaran ke 7.wav",
                "Pelajaran ke 8.wav",
                "Pelajaran ke 9.wav",
                "pembuka.wav");

            SoundInput.Text
            = ".* NEW SOUND           : ";
            SoundInput.SetXY(30, 14).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            string IDchange = IDchangeinput.Read();
            string day = dayinput.Read();
            string time = timeinput.Read();
            string add = addinput.Read();
            string sound = SoundInput.Read();

            DB.Connect();
            DB.RunNonQuery("UPDATE tbschedule SET hari=@hari, jam=@jam, ket=@ket, sound=@sound WHERE id=@id;",
                new OleDbParameter("@hari", day),
                new OleDbParameter("@jam", time),
                new OleDbParameter("@ket", add),
                new OleDbParameter("@sound", sound),
                new OleDbParameter("@id", IDchange)
                );

            DB.Disconnect();
            new Tulisan().SetXY(27, 16).SetText("YOUR DATA IS CHANGED").
                SetBackColor(ConsoleColor.Black).
                SetForeColor(ConsoleColor.DarkYellow).SetLength(88).TampilTengah();


        }

        static void DELETEDATA()//======================================================
        {
            new Clear(25, 7, 91, 17).SetBackColor(ConsoleColor.DarkYellow).Tampil();

            Tulisan title = new Tulisan();
            title.SetXY(27, 8).SetText("             ♥♥ *. DELETE DATA .* ♥♥               ").SetLength(88);
            title.SetBackColor(ConsoleColor.DarkYellow);
            title.SetForeColor(ConsoleColor.Black);
            title.TampilTengah();

            Inputan IDinput = new Inputan();
            IDinput.Text 
            = ".* ENTER THE ID TO DELETE       :";
            IDinput.SetXY(30, 10).SetForeColor(ConsoleColor.Black).SetBackColor(ConsoleColor.DarkYellow);

            string ID = IDinput.Read();

            DB.Connect();
            DB.RunNonQuery("DELETE FROM tbschedule WHERE id=@id;",
                new OleDbParameter("@id", ID));

            new Tulisan().SetXY(27, 13).SetText("YOUR DATA IS COMPLETED DELETED").SetBackColor(ConsoleColor.Black).
                SetForeColor(ConsoleColor.DarkYellow).SetLength(88).TampilTengah();


        }

    }
}
