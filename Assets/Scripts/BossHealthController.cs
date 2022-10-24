using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{
    public static BossHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider bossHealthSlider;

    public float bosscurrentHealth;

    public BossBattle theBoss;

    // Start is called before the first frame update
    void Start()
    {
        bossHealthSlider.maxValue = bosscurrentHealth;
        bossHealthSlider.value = bosscurrentHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        bosscurrentHealth -= damageAmount;
        if (bosscurrentHealth <= 0)
        {
            bosscurrentHealth = 0;
            theBoss.EndBattle();
        }
        bossHealthSlider.value = bosscurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
