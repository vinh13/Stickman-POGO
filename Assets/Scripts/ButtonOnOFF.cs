using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnOFF : MonoBehaviour
{
    [SerializeField]Image img;
    public string keyOptions;
    //	bool filling = false;
    //	int direction = 1;
    bool isOn = false;
    public Sprite[] sprs;

    void Awake()
    {
        isOn = (PlayerPrefs.GetInt(keyOptions, 1) == 1) ? true : false;
        int index = (isOn) ? 1 : 0;
        img.sprite = sprs[index];
    }

    void Start()
    {
        SOUND_SYSTEM.isSOUND = isOn;
        SOUND_SYSTEM.Instance.MUSIC();

    }

    public void Static()
    {
        isOn = !isOn;
        int index = (isOn) ? 1 : 0;
        img.sprite = sprs[index];
        //	direction = (isOn) ? 1 : -1;
        //	filling = true;
        //	img.fillAmount = index;
        PlayerPrefs.SetInt(keyOptions, (isOn) ? 1 : 0);
        //	SoundAndMusicPower.Instance.UpdateStatic ();

        SOUND_SYSTEM.isSOUND = isOn;
        SOUND_SYSTEM.Instance.MUSIC();
    }

    void Update()
    {
//		if (!filling)
//			return;
//		img.fillAmount += direction * 0.1f;
//		if (direction == 1) {
//			if (img.fillAmount >= 1) {
//				filling = false;
//				return;
//			}
//		} else {
//			if (img.fillAmount <= 0) {
//				filling = false;
//				return;
//			}
//		}

    }

    public void OnPressButton()
    {
//		if (filling)
//			return;
        Static();
    }
}
