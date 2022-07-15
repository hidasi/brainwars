using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro1 : MonoBehaviour
{
    public GameObject nave;
    private Rigidbody2D rb;
    private bool cima;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.introMusic();
        rb = nave.GetComponent<Rigidbody2D>();
        StartCoroutine(intro1co());
    }

    // Update is called once per frame
    void Update()
    {
        if (cima==false)
        {
            rb.velocity = new Vector2(50, 0);
        }
        if (cima==true)
        {
            rb.velocity = new Vector2(50, 5);
        }
        
        
    }
    IEnumerator intro1co()
    {
        yield return new WaitForSeconds(15f);
        cima = true;
    }
}
