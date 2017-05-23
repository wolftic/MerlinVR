using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public static float Health;
    private Image _towerHealthImage;

    private void Start()
    {
        Health = 100f;
        _towerHealthImage = GameObject.FindGameObjectWithTag("TowerHealth").GetComponent<Image>();
    }

    public void DealDamage(float dmg)
    {
        Health -= dmg;
        Health = Mathf.Clamp(Health, 0f, 100f);
        if (Health == 0)
        {
            Debug.Log("lose");
        }
    }

    private void Update()
    {
        if (!_towerHealthImage)
        {
            _towerHealthImage = GameObject.FindGameObjectWithTag("TowerHealth").GetComponent<Image>();
        }
        _towerHealthImage.fillAmount = Health / 100f;
    }
}
