using UnityEngine;
using System.Collections;

public abstract class Auto : MonoBehaviour {

    protected float brzina = 4.0f;
    protected float koristena_brzina = 4.0f;
    protected float leftConstraint;
    protected float rightConstraint;
    protected float upConstraint;
    protected float downConstraint;

    public float vjerovatnoca;


    // Use this for initialization
    protected virtual void Start () {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.0f, 0.0f, 0.0f)).x + 1;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.0f, 0.0f, 0.0f)).x + 1;
        downConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 0.0f, 0.0f)).y;
        upConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 1.0f, 0.0f)).y + 2;
        //Postavi();
        
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        transform.Translate(Vector2.down * Time.deltaTime * koristena_brzina);
    }

    public virtual void Postavi()
    {
        float ofs = Random.Range(leftConstraint, rightConstraint);
        if (ofs < (leftConstraint + rightConstraint) / 2)
            koristena_brzina = brzina * 2;
        else
            koristena_brzina = brzina;

        transform.position = new Vector3(ofs, upConstraint, -5);
    }

    public abstract bool Gotov();
    //public abstract void Ubrzaj();
}
