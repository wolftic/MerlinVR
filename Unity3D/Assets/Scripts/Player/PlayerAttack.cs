using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerAttack : MonoBehaviour {
    private Book _book;
    private Valve.VR.InteractionSystem.Player _player;

    private void Awake()
    {
        _book = GameObject.FindObjectOfType<Book>();
        _player = Valve.VR.InteractionSystem.Player.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (_player.leftController == null || _player.rightController == null) return;
        if (_player.rightController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || Input.GetMouseButtonDown(0))//if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        var position = (_player.rightHand == null) ? transform.position : _player.rightHand.transform.position;
        var rotation = (_player.rightHand == null) ? transform.rotation : _player.rightHand.transform.rotation;

        var spell = _book.GetCurrentSpell();
        var obj = Instantiate(spell);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.GetComponent<Spell>().Activate();
    }
}
