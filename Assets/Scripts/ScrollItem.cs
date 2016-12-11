using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollItem : MonoBehaviour {

    public Text product;
    public Text quantity;
    public Text cost;

    public void IncreaseCount()
    {
        // increase the count of the product
    }

    public void DecreaseCount()
    {
        // deccrease the count of the product
    }

    public void DeleteItem()
    {
        ScrollViewController svc = GameObject.FindObjectOfType<ScrollViewController>();
        svc.DeleteItem(product.text);
        Destroy(this.gameObject);
        // delete this product
    }
}
