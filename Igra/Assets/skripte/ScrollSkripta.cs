using UnityEngine;
using System.Collections;

public class ScrollSkripta : MonoBehaviour {

    public float brzina = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(0, Time.time * brzina);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
