using UnityEngine;
using System.Collections;
using System;

public class ObicnoAuto : Auto {

    /*public override void Ubrzaj()
    {
        brzina += 0.1f;
    }*/

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
