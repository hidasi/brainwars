using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public float currentHealth;
    public float maxHealth=100;

    public float invincibilityLength;
    private float invincCounter;

    public float flashLength;
    private float flashCounter;

    private PlayerController pc;

    public SpriteRenderer[] playerSprites;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealth(currentHealth, maxHealth);
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                foreach(SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = !sr.enabled;
                }
                flashCounter = flashLength;
            }
            if (invincCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = true;
                }
                flashCounter = 0f;
            }
        }
    }
    public void DamagePlayer(float damageAmount)
    {
        if (invincCounter <= 0)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                if (pc.crawl.activeSelf)
                {
                    pc.crawl.SetActive(false);
                    pc.standing.SetActive(true);
                }
                currentHealth = 0;
                //gameObject.SetActive(false);
                pc.anim.SetTrigger("death");
                RespawnController.instance.Respawn();
            }
            else
            {
                if (damageAmount != 0)
                {
                    invincCounter = invincibilityLength;
                }
                
            }
            UIController.instance.UpdateHealth(currentHealth, maxHealth);
        }
        
    }
    public void FillHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealth(currentHealth, maxHealth);

    }
    public void HealPlayer(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealth(currentHealth,maxHealth);
    }
}
