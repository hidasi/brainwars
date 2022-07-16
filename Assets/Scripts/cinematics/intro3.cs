using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro3 : MonoBehaviour
{

    public GameObject nave;

    private Rigidbody2D rb;
    private bool comeco;

    // Start is called before the first frame update
    void Start()
    {
        rb = nave.GetComponent<Rigidbody2D>();
        StartCoroutine(intro0co());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (comeco == false)
        {
            //rb.velocity = new Vector2(50, 0);
        }
        if (comeco == true)
        {
            rb.velocity = new Vector2(-1.5f, 1f);
            if (nave.transform.localScale.x > 0 && nave.transform.localScale.y > 0 && nave.transform.localScale.z > 0)
            {
                nave.transform.localScale -= new Vector3(0.0004f, 0.0004f, 0.0004f); // Reduce object size by .002 per frame
            }

            // This check makes sure that the scale does not reach below zero
            if (nave.transform.localScale.x < 0 && nave.transform.localScale.y < 0 && nave.transform.localScale.z < 0)
            {
                nave.transform.localScale = Vector3.zero;
            }
        }


    }

    IEnumerator intro0co()
    {
        yield return new WaitForSeconds(1f);
        comeco = true;
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("level1");
    }

}