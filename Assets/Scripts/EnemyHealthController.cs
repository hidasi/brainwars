using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth = 3;
    public GameObject deathEffect;
    public Animator anim;
    private patrol PATROL;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        PATROL = GetComponent<patrol>();
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
        PATROL.moveSpeed = 0;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
