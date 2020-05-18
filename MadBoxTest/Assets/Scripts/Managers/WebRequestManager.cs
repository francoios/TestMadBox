using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace MadBoxTest
{
    public class WebRequestManager : MadBoxMonobehaviour
    {
        #region Singleton
        private static WebRequestManager _instance;
        public static WebRequestManager Instance
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

        /// <summary>
        /// this method is started by coroutine, it is simply trying to access the following URI to retrive users data
        /// from the score board
        /// </summary>
        /// <param name="uri"> exemple : http://localhost:3000/GetScore</param>
        /// <returns></returns>
        IEnumerator GetScoresRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    EventManager.TriggerEvent(GameHandlerData.GetPlayersScoresFailureHandler);
                    Debug.Log(pages[page] + ": Error: " + webRequest.error);
                }
                else
                {
                    JsonUtility.ToJson(webRequest.downloadHandler.text);
                    ScoreManager.Instance._scoresCollection.users = null;
                    ScoreManager.Instance._scoresCollection = JsonUtility.FromJson<ScoresCollection>(webRequest.downloadHandler.text);
                    EventManager.TriggerEvent(GameHandlerData.GetPlayersScoresSuccessHandler);
                }
            }
        }
        
        IEnumerator SendScoreRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    EventManager.TriggerEvent(GameHandlerData.SendPlayerScoreFailureHandler);
                    Debug.Log(pages[page] + ": Error: " + webRequest.error);
                }
                else
                {
                    JsonUtility.ToJson(webRequest.downloadHandler.text);
                    EventManager.TriggerEvent(GameHandlerData.SendPlayerScoreSuccessHandler);
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                }
            }
        }
        
        IEnumerator TestServerRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    EventManager.TriggerEvent(GameHandlerData.TestServerConnectivityFailureHandler);
                }
                else
                {
                    JsonUtility.ToJson(webRequest.downloadHandler.text);
                    if (webRequest.downloadHandler.text == "ok")
                        EventManager.TriggerEvent(GameHandlerData.TestServerConnectivitySuccessHandler);
                }
            }
        }
        

        protected override void EventHandlerRegister()
        {
            EventManager.StartListening(GameHandlerData.TestServerConnectivityHandler, TestServer);
            EventManager.StartListening(GameHandlerData.SendPlayerScoreHandler, SendPlayerScore);
            EventManager.StartListening(GameHandlerData.GetPlayersScoresHandler, GetPlayersScores);
            base.EventHandlerRegister();
        }

        private void GetPlayersScores(object arg0)
        {
            StartCoroutine(GetScoresRequest("http://localhost:3000/GetScore"));
        }

        private void SendPlayerScore(object arg0)
        {
            playerScoreMessage msg = arg0 as playerScoreMessage;
            StartCoroutine(SendScoreRequest("http://localhost:3000/AddScore?user="+msg.playerName+"&score="+msg.playerScore));
        }

        private void TestServer(object arg0)
        {
            StartCoroutine(TestServerRequest("http://localhost:3000/"));
        }

        protected override void EventHandlerUnRegister()
        {
            base.EventHandlerUnRegister();
            EventManager.StopListening(GameHandlerData.TestServerConnectivityHandler, TestServer);
            EventManager.StopListening(GameHandlerData.SendPlayerScoreHandler, SendPlayerScore);
            EventManager.StopListening(GameHandlerData.GetPlayersScoresHandler, GetPlayersScores);
        }
    }
}