using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class violao : MonoBehaviour
{
    private bool collide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collide == true)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                AudioManager.instance.violaomusic();
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collide = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collide = false;
            AudioManager.instance.PlayLevelMusic();
        }
    }
}
