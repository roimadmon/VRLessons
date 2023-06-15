using System;
using UnityEngine;
using UnityEngine.Events;


    [AddComponentMenu("Level Listeners/GameObject Event Listener")]
    public class GameObjectEventListener : MonoBehaviour
    {
        [SerializeField] UnityEvent onAwake;
        [SerializeField] UnityEvent onStart;
        [SerializeField] UnityEvent onEnable;
        [SerializeField] UnityEvent onDisable;
        [SerializeField] UnityEvent onDestroy;

        private void Awake() => onAwake?.Invoke();

        private void OnEnable() => onEnable?.Invoke();

        private void OnDisable() => onDisable?.Invoke();

        private void Start() => onStart?.Invoke();
        private void OnDestroy() => onDestroy?.Invoke();
        
        
    }

