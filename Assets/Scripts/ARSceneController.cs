using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ARSceneController : MonoBehaviour {

    [Header("scan Screen")]
    public GameObject scanItemScreen;

    [Header("item info")]
    public GameObject itemInfo;
    public GameObject infoElems;
    public GameObject successAddCart;

    [Header("Show Cart")]
    public GameObject showCart;


    [Header("payment")]
    public GameObject payment;
    public Text payAmount;
    public GameObject payView;
    public GameObject successMessage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //scan Screen
    public void OnScanScreenViewCartClicked()
    {
        showCart.SetActive(true);
        scanItemScreen.SetActive(false);
    }
    public void OnScanScreenFinishShoppingClicked()
    {
        scanItemScreen.SetActive(false);
        itemInfo.SetActive(true);
    }

    //itemInfo
    public void OnItemInfoCancelClicked()
    {
        scanItemScreen.SetActive(true);
        infoElems.SetActive(true);
        itemInfo.SetActive(false);
    }
    public void OnItemInfoAddToCartClicked()
    {
        infoElems.SetActive(false);
        successAddCart.SetActive(true);
    }
    public void OnItemInfoFinishShoppingClicked()
    {
        itemInfo.SetActive(false);
        showCart.SetActive(true);
    }
    public void OnItemInfoSuccessAddClicked()
    {
        successAddCart.SetActive(false);
        infoElems.SetActive(true);
        itemInfo.SetActive(false);
        scanItemScreen.SetActive(true);
    }

    //Show Cart
    public void OnShowCartGoBackClicked()
    {
        scanItemScreen.SetActive(true);
        showCart.SetActive(false);
    }
    public void OnShowCartCheckoutClicked()
    {
        showCart.SetActive(false);

        payView.SetActive(true);
        payment.SetActive(true);
    }


    // Payment 
    public void OnPayClicked()
    {
        successMessage.SetActive(true);
        payView.SetActive(false);
    }
    public void OnPayCancelClicked()
    {
        successMessage.SetActive(false);
        payView.SetActive(true);
        payment.SetActive(false);
        scanItemScreen.SetActive(true);
    }
    public void OnSuccessOkClicked()
    {
        successMessage.SetActive(false);
        payView.SetActive(true);
        payment.SetActive(false);
        scanItemScreen.SetActive(true);
    }
}
