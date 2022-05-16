using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]AnimatorPopUpScript uiTutorial;
    bool isTutorial = false;

    void Show()
    {
        uiTutorial.gameObject.SetActive(true);
        uiTutorial.show();
    }

    void Hide()
    {
        uiTutorial.hide();
    }

    void Start()
    {
        isTutorial = PlayerPrefs.GetInt("isTutorial", 0) == 0 ? true : false;
        if (isTutorial)
        {
            Show();
            StartCoroutine(delayShow());
        }
    }

    IEnumerator delayShow()
    {
        yield return new WaitForEndOfFrame();
        Logic.PAUSE();
    }

    public void OnClick()
    {
        Hide();
        PlayerPrefs.SetInt("isTutorial", 1);
        StartCoroutine(delayHide());
    }

    IEnumerator delayHide()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Logic.UNPAUSE();
    }
}
