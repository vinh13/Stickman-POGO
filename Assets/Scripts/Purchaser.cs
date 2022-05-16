using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager,
// one of the existing Survival Shooter scripts.
//namespace CompleteProject
//{
// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
{

    public static Purchaser Instance;
    private static IStoreController m_StoreController;
    // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider;
    // The store-specific Purchasing subsystems.


    public static string PRODUCT_1_COIN = "tungstickmanahihi1";
    public static string PRODUCT_2_COIN = "tungstickmanahihi2";
    public static string PRODUCT_5_COIN = "tungstickmanahihi5";
    public static string PRODUCT_10_COIN = "tungstickmanahihi10";
    public static string PRODUCT_20_COIN = "tungstickmanahihi20";
    public static string PRODUCT_50_COIN = "tungstickmanahihi50";





    void Start()
    {		
        if (m_StoreController == null)
        {			
            InitializePurchasing();
        }
        if (Instance == null)
        {
            Instance = this;
        }
//		if (IsInitialized ())
//			CheckRemoveAds (PRODUCT_1_COIN);
			
    }

    //	public void CheckRemoveAds (string productId)
    //	{
    //		Product product = m_StoreController.products.WithID (productId);
    //		if (product != null && product.hasReceipt) {
    //			// Owned Non Consumables and Subscriptions should always have receipts.
    //			// So here the Non Consumable product has already been bought.
    //			RemoveAds ();
    //		}
    //
    //	}
    //
    //	public void RemoveAds ()
    //	{
    //
    //	}

    public void InitializePurchasing()
    {		
        if (IsInitialized())
        {			
            return;
        }
			

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(PRODUCT_1_COIN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_2_COIN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5_COIN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_10_COIN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_20_COIN, ProductType.Consumable);
        builder.AddProduct(PRODUCT_50_COIN, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {		
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void Buy1Coins()
    {
        BuyProductID(PRODUCT_1_COIN);
    }

    public void Buy2Coins()
    {		
        BuyProductID(PRODUCT_2_COIN);
    }

    public void Buy5Coins()
    {		
        BuyProductID(PRODUCT_5_COIN);
    }

    public void Buy10Coins()
    {		
        BuyProductID(PRODUCT_10_COIN);
    }

    public void Buy20Coins()
    {		
        BuyProductID(PRODUCT_20_COIN);
    }

    public void Buy50Coins()
    {		
        BuyProductID(PRODUCT_50_COIN);
    }


    void BuyProductID(string productId)
    {		
        if (IsInitialized())
        {						
            Product product = m_StoreController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {				
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {		
        if (!IsInitialized())
        {			
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }
			
        if (Application.platform == RuntimePlatform.IPhonePlayer
        || Application.platform == RuntimePlatform.OSXPlayer)
        {			
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
                {				
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
        }
        else
        {			
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }
    //
    // --- IStoreListener
    //
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {		
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {		
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // A consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1_COIN, StringComparison.Ordinal))
        {
            //		ShopCoinButton.Instance.UpdateCoin (100);
            InAppManager.Instance.AddCoin(0);
        }
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2_COIN, StringComparison.Ordinal))
        {
            //		ShopCoinButton.Instance.UpdateCoin (500);
            InAppManager.Instance.AddCoin(1);
        }
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5_COIN, StringComparison.Ordinal))
        {
            //		ShopCoinButton.Instance.UpdateCoin (1500);
            InAppManager.Instance.AddCoin(2);
        }
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_10_COIN, StringComparison.Ordinal))
        {
            //		ShopCoinButton.Instance.UpdateCoin (5000);
            InAppManager.Instance.AddCoin(3);
        }
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_20_COIN, StringComparison.Ordinal))
        {
            //		ShopCoinButton.Instance.UpdateCoin (15000);
            InAppManager.Instance.AddCoin(4);
        }
        // A non-consumable product has been purchased by this user.
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_50_COIN, StringComparison.Ordinal))
        {			
            //	PlayerPrefs.SetInt ("Noads", 1);
            //	AdsManager.Instance.HideBanner ();
            InAppManager.Instance.AddCoin(5);
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
//}
