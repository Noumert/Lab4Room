using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float currentHealth;
    public static float maxHealth=10;
    public Text Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.text = maxHealth + "/" + currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.text = maxHealth + "/" + currentHealth;
  
    }
}
