using System;
using System.Collections.Generic;
using System.Text;
//using Java.Util;

namespace TermProject_IA_7.BusinessLogic
{
    public struct Statistics    {
        private int _playerScore;
        private int _computerScore;
        private Bet _coinAmount;

        /// <summary>
        /// Parameterised constructor to initialize a new game statistics snapshot.
        /// </summary>
        /// <param name="playerScore">Starting score for the player.</param>
        /// <param name="computerScore">Starting score for the computer.</param>
        /// <param name="coinAmount">The active Bet instance containing wallet info.</param>
        public Statistics(int playerScore, int computerScore, Bet coinAmount)
        {
            _playerScore = playerScore;
            _computerScore = computerScore;
            _coinAmount = coinAmount;
        }
        
        // Maps directly to the "Player Score Tracker" label on the Stats Screen UI
        public int PlayerScore
        {
            get => _playerScore;
            set => _playerScore = value;
        }

        // Maps directly to the "Computer AI Score Tracker" label on the Stats Screen UI
        public int ComputerScore
        {
            get => _computerScore;
            set => _computerScore = value;
        }

        /// Maps directly to the "Current Wallet Balance" label on the Stats Screen UI
        public Bet CoinAmount
        {
            get => _coinAmount;
            set => _coinAmount = value;
        }
        
    }
}