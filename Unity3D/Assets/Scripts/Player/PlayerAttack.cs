using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField]
    private Transform _muzzle;
    private Book _book;

    private void Awake()
    {
        _book = GetComponent<Book>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        var spell = _book.GetCurrentSpell();
        var obj = Instantiate(spell);
        obj.transform.position = _muzzle.position;
        obj.transform.rotation = _muzzle.rotation;
        obj.GetComponent<Spell>().Activate();
    }
}
