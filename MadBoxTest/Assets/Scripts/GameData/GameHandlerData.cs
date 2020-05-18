using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace MadBoxTest
{
    [System.Serializable]
    public class MoneyMessage : UnityEvent<System.Object>
    {
    }

    [System.Serializable]
    public class ObjectSelectedMessage : UnityEvent<System.Object>
    {
        public GameObject selectedGameObject;
    }

    public static class GameHandlerData
    {
        /* ScoreBoards Handlers */

        #region ScoreBoard Handlers
        public static readonly string GetPlayersScoresHandler = "GetPlayersScores";
        public static readonly string GetPlayersScoresSuccessHandler = "GetPlayersScoresSuccess";
        public static readonly string GetPlayersScoresFailureHandler = "GetPlayersScoresFailure";
        public static readonly string SendPlayerScoreHandler = "SendPlayerScore";
        public static readonly string SendPlayerScoreSuccessHandler = "SendPlayerScoreSuccess";
        public static readonly string SendPlayerScoreFailureHandler = "SendPlayerScoreFailure";
        public static readonly string TestServerConnectivityHandler = "TestServerConnectivity";
        public static readonly string TestServerConnectivitySuccessHandler = "TestServerConnectivitySuccess";
        public static readonly string TestServerConnectivityFailureHandler = "TestServerConnectivityFailure";
        #endregion

        #region Basics Handlers
        public static readonly string SceneLoadedHandler = "SceneLoaded";
        public static readonly string GameStartingHandler = "GameStarting";
        #endregion
    }
}