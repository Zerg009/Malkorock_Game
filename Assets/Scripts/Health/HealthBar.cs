using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        Debug.Log("Player: " + playerHealth.health);
        totalhealthBar.fillAmount = playerHealth.health / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.health / 10;
    }
}
