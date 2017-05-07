using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Blink : Spell {
    private Hand rightHand;

    private Valve.VR.InteractionSystem.Player _player;

    public override void Activate()
    {
        rightHand = Valve.VR.InteractionSystem.Player.instance.rightHand;

        RaycastHit hit;

        if (Physics.Raycast(rightHand.transform.position, rightHand.transform.forward, out hit, 100.0f))
        {
            Player.Instance.transform.position = hit.point;
        }
    }

    public override void Init()
    {

    }
}
