﻿
using UnityEngine;

namespace MadBoxTest
{
    public class MenuManager : MadBoxMonobehaviour
    {
        public GameObject basicMenu;
        public GameObject scoreBoard;
        
        public UIInput userInput;
        public UIInput scoreInput;

        public UIButton sendScores;
        public UIButton getScores;
        public UIButton returnToMenu;
        
        #region Singleton

        private static MenuManager _instance;

        public static MenuManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(transform.gameObject);
                return;
            }

            DontDestroyOnLoad(transform.gameObject);
        }

        #endregion

        protected override void EventHandlerRegister()
        {
            base.EventHandlerRegister();
            EventManager.StartListening(GameHandlerData.GetPlayersScoresSuccessHandler, GoToScoreBoard);
        }

        protected override void EventHandlerUnRegister()
        {
            EventManager.StopListening(GameHandlerData.GetPlayersScoresSuccessHandler, GoToScoreBoard);
            base.EventHandlerUnRegister();
        }

        public void SendPlayerScore()
        {
            playerScoreMessage msg = new playerScoreMessage();
            msg.playerName = userInput.value;
            msg.playerScore = int.Parse(scoreInput.value);
            EventManager.TriggerEvent(GameHandlerData.SendPlayerScoreHandler, msg);
        }

        public void GetPlayersScores()
        {
            EventManager.TriggerEvent(GameHandlerData.GetPlayersScoresHandler, null);
        }

        public void TestConnectivity()
        {
            EventManager.TriggerEvent(GameHandlerData.TestServerConnectivityHandler);
        }

        public void ReturnToMenu()
        {
            basicMenu.GetComponent<TweenTransform>().PlayReverse();
            scoreBoard.GetComponent<TweenTransform>().PlayReverse();
        }
        
        private void GoToScoreBoard(object arg0)
        {
            GoToPlayerScoresBoard();
        }
        
        public void GoToPlayerScoresBoard()
        {
            basicMenu.GetComponent<TweenTransform>().PlayForward();
            scoreBoard.GetComponent<TweenTransform>().PlayForward();
        }
    }
}