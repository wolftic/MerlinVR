using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static float Health;


    private void Start()
    {
        Health = 100f;
    }

    public void DealDamage(float dmg)
    {
        Health -= dmg;
        Health = Mathf.Clamp(Health, 0f, 100f);
        Debug.Log(dmg);
        //Debug.Log("Tower Health: " + Health);
    }

    private void Update()
    {
        //
        //DisplayText
    }
}
