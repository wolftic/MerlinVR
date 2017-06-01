using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private Spell _spellSelected;

    [SerializeField]
    private Spell[] _spells;

    public static Book Instance;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _spellSelected.Init();
        Instance = this;
    }

    public void SetSpell(int i)
    {
        var spell = _spells[i];
        _spellSelected = spell;
        _spellSelected.Init();
    }

    public Spell GetCurrentSpell()
    {
        return _spellSelected;
    }
}

public enum SpellType
{
    Fireball,
    Thunder,
    Teleport
}