using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class ScrollViewController : MonoBehaviour {

    public GameObject scrollPrefab;
    public ARSceneController arSceneController;
    public Transform scrollParent;
    public ArrayList al = new ArrayList();

	void Awake () {
        if(!arSceneController)
            arSceneController = GameObject.FindObjectOfType<ARSceneController>();
    }

    public void OnEnable()
    {
      //  CreateCart();
    }

    public void OnDisable()
    {
        foreach (GameObject go in al)
            Destroy(go);
        al.Clear();
    }

    public void CreateCart()
    {
        al.Clear();
        scrollPrefab.gameObject.SetActive(false);
        for (int i = 0,len = arSceneController.prodDetailList.Count; i < len ; i++)
        {
            GameObject scrollItem = Instantiate(scrollPrefab) as GameObject;
            ScrollItem si = scrollItem.GetComponent<ScrollItem>();
            // Fix the scaling issue
            scrollItem.SetActive(true);
            scrollItem.transform.SetParent(scrollParent);
            si.GetComponent<RectTransform>().localScale = Vector3.one;
            si.cost.text = arSceneController.prodDetailList[i].productCost;
            si.product.text = arSceneController.prodDetailList[i].productName;
            
            al.Add(si.gameObject);
        }

    }

    public void DeleteItem(string productName)
    {
        if (arSceneController.prodDetailList == null)
            return;

        for (int i = 0, len = arSceneController.prodDetailList.Count; i < len; i++)
        {
           if(arSceneController.prodDetailList[i].productName == productName)
            {
                arSceneController.prodDetailList.Remove(arSceneController.prodDetailList[i]);
                return;
            }
        }
    }

}
