using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Blink : Spell {
    private Hand rightHand;
    public override void Activate()
    {
        rightHand.GetComponent<AllowTeleportWhileAttachedToHand>().teleportAllowed = false;
    }

    public override void Init()
    {
        rightHand = Valve.VR.InteractionSystem.Player.instance.rightHand;
        rightHand.GetComponent<AllowTeleportWhileAttachedToHand>().teleportAllowed = true;
    }
}
