using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHealthController : MonoBehaviour
{
    public float totalHealth = 3;
    public GameObject deathEffect;
    public Animator anim;
    public EnemyFlyingController flyingchaser;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void DamageEnemy(float damageAmount)
    {
        totalHealth -= damageAmount;

        if (totalHealth > 0)
        {
            anim.SetTrigger("hit");
        }

        if (totalHealth <= 0 && dead==false)
        {
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                StartCoroutine(DeathFLYING());
                dead = true;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathFLYING()
    {
        flyingchaser.moveSpeed = 0;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
