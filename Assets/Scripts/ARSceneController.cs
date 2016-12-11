using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ARSceneController : MonoBehaviour {

    [Header("scan Screen")]
    public GameObject scanItemScreen;

    [Header("item info")]
    public GameObject itemInfo;
    public GameObject infoElems;
    public Text prodName;
    public Text prodDesc;
    public Text prodCost;
    public GameObject successAddCart;

    [Header("Show Cart")]
    public GameObject showCart;


    [Header("payment")]
    public GameObject payment;
    public Text payAmount;
    public GameObject payView;
    public GameObject successMessage;

   
    public class productDetails
    {
        public string productName;
        public string productCost;
        public string productDesc;

        public productDetails()
        {
            productName = "";
            productCost = "";
            productDesc = "";
        }

        public productDetails(string name,string cost,string desc)
        {
            productName = name;
            productCost = cost;
            productDesc = desc;
        }
    }
    public productDetails pd;
    public List<productDetails> prodDetailList = new List<productDetails>();
    public ScrollViewController scrollViewController;

    //scan Screen
    public void OnScanScreenViewCartClicked()
    {
        showCart.SetActive(true);
        scanItemScreen.SetActive(false);
        scrollViewController.CreateCart();
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
        prodDetailList.Add(pd);

        /*
        foreach(productDetails pds in prodDetailList)
        {
            Debug.Log("-------------" + pds.productName + "--" + pds.productDesc + "-"+pds.productCost);
        }
        */

        pd = null;
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

    // Show Item Info
    public void ShowItemInfo(string item)
    {
        print("item name = "+item);
        productDetails pd = GetItemDetails(item);
        prodName.text = pd.productName;
        prodDesc.text = pd.productDesc;
        prodCost.text = pd.productCost;

        itemInfo.SetActive(true);
        scanItemScreen.SetActive(false);

    }

    public productDetails GetItemDetails(string item)
    {
        pd = new productDetails();
        switch (item)
        {
            case "1":
                pd.productCost = "10";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "2":
                pd.productCost = "20";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "3":
                pd.productCost = "30";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "4":
                pd.productCost = "40";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "5":
                pd.productCost = "50";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "6":
                pd.productCost = "60";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "7":
                pd.productCost = "70";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "8":
                pd.productCost = "80";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "9":
                pd.productCost = "90";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            case "10":
                pd.productCost = "100";
                pd.productDesc = "A chocolate to eat";
                pd.productName = "Cadbury Dairy Milk";
                break;
            default:
                return pd;
        }
        return pd;
    }

    public void GetData()
    {
        string url = "";
        WWW www = new WWW(url);
        StartCoroutine(WaitforGetRequest(www));
    }

    IEnumerator WaitforGetRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    public void PostData()
    {
        string url = "";
        WWWForm form = new WWWForm();
        form.AddField("var1", "value1");
        form.AddField("var2", "value2");
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForPostRequest(www));
    }

    IEnumerator WaitForPostRequest(WWW www)
    {
        yield return www;

         // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}

