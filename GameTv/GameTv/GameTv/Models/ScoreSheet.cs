using GameTv.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTv.Models
{
  public  class ScoreSheet: BindableBase
    {
        private string timeMatch;
        public string TimeMatch
        {
            get => timeMatch;
            set { SetProperty(ref timeMatch, value); }
        }
        private string team1;
        public string Team1
        {
            get => team1;
            set { SetProperty(ref team1, value); }
        }
        private string team2;
        public string Team2
        {
            get => team2;
            set { SetProperty(ref team2, value); }
        }
        private string score1;
        public string Score1
        {
            get => score1;
            set { SetProperty(ref score1, value); }
        }
        private string score2;
        public string Score2
        {
            get => score2;
            set { SetProperty(ref score2, value); }
        }
        private string avarta;
        public string Avarta
        {
            get => avarta;
            set { SetProperty(ref avarta, value); }
        }
    }
}
