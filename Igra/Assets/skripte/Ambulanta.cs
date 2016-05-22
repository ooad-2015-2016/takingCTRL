using UnityEngine;
using System.Collections;

public class Ambulanta : Auto {

    public AudioClip sirena;


    // Use this for initialization
    override protected void Start () {
        base.Start();
        brzina = base.brzina * 1.5f;
        Smjer = 'l';
        InvokeRepeating("promijeni_smjer", 0.5f, 0.5f);
        base.vjerovatnoca = 0.9983f;
        //GetComponent<AudioSource>().PlayOneShot(sirena);
        //Postavi();
    }

    private void promijeni_smjer()
    {
        if (Smjer == 'l')
            Smjer = 'r';
        else Smjer = 'l';
    }
	
	// Update is called once per frame
	protected override void Update () {
        StrategijaKretanja.KreciSe(this);

        Debug.Log(string.Format("up je: {0} a trenutno: {1}", upConstraint, transform.position.y));
    }

    public override void Postavi()
    {
        float ofs = Random.Range(leftConstraint, rightConstraint);
        koristena_brzina = brzina;

        transform.position = new Vector3(ofs, downConstraint - 5, -5);
        GetComponent<AudioSource>().PlayOneShot(sirena);
    }

    public override bool Gotov()
    {
        return transform.position.y > upConstraint;
    }

    public override void Ubrzaj()
    {
        brzina += 0.1f;
    }
}
