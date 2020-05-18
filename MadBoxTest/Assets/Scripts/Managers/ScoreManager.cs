using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MadBoxTest;
using UnityEngine;

public class ScoreManager : MadBoxMonobehaviour
{
    public ScoresCollection _scoresCollection;
    public GameObject scorePrefab;
    public GameObject scrollView;
    private List<GameObject> _scores = new List<GameObject>();
    
    
    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance
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
        EventManager.StartListening(GameHandlerData.GetPlayersScoresSuccessHandler, PopulateScoreBoard);
        base.EventHandlerRegister();
    }

    private void PopulateScoreBoard(object arg0)
    {
        if (_scores.Count > 0)
            foreach (GameObject o in _scores)
            {
                Destroy(o);
            }
        _scores.Clear();
        _scoresCollection.users = _scoresCollection.users.ToList().OrderBy(w => w.score).ToArray();
        int i = 0;
        foreach (Player player in _scoresCollection.users)
        {
            GameObject obj = Instantiate(scorePrefab, scrollView.transform);
            _scores.Add(obj);
            PlayerScorePrefabData data = obj.GetComponent<PlayerScorePrefabData>();
            data.SetPosition(i);
            data.SetScore(player.score);
            data.SetUserName(player.user);
            i++;
        }
        scrollView.GetComponent<UIGrid>().enabled = true;
    }

    protected override void EventHandlerUnRegister()
    {
        EventManager.StartListening(GameHandlerData.GetPlayersScoresSuccessHandler, OnSceneLoaded);
        base.EventHandlerUnRegister();
    }
}
