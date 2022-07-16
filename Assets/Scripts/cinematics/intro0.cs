using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro0 : MonoBehaviour
{

    public GameObject nave;

    private Rigidbody2D rb;
    private bool comeco;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.introMusic();
        rb = nave.GetComponent<Rigidbody2D>();
        StartCoroutine(intro0co());
    }

    // Update is called once per frame
    void Update()
    {
        if (comeco == false)
        {
            //rb.velocity = new Vector2(50, 0);
        }
        if (comeco == true)
        {
            rb.velocity = new Vector2(15, 0);
        }


    }

    IEnumerator intro0co()
    {
        yield return new WaitForSeconds(5f);
        comeco = true;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Intro1");
    }

}