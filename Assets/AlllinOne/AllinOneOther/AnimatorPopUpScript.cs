using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatorPopUpScript : MonoBehaviour
{
    [SerializeField]Animator anim;
    [SerializeField]GameObject goMain;
    //	Image imgbg;

    void Awake()
    {
        anim.enabled = false;
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
//		if (transform.childCount == 0)
//			return;
        //	imgbg = transform.GetChild (0).GetComponent<Image> ();
    }

    // FixAnim 2017

    void Update()
    {
        if (Time.timeScale < 1F)
        {
            anim.Update(Time.unscaledDeltaTime);
        }
        else
        {
            return;
        }
    }


    public void show(bool isShowPanel = true)
    {
        gameObject.SetActive(true);
        anim.enabled = true;
        anim.Rebind();
    }

    public void showII()
    {
        anim.enabled = true;
        anim.Rebind();
        anim.SetTrigger("showII");
    }

    IEnumerator delayDisableAnim()
    {
        yield return new WaitForEndOfFrame();
        anim.enabled = false;
    }

    public void hide()
    {
        if (gameObject.activeSelf)
        {
            anim.enabled = true;
            anim.Rebind();
            anim.SetTrigger("hide");
        }
    }

    public void hideII()
    {
        anim.enabled = true;
        anim.Rebind();
        anim.SetTrigger("hideII");
    }

    public void disableAnim()
    {
        if (!this.gameObject.activeInHierarchy)
            return;
        StartCoroutine(delayDisableAnim());
    }

    public void PlayAimTrigger(string trigger)
    {
        anim.enabled = true;
        anim.Rebind();
        anim.SetTrigger(trigger);
    }

    public void disablePanel()
    {
        goMain.SetActive(false);
    }

    public void disableAnimManual(bool state)
    {
        anim.enabled = state;
    }
}
