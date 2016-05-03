using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu_Dugmad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void Pokreni()
    {
        SceneManager.LoadScene("GlavnaScena");
    }
}
