using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    [SerializeField]
    protected float health;

    public virtual void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void AddHealth(float hp)
    {
        health += hp;
    }
}
