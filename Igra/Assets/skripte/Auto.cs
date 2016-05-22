using UnityEngine;
using System.Collections;

public interface IStrategijaKretanja
{
    void KreciSe(Auto a);
}

public class CikCakKretanje : IStrategijaKretanja
{
    public void KreciSe(Auto a)
    {
        
        a.transform.Translate(Vector2.up * Time.deltaTime * a.koristena_brzina);
        if (a.Smjer == 'l')
            a.transform.Translate(Vector2.left * Time.deltaTime * 2);
        else
            a.transform.Translate(Vector2.right * Time.deltaTime * 2);
    }
}

public class PravolinijskoKretanje : IStrategijaKretanja
{
    public void KreciSe(Auto a)
    {
        a.transform.Translate(Vector2.down * Time.deltaTime * a.koristena_brzina);
    }
}

public abstract class Auto : MonoBehaviour {

    protected float brzina = 4.0f;
    public float koristena_brzina = 4.0f;
    protected float leftConstraint;
    protected float rightConstraint;
    protected float upConstraint;
    protected float downConstraint;
    
    public char Smjer;
    public IStrategijaKretanja StrategijaKretanja;

    public float vjerovatnoca;


    // Use this for initialization
    protected virtual void Start () {
        Smjer = 'c';
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.0f, 0.0f, 0.0f)).x + 1;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.0f, 0.0f, 0.0f)).x + 1;
        downConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 0.0f, 0.0f)).y;
        upConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 1.0f, 0.0f)).y + 2;
        //Postavi();
        
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        StrategijaKretanja.KreciSe(this);
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
    public abstract void Ubrzaj();
}
