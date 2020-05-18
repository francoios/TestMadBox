using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MadBoxTest
{
    [System.Serializable]
    public class CustomEvent : UnityEvent<System.Object>
    {
    }

    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;

        private Dictionary<string, CustomEvent> _eventDictionary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _eventDictionary = new Dictionary<string, CustomEvent>();
            }
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public static void StartListening(string eventName, UnityAction<System.Object> listener)
        {
            CustomEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new CustomEvent();
                thisEvent.AddListener(listener);
                Instance._eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction<System.Object> listener)
        {
            if (Instance == null) return;
            CustomEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(string eventName, System.Object arg = null)
        {
            CustomEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(arg);
            }
        }
    }
}