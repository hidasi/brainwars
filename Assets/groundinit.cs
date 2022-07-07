using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundinit : MonoBehaviour
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
        if (collision.tag == "Player" && player.crawl.activeSelf)
        {
            player.crawl.SetActive(false);
            player.standing.SetActive(true);
            player.theRB.gravityScale = 5;

        }
    }
}
