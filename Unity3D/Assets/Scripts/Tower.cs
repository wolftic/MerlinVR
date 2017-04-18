using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static float Health;


    private void Start()
    {
        Health = 100f;

    }

    public IEnumerator DealDamage(float dmg)
    {
        yield return new WaitForSeconds(4f);
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
        //Debug.Log("Tower Health: " + Health);
        //DisplayText
    }
}
