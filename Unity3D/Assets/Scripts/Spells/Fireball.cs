using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    private bool _active = false;
    [SerializeField]
    private GameObject _explosion;

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

        if (enemy == null)
        {
            var expl = Instantiate(_explosion) as GameObject;
            expl.transform.position = transform.position;
            Destroy(expl, 5f);
        }
        else
        {
            enemy.DealDamage(damage);
        }
    }

    public override void Activate()
    {
        _active = true;
    }

    public override void Init()
    {

    }
}
