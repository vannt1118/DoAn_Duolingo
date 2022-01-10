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
    public partial class NguoiDungPage : ContentPage
    {
        Database db = new Database();
        User u;
        public NguoiDungPage()
        {
            InitializeComponent();
            Thu();
        }
        public NguoiDungPage(User nd)
        {
            InitializeComponent();
            u = nd;
            txtten.Text = nd.TenND;
            txtemail.Text = nd.Email;
            img.Source = nd.Hinh;
            Thu();
        }

        public NguoiDungPage(string ten, string hinh, string email)
        {
            InitializeComponent();
            txtten.Text = ten;
            txtemail.Text = email;
            img.Source = hinh;
            Thu();
        }
        void Thu()
        {
            List<User> nds = new List<User>();
            nds.Add(
                new User
                {
                    TenND = "Marge",
                    Email = "user1@gmail.com",
                    Hinh = "profile_friends_marge.png",
                    Diem = 150
                });
            nds.Add(
                new User
                {
                    TenND = "Lisa",
                    Email = "user2@gmail.com",
                    Hinh = "profile_friends_lisa.png",
                    Diem = 320
                });
            nds.Add(
                new User
                {
                    TenND = "Homer",
                    Email = "user3@gmail.com",
                    Hinh = "profile_friends_homer.png",
                    Diem = 60
                });
            nds.Add(
                new User
                {
                    TenND = "HuaHua",
                    Email = "user4@gmail.com",
                    Hinh = "dc_1.jpg",
                    Diem = 360
                });
            nds.Add(
                new User
                {
                    TenND = "Nagisa",
                    Email = "user5@gmail.com",
                    Hinh = "dc_4.jfif",
                    Diem = 150
                });
            lstnd.ItemsSource = nds;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSuaPage(u));
        }

        private async void btndx_Clicked(object sender, EventArgs e)
        {
            var dn = new MainPage();
            await Navigation.PushModalAsync(dn);
            
        }

        private void img_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChinhSuaPage(u));
        }

        private async void btnmk_Clicked(object sender, EventArgs e)
        {
            var mk = new MatKhauPage(u);
            await Navigation.PushModalAsync(mk);
        }
    }
}