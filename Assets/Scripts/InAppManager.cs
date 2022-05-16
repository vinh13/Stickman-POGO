using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InAppManager : MonoBehaviour
{
    public static InAppManager Instance;
    public ButtonGetCoinInApp[] btns;
    [Header("Coin get $$$$$$$$$$$$$$$$$$$$$$$$$")]
    public int[] coinsGet;
    [Header("Prices $$$$$$$$$$$$$$$$$$$$$$$$$$")]
    public float[] prices;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].Setup(coinsGet[i], prices[i], this, i);
        }
    }

    public void ClickGetCoin(int index)
    {
        // PurchaserIndex
        switch (index)
        {
            case 0:
                Purchaser.Instance.Buy1Coins();
                break;
            case 1:
                Purchaser.Instance.Buy2Coins();
                break;
            case 2:
                Purchaser.Instance.Buy5Coins();
                break;
            case 3:
                Purchaser.Instance.Buy10Coins();
                break;
            case 4:
                Purchaser.Instance.Buy20Coins();
                break;
            case 5:
                Purchaser.Instance.Buy50Coins();
                break;
        }
    }

    public void AddCoin(int index)
    {
        Manager.Instance.UpdateCOIN(coinsGet[index]);
    }
}
