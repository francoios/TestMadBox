using System;
using System.Collections;
using System.Collections.Generic;
using MadBoxTest;
using UnityEngine;

namespace MadBoxTest
{
    public class MadBoxMonobehaviour : MonoBehaviour
    {
        public bool ScriptReady = false;

        // Use this for initialization
        public virtual void Start()
        {
            EventHandlerRegister();
            ScriptReady = true;
        }

        private void OnDestroy()
        {
            EventHandlerUnRegister();
        }

        protected virtual void EventHandlerRegister()
        {
            EventManager.StartListening(GameHandlerData.SceneLoadedHandler, OnSceneLoaded);
            EventManager.StartListening(GameHandlerData.GameStartingHandler, OnGameStarting);
        }

        protected virtual void EventHandlerUnRegister()
        {
            EventManager.StopListening(GameHandlerData.SceneLoadedHandler, OnSceneLoaded);
            EventManager.StopListening(GameHandlerData.GameStartingHandler, OnGameStarting);
        }

        protected virtual void OnSceneLoaded(object arg0)
        {
        }

        protected virtual void OnGameStarting(object arg0)
        {
        }

    }
}