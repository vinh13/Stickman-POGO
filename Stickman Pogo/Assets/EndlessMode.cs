using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TungDz;

public class EndlessMode : MonoBehaviour
{
    public static EndlessMode Instance;

    public PartMapEndless[] parts;
    public Transform target;
    float rangeXMap = 40;
    int curIndexMap = 0;
    float valueTemp = 0;
    public CameraControl cameraControl;
    public CreatePlayer createPlayer;
    public int priceContinue;
    int countContinue = 0;
    int priceTemp = 0;

    public Text textPrice = null;
    public Text textLevel = null;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        textLevel.text = "====[]========>";
    }

    public void GetPriceContinue()
    {
        countContinue++;
        priceTemp = priceContinue + (int)((countContinue - 1F) * (priceContinue / 2F));
        textPrice.text = "-" + priceTemp;
    }

    public bool GetContinue()
    {
        if (Manager.Instance.CheckBuy(priceTemp))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {

        this.RegisterListener(EventID.EndlessContinue, (param) => OnContinue());

        StartCoroutine(delayCheck());

        for (int i = 1; i < parts.Length; i++)
        {
            parts[i].Off();
        }

    }

    IEnumerator delayCheck()
    {
        yield return new WaitForSeconds(0.25F);
        Check();
    }

    void Check()
    {
        float x = target.position.x;
        valueTemp = x / rangeXMap;
        curIndexMap = Mathf.RoundToInt(valueTemp);
        if (curIndexMap > 0)
        {
            parts[curIndexMap - 1].Check(x);
            parts[curIndexMap].Check(x);
            if (curIndexMap + 1 < parts.Length)
            {
                parts[curIndexMap + 1].Check(x);
            }
        }
        StartCoroutine(delayCheck());
    }

    public void ClickContinue()
    {
        StartCoroutine(delayContinue());
    }

    IEnumerator delayContinue()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Logic.UNPAUSE();
        createPlayer._CreatePlayer(parts[curIndexMap].checkPoint.position);
        yield return new WaitForEndOfFrame();
        cameraControl.Restore();
        Logic.IsEnd = false;
    }

    void OnContinue()
    {
        ClickContinue();
    }
}
