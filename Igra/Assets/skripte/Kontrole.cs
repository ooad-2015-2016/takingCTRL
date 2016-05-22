using UnityEngine;
using System.Collections;

public class Kontrole : MonoBehaviour {
    float brzina_skretanja_h = 5.0f;
    float brzina_skretanja_v = 2.5f;
    float leftConstraint;
    float rightConstraint;
    float upConstraint;
    float downConstraint;
    int bodovi = 0;
    int nivo = 1;
    public Auto ob_auto;
    public Novcic novcic;
    public Ambulanta ambulanta;
    bool postoji_novcic;
    bool prekid_novcica;

    public AudioClip levelUpZvuk;
    public AudioClip poenZvuk;
    public AudioClip sudarZvuk;
    public AudioClip udaracZvuk;

    AudioSource audio_s;

    AutoFactory autoFactory;

    ArrayList auta = new ArrayList();

    // Use this for initialization
    void Start () {
        prekid_novcica = false;
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.0f, 0.0f, 0.0f)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.0f, 0.0f, 0.0f)).x;
        downConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 0.0f, 0.0f)).y;
        upConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 1.0f, 0.0f)).y;
        transform.position = new Vector2(Screen.width / 2, Screen.height * 0.494f);
        postoji_novcic = false;

        audio_s = GetComponent<AudioSource>();

        autoFactory = new AutoFactory();
        autoFactory.ob_auto = ob_auto;
        autoFactory.amb = ambulanta;
        autoFactory.downConstraint = downConstraint;

        auta = new ArrayList();
        Invoke("DodajNovcic", 5.0f);

        while (auta.Count < nivo * 7)
        {
            Auto novo = autoFactory.generisiAuto('o');
            novo.StrategijaKretanja = new PravolinijskoKretanje();
            auta.Add(novo);
        }

        Physics.IgnoreLayerCollision(9, 9);


        //novoAuto.transform.parent = GameObject.Find("Canvas").transform;
        //novoAuto.transform.localPosition = new Vector3(0, 1, 0);

        //Instantiate(Auto, new Vector3(0, 0, 0), Quaternion.identity);
        //auta.Add(Object.Instantiate)
    }

    void DodajNovcic()
    {
        Novcic novi = (Novcic)Instantiate(novcic, new Vector3(Random.Range(leftConstraint, rightConstraint), Random.Range(downConstraint, upConstraint), -5), Quaternion.identity);
        Invoke("BrisiNovcic", 7.5f);
        Invoke("DodajNovcic", 10.0f);
    }

    void BrisiNovcic()
    {
        Destroy(GameObject.Find("poeni(Clone)"));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftConstraint)
        {
            transform.Translate(Vector2.left * Time.deltaTime * brzina_skretanja_h);
            //Debug.Log("kliknuto lijevo; transformacija");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightConstraint)
        {
            transform.Translate(Vector2.right * Time.deltaTime * brzina_skretanja_h);
            //Debug.Log("kliknuto desno; transformacija");
        }

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < upConstraint)
        {
            transform.Translate(Vector2.up * Time.deltaTime * brzina_skretanja_v);
            //Debug.Log("kliknuto gore; transformacija");
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > downConstraint)
        {
            transform.Translate(Vector2.down * Time.deltaTime * brzina_skretanja_v);
            //Debug.Log("kliknuto dole; transformacija");
        }

        foreach (Auto a in auta)
        {
            if(a.Gotov())
            {
                if (Random.value > a.vjerovatnoca)
                    a.Postavi();
            }
        }


    }

    void OnGUI()
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperLeft;

        GUI.Label(new Rect(10, 10, 150, 150), System.String.Format("<color=red><size=15>Level: {0}\nBodovi: {1}</size></color>", nivo, bodovi));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "poeni(Clone)")
        {
            Destroy(col.gameObject);
            audio_s.PlayOneShot(poenZvuk);
            bodovi += 10;
            if (bodovi % 50 == 0)
            {
                ++nivo;
                audio_s.PlayOneShot(levelUpZvuk);
                var pozadina = GameObject.Find("pozadina").GetComponent<ScrollSkripta>().brzina += 0.1f;

                Auto novo = autoFactory.generisiAuto('o');
                novo.StrategijaKretanja = new PravolinijskoKretanje();
                auta.Add(novo);

                novo = autoFactory.generisiAuto('o');
                novo.StrategijaKretanja = new PravolinijskoKretanje();
                auta.Add(novo);

                novo = autoFactory.generisiAuto('a');
                novo.StrategijaKretanja = new CikCakKretanje();
                auta.Add(novo);
                

                foreach (Auto a in auta)
                    a.Ubrzaj();
            }

            postoji_novcic = false;

        }
        else if (col.gameObject.name == "Ambulanta(Clone)" || col.gameObject.name == "ObicnoAuto(Clone)")
        {
            if (System.Math.Abs(transform.position.x - col.transform.position.x) < 0.8f)
            {
                var log = GameObject.Find("Logika");
                audio_s.PlayOneShot(sudarZvuk);
                log.GetComponent<PauzaSkripta>().Kraj();
            }
            else
                audio_s.PlayOneShot(udaracZvuk);
        }
        
    }

    public class AutoFactory
    {
        public Auto ob_auto;
        public Ambulanta amb;

        public float downConstraint;
        
        public Auto generisiAuto(char a)
        {
            if (a == 'a')
                return (Ambulanta)Instantiate((amb), new Vector3(1000, 1000, 0), Quaternion.identity);
            else
                return (ObicnoAuto)Instantiate(ob_auto, new Vector3(0, downConstraint, 0), Quaternion.identity);

        }
    }

}
