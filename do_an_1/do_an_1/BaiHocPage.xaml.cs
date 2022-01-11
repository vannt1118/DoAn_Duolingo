﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace do_an_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaiHocPage : ContentPage
    {
        Database db = new Database();
        User u;
        public BaiHocPage(User nd)
        {
            InitializeComponent();
            u = nd;
            Thu();
            HienThi(nd);
            
        }

        void HienThi(User nd)
        {
            txtdiem.Text = nd.Diem.ToString();
            txtten.Text = nd.TenND;
        }
        public BaiHocPage()
        {
            InitializeComponent();
            Thu();
            Navigation.PushAsync(new BaiHocPage(u));
        }
        
        void Thu()
        {
            List<GroupBH> dsgbh = new List<GroupBH>();
            GroupBH b1 = new GroupBH(1, new List<BaiHoc>
            {
                new BaiHoc
                {
                    TenBH = "Baby",
                    Hinh = "lesson_baby.png",
                    MaChang = 1,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                },
                new BaiHoc
                {

                    TenBH = "Bag",
                    Hinh = "lesson_bag.png",
                    MaChang = 1,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    TenBH = "Egg",
                    Hinh = "lesson_egg.png",
                    MaChang = 1,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                }
            });
            dsgbh.Add(b1);

            GroupBH b2 = new GroupBH(2, new List<BaiHoc>
            {
                new BaiHoc
                {

                    TenBH = "Pencil",
                    Hinh = "lesson_pencil.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                },
                new BaiHoc
                {

                    TenBH = "Bike",
                    Hinh = "lesson_bike.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"
                },
                new BaiHoc
                {
                    TenBH = "Hat",
                    Hinh = "lesson_hat.png",
                    MaChang = 2,
                    Diem = 50,
                    ThanhTich = "crown_stroke.png"

                }
            });
            dsgbh.Add(b2);
            lstbh.ItemsSource = dsgbh;


        }
       /* void KhoiTao(User u)
        {
            List<BaiHoc> bhs = new List<BaiHoc>();
            bhs.Add(new BaiHoc {
                TenBH = "Baby",
                Hinh = "lesson_baby.png",
                MaChang = 1,
                ThanhTich = "crown_gray_stroke.png",
                Diem = 50,
                MaND = u.MaND
            });
            bhs.Add(
                new BaiHoc
                {
                    TenBH = "Bag",
                    Hinh = "lesson_bag.png",
                    MaChang = 1,
                    ThanhTich = "crown_gray_stroke.png",
                    Diem = 50,
                    MaND = u.MaND
                });
            bhs.Add(new BaiHoc
            {
                TenBH = "Egg",
                Hinh = "lesson_egg.png",
                MaChang = 1,
                ThanhTich = "crown_gray_stroke.png",
                Diem = 50,
                MaND = u.MaND
            });
            bhs.Add(new BaiHoc
            {
                TenBH = "Pencil",
                Hinh = "lesson_pencil.png",
                MaChang = 2,
                ThanhTich = "crown_gray_stroke.png",
                Diem = 50,
                MaND = u.MaND
            });
            bhs.Add(new BaiHoc
            {
                TenBH = "Bike",
                Hinh = "lesson_bike.png",
                MaChang = 2,
                ThanhTich = "crown_gray_stroke.png",
                Diem = 50,
                MaND = u.MaND
            });
            bhs.Add(new BaiHoc
            {
                TenBH = "Hat",
                Hinh = "lesson_hat.png",
                MaChang = 2,
                ThanhTich = "crown_gray_stroke.png",
                Diem = 50,
                MaND = u.MaND
            });
            for (int i =0; i< bhs.Count; i++)
            {
                BaiHoc bh = new BaiHoc();
                bh = bhs[i];
                if (db.TonTaiBH(bh.MaND, bh.TenBH, bh.MaChang) == false)
                {
                    if (db.ThemBaiHoc(bh))
                        HienThi();
                }
               
            }

            List<GroupBH> dsgbh = new List<GroupBH>();
            GroupBH b1 = new GroupBH(1, db.LayBaiHocTheoChang(1, u.MaND));
            GroupBH b2 = new GroupBH(2, db.LayBaiHocTheoChang(2,u.MaND));
            GroupBH b3 = new GroupBH(3, db.LayBaiHocTheoChang(3,u.MaND));
            dsgbh.Add(b1);
            dsgbh.Add(b2);
            dsgbh.Add(b3);
            lstbh.ItemsSource = dsgbh;

        }*/

        private void lstbh_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            u.Diem += 10;
            if (db.SuaNguoiDung(u) == true) HienThi(u);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            u.Diem += 10;
            if (db.SuaNguoiDung(u) == true) HienThi(u);

        }
    }
}