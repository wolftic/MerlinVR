using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Blink : Spell {
    private Transform rightHand;

    private Valve.VR.InteractionSystem.Player _player;

    public override void Activate()
    {
        Debug.Log(_player);
        rightHand = (_player.rightHand == null) ? transform.FindChild("NoSteamVRFallbackObjects").FindChild("FallbackObjects").FindChild("FallBackHandController") : _player.rightHand.transform;

        RaycastHit hit;

        if (Physics.Raycast(rightHand.position, rightHand.forward, out hit, 100.0f))
        {
            Player.Instance.transform.position = hit.point;
        }
    }

    public override void Init()
    {
        _player = Valve.VR.InteractionSystem.Player.instance;
    }
}
