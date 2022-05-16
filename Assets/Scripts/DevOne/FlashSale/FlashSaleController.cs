using DevOne.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevOne.Analytic;
using System;

namespace DevOne.FlashSale
{
    [ScriptOrder(-100)]
    public class FlashSaleController : Singleton<FlashSaleController>
    {
        public event Action<FlashItem> OnFlashPopupShow;

        public float FlashTime;

        private int itemIndex;
        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            private set { }

        }

        [SerializeField]
        private List<FlashItem> itemList;

        public int StartTimeFlashSale
        {
            get
            {
                return PlayerPrefs.GetInt("DevOne.FlashTime", 0);
            }

            set
            {
                PlayerPrefs.SetInt("DevOne.FlashTime", value);
            }
        }

        public override void InitInAwake()
        {
            if (IsShowFlashSale)
            {
                StartFlashSale();
            }
        }

        private void StartFlashSale()
        {
            Debug.Log("StartFlashSale");

            itemIndex = UnityEngine.Random.Range(0, itemList.Count);
            StartTimeFlashSale = GetSecondTime(DateTime.Now);

            if (OnFlashPopupShow != null)
            {
                OnFlashPopupShow.Invoke(itemList[itemIndex]);
                FlashTime = itemList[itemIndex].Time;
            }
        }

        public int GetFlashTimeBySecond()
        {
            int nowTime = GetSecondTime(DateTime.Now);
            return Mathf.Max(itemList[itemIndex].Time - nowTime - StartTimeFlashSale, 0);
        }

        private bool IsShowFlashSale
        {
            get
            {
                if (LocalAnalytic.Instance.logAppDay < 2)
                    return false;

                if (LocalAnalytic.Instance.logAppNumberInDay == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public static int GetSecondTime(DateTime dateTime)
        {
            return dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
        }

    }
}
