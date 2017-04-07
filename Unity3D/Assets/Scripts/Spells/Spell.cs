using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected float speed, damage;

    public abstract void Activate();
    public abstract void Init();
}
