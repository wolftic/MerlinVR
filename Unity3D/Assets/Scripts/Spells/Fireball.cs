using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    private bool _active = false;

    private void Update()
    {
        if (_active)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);

        var enemy = col.transform.root.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.DealDamage(damage);
    }

    public override void Activate()
    {
        _active = true;
    }

    public override void Init()
    {

    }
}
