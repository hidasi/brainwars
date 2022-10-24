using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D theRB;
    public GameObject impactEffect;
    public float damageAmount = 1f;

    public Vector2 moveDir;
    private bool rotated;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = moveDir * bulletSpeed;
        if (moveDir.x < 0 && !rotated)
        {
            transform.localScale=new Vector3(-2.8868f, 2.8868f, 2.8868f);
            rotated = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boss")
        {
            BossHealthController.instance.TakeDamage(damageAmount);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponentInParent<EnemyHealthController>().DamageEnemy(damageAmount);
        }

        if (other.tag == "flyingenemy")
        {
            other.GetComponentInParent<FlyingEnemyHealthController>().DamageEnemy(damageAmount);
        }

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
