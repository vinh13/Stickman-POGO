using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text TextTimerLive;
    [SerializeField] Text TextTimeEnd;
    [SerializeField] Text TextJumpEnd;
    [SerializeField] Text TextTotalScoreEnd;
    [SerializeField] Text TextCoinEarn;

    public int countJump;
    public int totalScore;
    public int coinEarn;

    public float timer = 0;
    int countTimeInt = 0;

    public GameObject buttonX2Coin;

    string nameLevel = "";

    int meter = 0;

    void Start()
    {

        countTimeInt = 1;
        nameLevel = Logic.NameMode;
        nameLevel += "" + Logic.IdLevel;
    }

    void Update()
    {
        if (Logic.IsEnd)
            return;
        timer += Time.deltaTime;
        if (timer >= countTimeInt)
        {
            UpdateTextTimer();
        }
    }

    void UpdateTextTimer()
    {
        countTimeInt++;
        TextTimerLive.text = "" + (countTimeInt - 1);
    }

    public void OnWin()
    {

        countJump = PogoContact.countJump;
       
        totalScore = (int)((timer * 1000) / countJump);
        float temp = timer;
        if (temp > 10)
            temp = 10;
        totalScore += (int)((10 - temp) * 1000);


        if (HUDManager.Instance.endlessMode)
        {
            meter = (int)Camera.main.transform.position.x;
            totalScore += meter * 1000;
        }
        TextTimeEnd.text = "" + timer;
        TextJumpEnd.text = "" + countJump;
        TextTotalScoreEnd.text = "" + totalScore;

        coinEarn = (int)(totalScore / 55);

        TextCoinEarn.text = "" + coinEarn;
        Manager.Instance.UpdateCOIN(coinEarn);


        int bestscore = PlayerPrefs.GetInt(nameLevel + "bestscore");
        if (totalScore > bestscore)
        {
            bestscore = totalScore;
            PlayerPrefs.SetInt(nameLevel + "bestscore", bestscore);
        }

        buttonX2Coin.SetActive(AllInOne.Instance.CheckUnityADS());

        PlayerPrefs.SetInt(Logic.NameMode + "" + (Logic.IdLevel + 1) + "unlocked", 1);
        PlayerPrefs.Save();
       
    }

    public void X2Coin()
    {
        Manager.Instance.UpdateCOIN(coinEarn);
        buttonX2Coin.SetActive(false);
    }
   
}
