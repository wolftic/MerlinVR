using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerAttack : MonoBehaviour {
    private Book _book;
    private Valve.VR.InteractionSystem.Player _player;
    private Player _playerOwn;

    private float _lastShot;

    [SerializeField]
    private float _cooldown;

    private void Start()
    {
        _book = Book.Instance;
        _player = Valve.VR.InteractionSystem.Player.instance;
        _playerOwn = GetComponent<Player>();
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
        if (_lastShot > Time.time) return;

        var hand = (_player.rightHand == null) ? transform.FindChild("NoSteamVRFallbackObjects").FindChild("FallbackObjects").FindChild("FallBackHandController") : _player.rightHand.transform;

        if (_book == null) _book = Book.Instance;

        var spell = _book.GetCurrentSpell();
        var obj = Instantiate(spell);

        _playerOwn.RemoveMana(20);

        obj.transform.position = hand.position;
        obj.transform.rotation = hand.rotation;
        obj.GetComponent<Spell>().Activate();

        Destroy(obj.gameObject, 10f);

        _lastShot = Time.time + _cooldown;
    }
}
