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
    public partial class TestPage : ContentPage
    {
        Database db;
        List<Question> QuestionList;
        int point = 0, score = 0;
        string Answer, CorrectAnswer;
        BaiHoc b;
        public TestPage()
        {
            InitializeComponent();
        }
        
        public TestPage(BaiHoc bh)
        {
            InitializeComponent();
            db = new Database();
            QuestionList = new List<Question>();
            Khoitao(bh.MaBH);
            Question a = QuestionList[0];
            lblQuestion.Text = a.Quest_;
            btnresp1.Text = a.resp1_;
            btnresp2.Text = a.resp2_;
            btnresp3.Text = a.resp3_;
            btnresp4.Text = a.resp4_;
            CorrectAnswer = a.Correct;

        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void Khoitao(int i)
        {
            QuestionList = db.SelectQuestions(i);
        }
        
        private string QuestionHandle(int i)
        {
            if (i < QuestionList.Count)
            {
                Question q = QuestionList[i];
                lblQuestion.Text = q.Quest_;
                btnresp1.Text = q.resp1_;
                btnresp2.Text = q.resp2_;
                btnresp3.Text = q.resp3_;
                btnresp4.Text = q.resp4_;
                CorrectAnswer = q.Correct;
                return CorrectAnswer;
            }
            else
            {
                btnconfirm.IsVisible = false;
                btnresult.IsVisible = true;
                return null;
            }
        }

        public void clearpressed()
        {
            Answer = null;
            btnresp1.BackgroundColor = Color.White;
            btnresp1.TextColor = Color.Black;
            btnresp2.BackgroundColor = Color.White;
            btnresp2.TextColor = Color.Black;
            btnresp3.BackgroundColor = Color.White;
            btnresp3.TextColor = Color.Black;
            btnresp4.BackgroundColor = Color.White;
            btnresp4.TextColor = Color.Black;
        }

        private void btnresp1_Clicked(object sender, EventArgs e)
        {
            QuestionHandle(point);
            clearpressed();
            btnresp1.BackgroundColor = Color.LawnGreen;
            btnresp1.TextColor = Color.White;
            Answer = btnresp1.Text;
        }

        private void btnresp2_Clicked(object sender, EventArgs e)
        {
            QuestionHandle(point);
            clearpressed();
            btnresp2.BackgroundColor = Color.LawnGreen;
            btnresp2.TextColor = Color.White;
            Answer = btnresp2.Text;
        }

        private void btnresp3_Clicked(object sender, EventArgs e)
        {
            QuestionHandle(point);
            clearpressed();
            btnresp3.BackgroundColor = Color.LawnGreen;
            btnresp3.TextColor = Color.White;
            Answer = btnresp3.Text;
        }

        private void btnresp4_Clicked(object sender, EventArgs e)
        {
            QuestionHandle(point);
            clearpressed();
            btnresp4.BackgroundColor = Color.LawnGreen;
            btnresp4.TextColor = Color.White;
            Answer = btnresp4.Text;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {

        }

        private void btnresult_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultPage(score));
        }

        async void btnconfirm_Clicked(object sender, EventArgs e)
        {
            if (Answer != null)
            {
                pbar.Progress += 0.25;
                if (Answer == CorrectAnswer)
                {
                    score += 10;
                }
                point++;
                QuestionHandle(point);
                clearpressed();
            }
            else await DisplayAlert("", "Hãy chọn một đáp án cho câu hỏi này nhé", "OK"); 
        }
        

    }
}