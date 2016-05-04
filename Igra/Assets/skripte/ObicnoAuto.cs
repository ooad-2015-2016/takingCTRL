using UnityEngine;
using System.Collections;

public class ObicnoAuto : Auto {

    bool pravo;

    public override void Ubrzaj()
    {
        brzina += 0.2f;
        pravo = true;
    }

    protected override void Start()
    {
        base.Start();
        base.vjerovatnoca = 0.994f;
    }
             

    public override bool Gotov()
    {
        return transform.position.y < downConstraint;
    }
}
