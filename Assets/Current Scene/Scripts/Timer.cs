using UnityEngine;
using UnityEngine.Events;


    public class Timer : MonoBehaviour
    {
        [System.Serializable]
        public class TimeStringEvent : UnityEvent<string> { }
        [System.Serializable]
        public class TimeFloatEvent : UnityEvent<float> { }

        [SerializeField] private bool autoStart;
        float timeLeft = 0;
        public float TimeLeft => timeLeft;
        string lastTimeString;
        string timeLeftString;
        public string TimeLeftString => timeLeftString;
        float timeLimit = float.MaxValue;
        public float TimeLimit => timeLimit;
        public float minTimeLimit = 5;
        public float maxTimeLimit = 10;

        public UnityEvent onStart;
        public TimeStringEvent onTimeUpdateText;
        public TimeFloatEvent onTimeUpdateSeconds;
        public UnityEvent onTimesUp;
        public UnityEvent onPause;
        public UnityEvent onContinue;
        public UnityEvent onReset;

        bool running = false;
        private void Update()
        {
            UpdateTimer();
        }

        private void OnEnable()
        {
            if (autoStart) StartOrContinueTimer();
            UpdateTimeString();
            if (running && timeLeft > 0) onContinue.Invoke();
        }

        private void OnDisable()
        {
            if (running)
            {
                timeLeft = timeLimit;
                onPause.Invoke();
            }
        }

        void UpdateTimer()
        {
            if (!running) return;

            timeLeft -= Time.deltaTime;

            if (timeLeft > 0)
            {
                onTimeUpdateSeconds?.Invoke(timeLeft);
                UpdateTimeString();
                // Debug.Log(timeLeft);
            }
            else
            {
                running = false;
                timeLeft = 0;
                UpdateTimeString();
                onTimesUp?.Invoke();
                // Debug.Log("time End");
            }
        }

#if UNITY_EDITOR
        static readonly string stopTitle = "Stopped";
        static readonly string runningTitle = "Running";
        static readonly Color runningTitleColor = new Color(0.8f, 1, 0.8f);
        static readonly Color stopTitleColor = Color.white;

        string Title
        {
            get
            {
                return running switch
                {
                    true => $"{runningTitle}\n{timeLeftString}",
                    _ => $"{stopTitle}\n{timeLeftString}",
                };
            }
        }

        Color TitleColor => running switch
        {
            true => runningTitleColor,
            _ => stopTitleColor,
        };
#endif

     
        public void StartOrContinueTimer()
        {
            if (timeLeft <= 0) ResetTimer();
            running = true;
            if (timeLeft >= timeLimit)
                onStart?.Invoke();
            else
                onContinue?.Invoke();
            UpdateTimeString();
        }

       
        public void PauseTimer()
        {
            if (!running) return;

            running = false;
            onPause?.Invoke();
        }

    
        public void ResetTimer()
        {
            if (timeLeft >= timeLimit) return;

            if (running) PauseTimer();

            timeLimit = Mathf.Abs(Random.Range(minTimeLimit, maxTimeLimit));
            timeLeft = timeLimit;
            UpdateTimeString();
            
            onReset?.Invoke();
        }

        string ConvertSecondsToTimeString(float time)
        {
            return $"{Mathf.Floor(time / 60).ToString("00")}:{Mathf.Floor(time % 60).ToString("00")}";
        }

        void UpdateTimeString()
        {
            timeLeftString = ConvertSecondsToTimeString(timeLeft);
            if (timeLeftString != lastTimeString)
            {
                onTimeUpdateText?.Invoke(TimeLeftString);
                lastTimeString = timeLeftString;
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
        }
    }



