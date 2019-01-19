using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TicTacToe
{
    [Activity(Label = "Oso's TicTacToe", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity 
    {
        public char[,] TTT = new char[3,3];

        //for initializing players

        int player = 1;

        int P1Score=0;
        int P2Score=0;

        int turns=0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Randomizes who goes first
            Random Rnd = new Random();
            TextView Turn = FindViewById<TextView>(Resource.Id.textView1);
            player = Rnd.Next(0,1);
            if (player == 0)
                Turn.Text = "O's Turn";
            else
                Turn.Text = "X's Turn";

            //Button instances
            Button B1 = FindViewById<Button>(Resource.Id.button1);
            Button B2 = FindViewById<Button>(Resource.Id.button2);
            Button B3 = FindViewById<Button>(Resource.Id.button3);
            Button B4 = FindViewById<Button>(Resource.Id.button4);
            Button B5 = FindViewById<Button>(Resource.Id.button5);
            Button B6 = FindViewById<Button>(Resource.Id.button6);
            Button B7 = FindViewById<Button>(Resource.Id.button7);
            Button B8 = FindViewById<Button>(Resource.Id.button8);
            Button B9 = FindViewById<Button>(Resource.Id.button9);

            //event handling
            B1.Click += delegate { Clicky(0, 0); B1.Text = string.Format("{0}",(TTT[0, 0])); };
            B2.Click += delegate { Clicky(0, 1); B2.Text = string.Format("{0}",(TTT[0, 1])); };
            B3.Click += delegate { Clicky(0, 2); B3.Text = string.Format("{0}",(TTT[0, 2])); };
            B4.Click += delegate { Clicky(1, 0); B4.Text = string.Format("{0}",(TTT[1, 0])); };
            B5.Click += delegate { Clicky(1, 1); B5.Text = string.Format("{0}",(TTT[1, 1])); };
            B6.Click += delegate { Clicky(1, 2); B6.Text = string.Format("{0}",(TTT[1, 2])); };
            B7.Click += delegate { Clicky(2, 0); B7.Text = string.Format("{0}",(TTT[2, 0])); };
            B8.Click += delegate { Clicky(2, 1); B8.Text = string.Format("{0}",(TTT[2, 1])); };
            B9.Click += delegate { Clicky(2, 2); B9.Text = string.Format("{0}",(TTT[2, 2])); };

         

        }

        void Clicky(int x,int y)//event handling
        {
            if (TTT[x, y] != '\0')
                return;
            if (player == 0)
            {
                player = 1;
                TTT[x, y] = 'O';
                turns++;
                O_checker(0);
            }
                
            else
            {
                player = 0;
                TTT[x, y] = 'X';
                turns++;
                X_checker(1);
            }

            TextView Turn = FindViewById<TextView>(Resource.Id.textView1);
            if (player == 0)
                Turn.Text = "O's Turn";
            else
                Turn.Text = "X's Turn";


            return;
        }

        void X_checker(int n)
        {
            TextView view = FindViewById<TextView>(Resource.Id.textView2);
            //horizontally
            if (TTT[0, 0] == 'X' && TTT[0, 1] == 'X' && TTT[0, 2] == 'X')
                Win(1,"Player 2 Has Won The Match!");
            else if (TTT[1, 0] == 'X' && TTT[1, 1] == 'X' && TTT[1, 2] == 'X')
                Win(1, "Player 2 Has Won The Match!");
            else if (TTT[2, 0] == 'X' && TTT[2, 1] == 'X' && TTT[2, 2] == 'X')
                Win(1, "Player 2 Has Won The Match!");

            //vertically
            else if (TTT[0, 0] == 'X' && TTT[1, 0] == 'X' && TTT[2, 0] == 'X')
                Win(1, "Player 2 Has Won The Match!");
            else if (TTT[0, 1] == 'X' && TTT[1, 1] == 'X' && TTT[2, 1] == 'X')
                Win(1, "Player 2 Has Won The Match!");
            else if (TTT[0, 2] == 'X' && TTT[1, 2] == 'X' && TTT[2, 2] == 'X')
                Win(1, "Player 2 Has Won The Match!");

            //diagonally
            else if (TTT[0, 0] == 'X' && TTT[1, 1] == 'X' && TTT[2, 2] == 'X')
                Win(1, "Player 2 Has Won The Match!");
            else if (TTT[0, 2] == 'X' && TTT[1, 1] == 'X' && TTT[2, 0] == 'X')
                Win(1, "Player 2 Has Won The Match!");
            else if (turns == 9)
            {
                Win(2, "It's a Draw!");
            }
            return;
        }

        void O_checker(int n)
        {
            TextView view = FindViewById<TextView>(Resource.Id.textView2);
            //horizontally
            if (TTT[0, 0] == 'O' && TTT[0, 1] == 'O' && TTT[0, 2] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (TTT[1, 0] == 'O' && TTT[1, 1] == 'O' && TTT[1, 2] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (TTT[2, 0] == 'O' && TTT[2, 1] == 'O' && TTT[2, 2] == 'O')
                Win(0, "Player 1 Has Won The Match!");

            //vertically
            else if (TTT[0, 0] == 'O' && TTT[1, 0] == 'O' && TTT[2, 0] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (TTT[0, 1] == 'O' && TTT[1, 1] == 'O' && TTT[2, 1] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (TTT[0, 2] == 'O' && TTT[1, 2] == 'O' && TTT[2, 2] == 'O')
                Win(0, "Player 1 Has Won The Match!");

            //diagonally
            else if (TTT[0, 0] == 'O' && TTT[1, 1] == 'O' && TTT[2, 2] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (TTT[0, 2] == 'O' && TTT[1, 1] == 'O' && TTT[2, 0] == 'O')
                Win(0, "Player 1 Has Won The Match!");
            else if (turns == 9)
            {
                Win(2, "It's a Draw!");
            }
            return;
        }

        void Win(int P,string S)
        {
            TextView S1 = FindViewById<TextView>(Resource.Id.Score1);
            TextView S2 = FindViewById<TextView>(Resource.Id.Score2);

            AlertDialog.Builder build = new AlertDialog.Builder(this);
            build.SetTitle(string.Format("{0}", S));
            build.SetMessage("Do you want to continue the match or new game?");
            build.SetCancelable(false);
            build.SetPositiveButton("Continue", (object sender, DialogClickEventArgs e )=>{
                ContinueGame();
            });
            build.SetNegativeButton("New Game", (object sender, DialogClickEventArgs e) =>
            {
                NewGame();
            });

            switch (P)
            {
                case 0:this.P1Score+=1;break;
                case 1:this.P2Score+=1;break;
                case 2:break;
            }

            S1.Text = string.Format("{0}", P1Score);
            S2.Text = string.Format("{0}", P2Score);

            AlertDialog win = build.Create();
            win.Show();
        }

        void NewGame()
        {
            TextView S1 = FindViewById<TextView>(Resource.Id.Score1);
            TextView S2 = FindViewById<TextView>(Resource.Id.Score2);
            Button B1 = FindViewById<Button>(Resource.Id.button1);
            Button B2 = FindViewById<Button>(Resource.Id.button2);
            Button B3 = FindViewById<Button>(Resource.Id.button3);
            Button B4 = FindViewById<Button>(Resource.Id.button4);
            Button B5 = FindViewById<Button>(Resource.Id.button5);
            Button B6 = FindViewById<Button>(Resource.Id.button6);
            Button B7 = FindViewById<Button>(Resource.Id.button7);
            Button B8 = FindViewById<Button>(Resource.Id.button8);
            Button B9 = FindViewById<Button>(Resource.Id.button9);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    TTT[x, y] = '\0';
                }
            }

            B1.Text = null;
            B2.Text = null;
            B3.Text = null;
            B4.Text = null;
            B5.Text = null;
            B6.Text = null;
            B7.Text = null;
            B8.Text = null;
            B9.Text = null;

            turns = 0;
            P1Score = 0;
            P2Score = 0;
            S1.Text = "";
            S2.Text = "";
        }

        void ContinueGame()
        {
            Button B1 = FindViewById<Button>(Resource.Id.button1);
            Button B2 = FindViewById<Button>(Resource.Id.button2);
            Button B3 = FindViewById<Button>(Resource.Id.button3);
            Button B4 = FindViewById<Button>(Resource.Id.button4);
            Button B5 = FindViewById<Button>(Resource.Id.button5);
            Button B6 = FindViewById<Button>(Resource.Id.button6);
            Button B7 = FindViewById<Button>(Resource.Id.button7);
            Button B8 = FindViewById<Button>(Resource.Id.button8);
            Button B9 = FindViewById<Button>(Resource.Id.button9);

            for (int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    TTT[x, y] = '\0';
                }
            }

            B1.Text = null;
            B2.Text = null;
            B3.Text = null;
            B4.Text = null;
            B5.Text = null;
            B6.Text = null;
            B7.Text = null;
            B8.Text = null;
            B9.Text = null;

            turns = 0;
        }

    }
}

