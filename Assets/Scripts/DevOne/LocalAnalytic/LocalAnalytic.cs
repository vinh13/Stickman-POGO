using System;
using System.Collections;
using System.Collections.Generic;
using DevOne.Patterns;
using UnityEngine;

namespace DevOne.Analytic
{
    [ScriptOrder(-1000)]
    public class LocalAnalytic : Singleton<LocalAnalytic>
    {
        public const string LOG_APP_NUMBER_KEY = "DEVONE_LOG_APP_NUMBER_KEY";
        public const string LOG_APP_DAY_KEY = "DEVONE_LOG_APP_DAY_KEY";
        public const string LAST_DAY_KEY = "DEVONE_LAST_DAY_KEY";
        public const string LOG_APP_NUMBER_IN_DAY_KEY = "DEVONE_LOG_APP_NUMBER_IN_DAY_KEY";
        public const string APP_TIME_KEY = "DEVONE_APP_TIME_KEY";
        public const string APP_TIME_IN_DAY_KEY = "DEVONE_APP_TIME_IN_DAY_KEY";

        public float timeInGame
        {
            get
            {
                return PlayerPrefs.GetFloat(APP_TIME_KEY, 0);
            }

            set
            {
                PlayerPrefs.SetFloat(APP_TIME_KEY, value);
            }
        }

        public float timeInGameToDay
        {
            get
            {
                return PlayerPrefs.GetFloat(APP_TIME_IN_DAY_KEY, 0);
            }

            set
            {
                PlayerPrefs.SetFloat(APP_TIME_IN_DAY_KEY, value);
            }
        }

        public int logAppNumber
        {
            get
            {
                return PlayerPrefs.GetInt(LOG_APP_NUMBER_KEY, 0);
            }
            set
            {
                PlayerPrefs.SetInt(LOG_APP_NUMBER_KEY, value);
            }
        }

        public int logAppNumberInDay
        {
            get
            {
                return PlayerPrefs.GetInt(LOG_APP_NUMBER_IN_DAY_KEY, 0);
            }
            set
            {
                PlayerPrefs.SetInt(LOG_APP_NUMBER_IN_DAY_KEY, value);
            }
        }

        public int logAppDay
        {
            get
            {
                return PlayerPrefs.GetInt(LOG_APP_DAY_KEY, 0);
            }

            set
            {
                PlayerPrefs.SetInt(LOG_APP_DAY_KEY, value);
            }
        }

        private string LastDayValue
        {
            get
            {
                return PlayerPrefs.GetString(LAST_DAY_KEY, "lastDay");
            }

            set
            {
                PlayerPrefs.SetString(LAST_DAY_KEY, value);
            }
        }

        public override void InitInAwake()
        {
            logAppNumber++;

            string dayString = NowDayToString();

            Debug.Log("Day string: " + dayString);

            if (LastDayValue != dayString)
            {
                // New Day
                LastDayValue = dayString;
                logAppDay++;
                logAppNumberInDay = 0;
                timeInGameToDay = 0;
            }
            logAppNumberInDay++;
        }

        void Update()
        {
            timeInGame += Time.deltaTime;
            timeInGameToDay += Time.deltaTime;
        }

        private string NowDayToString()
        {
            return DateTime.Now.Date.ToShortDateString();
        }

        public bool IsFirstPlayInDay()
        {
            return logAppNumberInDay == 1;
        }
    }


}
