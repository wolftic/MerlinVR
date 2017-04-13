using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public float Health;


    private void Start()
    {
        Health = 100;
    }

    public void DealDamage(float dmg)
    {
        if (Health > 0)
        {
            Health -= dmg;
        }
        else
        {
            Health = 0;
        }

    }

    private void Update()
    {
        Debug.Log("Tower Health: " + Health);
    }
}
