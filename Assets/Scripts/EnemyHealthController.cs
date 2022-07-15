using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth = 3;
    public GameObject deathEffect;
    public Animator anim;
    public patrol PATROL;
    private bool dead;
    public DamagePlayer dp;

    // Start is called before the first frame update
    void Start()
    {
        dp = GetComponent<DamagePlayer>();
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
                StartCoroutine(Death());
                dead = true;
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Death()
    {
        dp.damageAmount = 0;
            PATROL.moveSpeed = 0;       
        anim.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
