using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PauzaSkripta : MonoBehaviour {

    //public GameObject Canvas;
    //public GameObject Camera;
    bool Pauzirano = false;
    bool Zavrseno = false;
    

    void Start()
    {
        //Canvas.gameObject.SetActive(false);
        Debug.Log("pokrenuta glavna scena");
        Time.timeScale = 1.0f;
        Pauzirano = false;
        Zavrseno = false;

    }

    public void Kraj()
    {
        Time.timeScale = 0.0f;
        Zavrseno = true;
    }


    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Pauzirano)
            {
                SceneManager.LoadScene("mainmenu");
                Pauzirano = false;
                Debug.Log("kraj glavne scene");
            }
            else
            {
                Time.timeScale = 0.0f;
                //Canvas.gameObject.SetActive(true);
                //GetComponent<AudioSource>().Pause();
                Pauzirano = true;
                Debug.Log("pauzirano");

            }
        }
        else if (Input.GetKeyDown("return") && Pauzirano)
        {
            Time.timeScale = 1.0f;
            //Canvas.gameObject.SetActive(false);
            //GetComponent<AudioSource>().Play();
            Pauzirano = false;
            Debug.Log("nastavljeno");
        }

        if (Zavrseno && Input.anyKeyDown)
            SceneManager.LoadScene("mainmenu");


    }

    void OnGUI()
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;

        if (Pauzirano)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 150, 150), "<color=red><size=30>pauzirano</size></color>\n<size=15>ESC za izlaz, enter za nastavak</size>");

        if (Zavrseno)
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 250, 150), "<color=red><size=30>Izgubili ste.</size>\n<size=15>Pritisnite bilo koju tipku za nastavak</size></color>");
    }
}
