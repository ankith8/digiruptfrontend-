using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject searchDisabled;

    void Start()
    {
        searchDisabled.SetActive(false);
    }

	public void GoShoppingClick () {
        SceneManager.LoadScene("AR");
	}

    public void SearchLocationClick ()
    {
        searchDisabled.SetActive(true);
    }

    public void SearchOkClick ()
    {
        searchDisabled.SetActive(false);
    }

}
