using UnityEngine;
using System.Collections;

public class Ambulanta : Auto {



    char smjer;

    // Use this for initialization
    override protected void Start () {
        base.Start();
        brzina = base.brzina * 1.5f;
        char smjer = 'l';
        InvokeRepeating("promijeni_smjer", 0.5f, 0.5f);
        base.vjerovatnoca = 0.9983f;
	}

    private void promijeni_smjer()
    {
        if (smjer == 'l')
            smjer = 'r';
        else smjer = 'l';
    }
	
	// Update is called once per frame
	protected override void Update () {
        transform.Translate(Vector2.up * Time.deltaTime * koristena_brzina);
        if (smjer == 'l')
            transform.Translate(Vector2.left * Time.deltaTime);
        else
            transform.Translate(Vector2.right * Time.deltaTime * 2);

        Debug.Log(string.Format("up je: {0} a trenutno: {1}", upConstraint, transform.position.y));
    }

    public override void Postavi()
    {
        float ofs = Random.Range(leftConstraint, rightConstraint);
        koristena_brzina = brzina;

        transform.position = new Vector3(ofs, downConstraint, -5);
    }

    public override bool Gotov()
    {
        return transform.position.y > upConstraint;
        
    }
}
