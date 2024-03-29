﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Martian_Attack
{
    public partial class Form1 : Form
    {
        int gravity = 6;
        int PipeSpeed = -8;
        int Score = 0;
        int starSpeed = -1;
        int HighScores;
        SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(@"C:\Users\phill\Documents\GitHub\Martian_Attack\Martian_Attack\Jump.wav");
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            
            MainPlayer.Top = MainPlayer.Top + gravity;
            NewPipes();
            PipeMovement();
            Bounds();
            ScoreLabel.Text = ($"Score: {Score}");
            HitMarker();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if(e.KeyCode == Keys.Space) {
                soundPlayer.Play();
                gravity = -10;
                e.SuppressKeyPress = true;
            }
            

          
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                
                gravity = 6;  
                
            }



        }
        public void Bounds()
        {
            if (MainPlayer.Top < 0)
            {
                MainPlayer.Top = 0;
            }
            else if (MainPlayer.Top > 355)
            {
                gravity = 0;
            }
             

        }

        public void NewPipes()
        {
            Random rando = new Random();
            if (PipeUpOne.Left < -50)
            {
                PipeUpOne.Left = rando.Next(900, 1000);
                Score++;
            }
            if(PipeUpTwo.Left < -50)
            {
                PipeUpTwo.Left = rando.Next(700, 800);
                Score++;
            }
            if (PipeDownOne.Left < -50)
            {
                PipeDownOne.Left = rando.Next(900, 1000);
                Score++;
            }
            if (PipeDownTwo.Left < -50)
            {
                PipeDownTwo.Left = rando.Next(700, 800);
                Score++;
            }
            if(Star1.Left < -10)
            {
                Star1.Left = rando.Next(800, 900);
            }
            if (Star2.Left < -10)
            {
                Star2.Left = rando.Next(800, 900);
            }
            if (Star3.Left < -10)
            {
                Star3.Left = rando.Next(800, 900);
            }
            if (Star4.Left < -10)
            {
                Star4.Left = rando.Next(800, 900);
            }
            if (Star4.Left < -10)
            {
                Star4.Left = rando.Next(800, 900);
            }
            if (Star5.Left < -10)
            {
                Star5.Left = rando.Next(800, 900);
            }
            if (Star6.Left < -10)
            {
                Star6.Left = rando.Next(800, 900);
            }
            if (Star7.Left < -10)
            {
                Star7.Left = rando.Next(800, 900);
            }
            if (Star8.Left < -10)
            {
                Star8.Left = rando.Next(800, 900);
            }
            if (Star9.Left < -10)
            {
                Star9.Left = rando.Next(800, 900);
            }
            if (Star10.Left < -10)
            {
                Star10.Left = rando.Next(800, 900);
            }

        }

        public void PipeMovement()
        {
            PipeUpOne.Left = PipeUpOne.Left + PipeSpeed;
            PipeUpTwo.Left = PipeUpTwo.Left + PipeSpeed;
            PipeDownOne.Left = PipeDownOne.Left + PipeSpeed;
            PipeDownTwo.Left = PipeDownTwo.Left + PipeSpeed;
            Star1.Left += starSpeed;
            Star2.Left += starSpeed;
            Star3.Left += starSpeed;
            Star4.Left += starSpeed;
            Star5.Left += starSpeed;
            Star6.Left += starSpeed;
            Star7.Left += starSpeed;
            Star8.Left += starSpeed;
            Star9.Left += starSpeed;
            Star10.Left += starSpeed;
        }
      
        public void HitMarker()
        {
            if(MainPlayer.Bounds.IntersectsWith(PipeDownOne.Bounds) ||
                MainPlayer.Bounds.IntersectsWith(PipeDownTwo.Bounds)||
                MainPlayer.Bounds.IntersectsWith(PipeUpOne.Bounds)||
                MainPlayer.Bounds.IntersectsWith(PipeUpTwo.Bounds))
            {
                EndGame();
            }

        }

        public void EndGame()
        {
            var player = new System.Media.SoundPlayer(@"C:\Users\phill\Documents\GitHub\Martian_Attack\Martian_Attack\Alien.wav");
            player.PlayLooping();
            if (HighScores < Score)
            {
                HighScores = Score;
            }
            GameTimer.Stop();
            GameOverLabel.Visible = true;
            MainMenuBtn.Visible = true;
            MainMenuBtn.Enabled = true;
            ScoreLabel.Visible = false;
            HighScore.Text = ($"Your Highest Score so far is {HighScores}");
            FinalScore.Text = ($"Your Final Score is: {Score}");
            FinalScore.Visible = true;
            HighScore.Visible = true;
        }

        private void PipeUpOne_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void PipeDownTwo_Click(object sender, EventArgs e)
        {

        }

        private void MainMenuBtn_Click(object sender, EventArgs e)
        {
            GameOverLabel.Visible = false;
            MainMenuBtn.Visible = false;
            FinalScore.Visible = false;
            HighScore.Visible = false;
            ScoreLabel.Visible = true;
            gravity = 6;
            PipeSpeed = -8;
            Score = 0;
            starSpeed = -1;
            MainPlayer.Top = 180;
            MainMenuBtn.Enabled = false;

            GameTimer.Start();


        }

        
    }
}
