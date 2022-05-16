using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomCoin : MonoBehaviour
{


    public Text[] txtNumber = new Text[3];
    public int[] number = new int[3];
    float timer = 0;
    public float durationFrame;
    bool play = false;
    int count = 0;
    public GameObject btnWatchVideo, btnBack;

    void OnEnable()
    {
        btnWatchVideo.SetActive(true);
    }

    void Update()
    {
        if (!play)
            return;
        timer += Time.unscaledDeltaTime;
        if (timer >= durationFrame)
        {
            _PlayRanDom();
            timer = 0;
        }
    }

    void  _PlayRanDom()
    {
        //
        count++;
        int i = Random.Range(1, 10);
        if (i < 9)
        {
            number[0] = Random.Range(0, 3);
        }
        else
        {
            number[0] = Random.Range(3, 10);
        }
        number[1] = Random.Range(1, 10);
        number[2] = Random.Range(1, 10);
        showTextNumber();
    }

    string s = "";

    void showTextNumber()
    {
        if (count > 20)
        {
            play = false;
        }
        for (int i = 0; i < 3; i++)
        {
            txtNumber[i].text = "" + number[i];
            if (!play)
            {
                s += number[i].ToString();
            } 
        }
        if (!play)
        {
            btnWatchVideo.SetActive(true);
            btnBack.SetActive(true);
            Manager.Instance.UpdateCOIN(int.Parse(s));
        }
    }

    public void showADS()
    {
        btnWatchVideo.SetActive(false);
        btnBack.SetActive(false);
        // show unity ADS
        AllInOne.Instance.showUnityAds();
    }

    public void StartAnim()
    {
        play = true;
        count = 0;
        s = "";
    }
}
