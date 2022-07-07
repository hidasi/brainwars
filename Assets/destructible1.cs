using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructible1 : MonoBehaviour
{
    public int destroying;
    public ParticleSystem particles;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroying == 3)
        {
            StartCoroutine(destroyed());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="shot")
        {
            var par = Instantiate(particles, transform);
            par.transform.position = new Vector2(transform.position.x, transform.position.y);
            destroying++;
        }
    }
    IEnumerator destroyed()
    {
        anim.SetBool("destroy", true);
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
