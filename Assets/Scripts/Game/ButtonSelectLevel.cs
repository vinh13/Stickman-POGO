using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectLevel : MonoBehaviour
{
    public string LEVELNAME;
    public int PRICE;
    [SerializeField]AnimatorPopUpScript panelBlock;
    public GameObject panelActive;

    [SerializeField]Text textTitle, textPrice, textBestScore;
    float bestScore = 0;
    public int indexLevel;

    bool unlocked = false;

    public void Setup(LEVEL _LEVEL, int _indexLevel, bool actived)
    {
        gameObject.SetActive(actived);
        if (!actived)
            return;
        
        indexLevel = _indexLevel + 1;

        LEVELNAME = _LEVEL.Name + "" + indexLevel;
        PRICE = _LEVEL.Price;


        textTitle.text = "" + indexLevel;
        textPrice.text = "" + PRICE;

        if (PRICE == 0)
        {
            unlocked = true;
        }
        else
        {
            unlocked = (PlayerPrefs.GetInt(LEVELNAME + "unlocked") == 0) ? false : true;
        }
        if (unlocked)
        {
            bestScore = PlayerPrefs.GetInt(LEVELNAME + "bestscore");
        }
        panelBlock.gameObject.SetActive(!unlocked);
        panelActive.SetActive(unlocked);


        textBestScore.text = "Best: " + bestScore;
    }

    public void OnClickButton()
    {
        SOUND_SYSTEM.Instance.OnClick();

        if (unlocked)
        {
            Logic.IdLevel = indexLevel;
            ModeManager.Instance.OnSlectLevel();
        }
        else
        {
            if (Manager.Instance.CheckBuy(PRICE))
            {
                unlocked = true;
                bestScore = PlayerPrefs.GetInt(LEVELNAME + "bestscore");

                panelBlock.gameObject.SetActive(!unlocked);
                panelActive.SetActive(unlocked);

                textBestScore.text = "Best: " + bestScore;

                PlayerPrefs.SetInt(LEVELNAME + "unlocked", 1);
                PlayerPrefs.Save();
            }
        }
    }
    //	SoundAndMusicPower.Instance.PlayClipClick ();
    //
    //		if (unlocked) {
    //			// Load Map
    //			SelectLevelManager.Instance.loadLevel (indexLevel);
    //		} else {
    //			if (!CoinManager.Instance.CheckBeforeBuy (PRICE)) {
    //				// Not enoughCoin;
    //				CoinManager.Instance.showNotEnoughCoin ();
    //			} else {
    //				unlocked = true;
    //				panelBlock.show ();
    //				stars.enabled = unlocked;
    //				fillingStar = true;
    //				StartFill ();
    //				PlayerPrefs.SetInt (LEVELNAME + "unlocked", 1);
    //				CoinManager.Instance.MinnusCoin (PRICE);
    //			}
    //
    //		}
}
