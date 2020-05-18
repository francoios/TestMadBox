using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;


namespace MadBoxTest
{
    public class GameManager : MadBoxMonobehaviour
    {
        [SerializeField] private ScoresCollection _scoresCollection;

        #region Singleton

        private static GameManager _instance;

        public static GameManager Instance
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


        public override void Start()
        {
            base.Start();
        }

        protected override void EventHandlerRegister()
        {
            base.EventHandlerRegister();
        }

        protected override void EventHandlerUnRegister()
        {
            base.EventHandlerUnRegister();
        }
    }
}


    