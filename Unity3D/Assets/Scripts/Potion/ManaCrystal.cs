using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCrystal : MonoBehaviour
{
    [SerializeField]
    private float _manaTickRate = .5f, _manaPerTick = 10f;
    private float _nextManaTick;
    private List<Player> _players = new List<Player>();

    private void Update()
    {
        if (!(_nextManaTick < Time.time)) return;
        GiveMana();
        _nextManaTick = Time.time + _manaTickRate;
    }

    private void GiveMana()
    {
        if (_players.Count == 0) return;

        foreach (var player in _players)
        {
            player.AddMana(_manaPerTick);
        }

        Debug.Log("Giving mana to " + _players.Count + " player(s).");
    }

    private void OnCollisionEnter(Collision col)
    {
        var player = col.transform.root.GetComponent<Player>();

        if (player == null) return;

        _players.Add(player);

        Debug.Log("Player touching crystal!");
    }

    private void OnCollisionExit(Collision col)
    {
        var player = col.transform.root.GetComponent<Player>();

        if (player == null) return;

        _players.Remove(player);

        Debug.Log("Player stopped touching crystal!");
    }
}
