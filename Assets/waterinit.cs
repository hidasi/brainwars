using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterinit : MonoBehaviour
{
    public PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.crawl.SetActive(true);
            player.standing.SetActive(false);
            player.theRB.gravityScale = 0.5f;

        }
    }
}
