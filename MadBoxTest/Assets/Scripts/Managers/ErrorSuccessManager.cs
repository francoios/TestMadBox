using System.Collections;
using System.Collections.Generic;
using MadBoxTest;
using UnityEngine;

public class ErrorSuccessManager : MadBoxMonobehaviour
{
    public GameObject errorWindow;
    public UILabel errorMessage;

    protected override void EventHandlerRegister()
    {
        base.EventHandlerRegister();
        EventManager.StartListening(GameHandlerData.GetPlayersScoresFailureHandler, GetScoresFailureNotification);
        EventManager.StartListening(GameHandlerData.SendPlayerScoreFailureHandler, SendScoresFailureNotification);
        EventManager.StartListening(GameHandlerData.SendPlayerScoreSuccessHandler, SendScoresSuccessNotification);
        EventManager.StartListening(GameHandlerData.TestServerConnectivityFailureHandler,
            TestServerConnectivityFailureNotification);
    }

    private void TestServerConnectivityFailureNotification(object arg0)
    {
        errorMessage.text = "Connectivity error please check your network and try again";
        errorMessage.color = Color.red;
        StartCoroutine(HideMessage());
    }

    private void SendScoresFailureNotification(object arg0)
    {
        errorMessage.text = "Error while trying to reach the server, please try again";
        errorMessage.color = Color.red;
        StartCoroutine(HideMessage());
    }
    
    private void SendScoresSuccessNotification(object arg0)
    {
        print("test");
        errorMessage.text = "Data saved to the server";
        errorMessage.color = Color.green;
        StartCoroutine(HideMessage());
    }

    private void GetScoresFailureNotification(object arg0)
    {
        errorMessage.text = "Error while retrieving the scores from the servers. please try again";
        errorMessage.color = Color.red;
        StartCoroutine(HideMessage());
    }

    protected override void EventHandlerUnRegister()
    {
        base.EventHandlerUnRegister();
        EventManager.StopListening(GameHandlerData.GetPlayersScoresFailureHandler, GetScoresFailureNotification);
        EventManager.StopListening(GameHandlerData.SendPlayerScoreFailureHandler, SendScoresFailureNotification);
        EventManager.StopListening(GameHandlerData.TestServerConnectivityFailureHandler,
            TestServerConnectivityFailureNotification);
    }
    
    IEnumerator HideMessage()
    {
        errorWindow.GetComponent<TweenTransform>().PlayForward();
        yield return new WaitForSeconds(5);
        errorWindow.GetComponent<TweenTransform>().PlayReverse();
    }
}
