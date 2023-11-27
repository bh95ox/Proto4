using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int MaxShield;
    [SerializeField] private GameObject DeathUIPanel;
    [SerializeField] private GameObject CrossAirUIPanel;
    [SerializeField] private GameObject GameStatsUIPanel;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider shieldBar;
    [SerializeField] private TextMeshProUGUI HP_Percentage;
    [SerializeField] private TextMeshProUGUI SP_Percentage;
    
    private int CurrentHealth;
    private int CurrentShield;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentShield = MaxShield;
    }

    private void Update()
    {
        healthBar.value = CurrentHealth;
        shieldBar.value = CurrentShield;

        HP_Percentage.text = CurrentHealth.ToString()+"%";
        SP_Percentage.text = CurrentShield.ToString()+"%";

    }

    void TakeDamageShield(int Amount)
    {
        CurrentShield -= Amount;
    }

    // Damage to Health
    void TakeDamageHealth(int Amount)
    {
        CurrentHealth -= Amount;
    }



    public void DamageTaken(int Amount)
    {
        int DmgShield = Amount / 3 * 2;
        int DmgHealth = Amount / 3 * 1;

        if (Amount > 0)
        {
            if (CurrentShield > 0)
            {
                TakeDamageShield(DmgShield);
                TakeDamageHealth(DmgHealth);

            }
            else if (CurrentShield <= 0)
            {
                TakeDamageHealth(Amount);
            }
        }
        if (CurrentHealth <= 0)
        {
                DeathTrigger();
        }
    }

    private void DeathTrigger()// Trigger the Death panel
    {
        Debug.Log("You Have Died");
        //Enable Death UI
        DeathUIPanel.SetActive(true);
        CrossAirUIPanel.SetActive(false);
        GameStatsUIPanel.SetActive(false);
        //ui.CanPause= false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Heal the User Health Point
    public void UseHeal(int Amount)
    {
        Debug.Log("Health Increase by "+ Amount);
        CurrentHealth += Amount;
    }

    //Increaase the user Shield Point
    public void UseShield(int Amount)
    {
        Debug.Log("Shield Increase by " + Amount);
        CurrentShield += Amount;
    }



}
