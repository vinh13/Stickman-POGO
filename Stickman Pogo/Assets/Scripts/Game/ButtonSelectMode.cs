using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectMode : MonoBehaviour
{
    public string MODENAME;
    public int PRICE;
    bool unlocked = false;
    [SerializeField]GameObject panelBlock, panelActive;
    int indexMode;
    public bool disabled = false;
    [SerializeField]Text txtName, txtInfo;
    MODE modeFormat;

    public void Setup(MODE _mode, int id)
    {

        modeFormat = _mode;

        indexMode = id;
        MODENAME = _mode.Name;
        PRICE = _mode.PriceUnlock;

        txtName.text = "" + MODENAME;

        disabled = _mode.disable;

        if (disabled)
        {
            GetComponent<Button>().enabled = false;
        }


        if (PRICE == 0)
        {
            unlocked = true;
        }
        else
        {
            unlocked = PlayerPrefs.GetInt(MODENAME + "unlocked") == 0 ? false : true;
        }
        panelBlock.SetActive(!unlocked);
        panelActive.SetActive(unlocked);


    }

    public int GetTotalScore()
    {

        int totalScore = 0;
        if (!unlocked)
        {
            totalScore = 0;
        }
        else
        {
            for (int i = 0; i < modeFormat.NumberLevel; i++)
            {
                string temp = MODENAME + "" + (i + 1);
                totalScore += PlayerPrefs.GetInt(temp + "bestscore");
            }
        }

        txtInfo.text = "SCORE: " + totalScore;

        return totalScore;
    }

    public void OnClickButton()
    {
        //SoundAndMusicPower.Instance.PlayClipClick ();

        SOUND_SYSTEM.Instance.OnClick();

        ModeManager.Instance.OnSlectMode(indexMode);

        if (unlocked)
        {
            // Load Map
            //	SelectModeManager.Instance.OnSelectMode (indexMode);
        }
        else
        {
            //if (!CoinManager.Instance.CheckBeforeBuy (PRICE)) {
            // Not enoughCoin;
            //	CoinManager.Instance.showNotEnoughCoin ();
            //} else {


            unlocked = true;
            panelBlock.SetActive(false);
            PlayerPrefs.SetInt(MODENAME + "unlocked", 1);
            PlayerPrefs.SetInt(MODENAME + "1unlocked", 1);
            PlayerPrefs.Save();
            //	CoinManager.Instance.MinnusCoin (PRICE);
        }

    }
}
