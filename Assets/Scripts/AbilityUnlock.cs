using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityUnlock : MonoBehaviour
{
    public bool unlockDoubleJump, unlockDash, unlockCrawl;
    public GameObject pickupEffect;
    public string unlockMessage;
    public GameObject Canvas;
    public Text printer;
    private bool fim;
    public PlayerController player;
    private float moveinitial;
    private float dashinitial;
    //public TMP_Text unlockText;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        moveinitial = player.moveSpeed;
        dashinitial = player.dashSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAbilityTracker player = collision.GetComponentInParent<PlayerAbilityTracker>();
            if (unlockDoubleJump)
            {
                player.canDoubleJump = true;
            }
            if (unlockDash)
            {
                player.canDash = true;
            }
            if (unlockCrawl)
            {
                player.canCrawl = true;
            }
            Instantiate(pickupEffect, transform.position, transform.rotation);

            /*unlockText.transform.parent.SetParent(null);
            unlockText.transform.parent.position = transform.position;
            Destroy(unlockText.transform.parent.gameObject,5f);

            unlockText.text = unlockMessage;
            unlockText.gameObject.SetActive(true);
            */
            printer.text = unlockMessage;
            Canvas.SetActive(true);
            //this.gameObject.SetActive(false);

            fim = true;
            
        }
    }

    private void Update()
    {
        if (fim)
        {
            player.moveSpeed = 0;
            player.dashSpeed = 0;
            if (Input.GetButtonDown("Fire1"))
            {
                printer.text = "";
                Canvas.SetActive(false);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                player.moveSpeed = moveinitial;
                player.dashSpeed = dashinitial;
                Destroy(gameObject);

            }
        }
    }
}
