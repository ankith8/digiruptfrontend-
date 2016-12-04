using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadMenuScene", 3);
	}
	
    void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
