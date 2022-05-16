using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpineGif : MonoBehaviour
{
    public RectTransform rectArrow, checkPoint;
    public float speed = 0, speedMin = -720, speedAdd = -6000;
    bool playing = false;
    public float angleZ_late = 0;
    public float speedPerDeltatime = 5F;
    public float speedTEST = -360;
    public GifScript[] gifs;
    public int IDGIF = 0;

    public Text textStatus = null;
    public Image progressBar;
    public float fillAmoutValue_spine = 0;

    public bool inHold = false;

    public float timeHoldMax = 1F;
    int direcionHold = 1;

    public int priceSpine = 500;

    public static bool freeSpine = false;

    void Start()
    {
        freeSpine = true;

        angleZ_late = PlayerPrefs.GetFloat("angleZ_late", 0);
        rectArrow.localRotation = Quaternion.AngleAxis(angleZ_late, Vector3.forward);
        fillAmoutValue_spine = PlayerPrefs.GetFloat("fillAmoutValue_spine", 0);
        progressBar.fillAmount = fillAmoutValue_spine;
        CheckStatus();
    }

    public void CheckStatus()
    {
        if (freeSpine)
        {
            textStatus.text = "Spine Free";
        }
        else
        {
            textStatus.text = "Spine " + priceSpine + " Coin";
        }
    }

    public void Play(float temp)
    {
        if (playing)
            return;
        playing = true;
        speed = temp;
    }

    void Update()
    {
        if (inHold)
        {
            timerHold += direcionHold * Time.unscaledDeltaTime;
            if (timerHold >= timeHoldMax)
            {
                direcionHold = -1;
                timerHold = timeHoldMax;
            }
            if (timerHold <= 0)
            {
                direcionHold = 1;
                timerHold = 0;
            }
            fillAmoutValue_spine = timerHold / timeHoldMax;
            progressBar.fillAmount = fillAmoutValue_spine;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Play(speedTEST);
        }

        if (!playing)
            return;
        if (speed < 0)
        {
            speed += speedPerDeltatime;
        }
        else
        {
            speed = 0;
            playing = false;
            OnEndSpine();
        }
        rectArrow.Rotate(Vector3.forward * speed * Time.unscaledDeltaTime);
    }

    public void OnEndSpine()
    {
        angleZ_late = Quaternion.ToEulerAngles(rectArrow.localRotation).z * Mathf.Rad2Deg;
        PlayerPrefs.SetFloat("angleZ_late", angleZ_late);
        IDGIF = idGif();
    }

    public int idGif()
    {
        int id = 0;
        float distanceMin = Vector3.Distance(checkPoint.position, gifs[0].checkPoint.position);
        for (int i = 1; i < gifs.Length; i++)
        {
            float distance = Vector3.Distance(checkPoint.position, gifs[i].checkPoint.position);
            if (distance <= distanceMin)
            {
                distanceMin = distance;
                id = i;
            }
        }
        return id;
    }

    float timerHold = 0;

    public void OnHoldButtonSpine()
    {
        if (inHold)
            return;
        if (freeSpine)
        {
            freeSpine = false;
        }
        else
        {
            if (!Manager.Instance.CheckBuy(priceSpine))
            {
                return;
            }
        }


        // spam
        direcionHold = 1;
        inHold = true;
        timerHold = 0;
    }

    public void EndHoldButtonSpine()
    {
        if (!inHold)
            return;
        inHold = false;
        fillAmoutValue_spine = Mathf.Clamp(timerHold, 0, timeHoldMax) / timeHoldMax;
        progressBar.fillAmount = fillAmoutValue_spine;

        PlayerPrefs.SetFloat("fillAmoutValue_spine", fillAmoutValue_spine);
        Play(speedMin + (speedAdd * fillAmoutValue_spine));

        CheckStatus();
    }

}
