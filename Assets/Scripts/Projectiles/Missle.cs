using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Projectile
{
    public void Explode()
    {
    }

    public void OnCollisionEnter(Collision other)
    {
        Explode();
    }
}
