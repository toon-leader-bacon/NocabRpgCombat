using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider_UI;

    public int maxHealth { get; set; } = 100;
    public int currentHealth { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        if (healthSlider_UI == null)
        {
            // Attempt to grab from this object
            healthSlider_UI = GetComponent<Slider>();
        }

        SetMaxHealth(maxHealth);
        SetCurrentHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SetCurrentHealth(currentHealth - 5);
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider_UI.maxValue = maxHealth;
        healthSlider_UI.value = maxHealth; // Start with full health
    }

    public void SetCurrentHealth(int newHealth)
    {
        currentHealth = Mathf.Max(newHealth, 0);
        healthSlider_UI.value = currentHealth;
    }
}
