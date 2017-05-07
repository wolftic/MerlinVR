using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    [SerializeField]
    private float _maxMana;

    private float _mana;

    public static Player Instance;

    public void AddMana(float mp)
    {
        _mana += mp;
        Mathf.Clamp(_mana, 0, _maxMana);
    }

    public void RemoveMana(float mp)
    {
        _mana -= mp;
        Mathf.Clamp(_mana, 0, _maxMana);
    }

	private void Awake ()
	{
	    Instance = this;
	}

    private void Update () {

	}
}
