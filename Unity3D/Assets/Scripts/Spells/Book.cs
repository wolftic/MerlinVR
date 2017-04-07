using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    private Player _player;
    private Spell _spellSelected;
    private Spell[] _spells;

    public void SetSpell(int i)
    {
        var spell = _spells[i];
        _spellSelected = spell;
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