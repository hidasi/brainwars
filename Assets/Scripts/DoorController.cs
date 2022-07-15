using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private bool playerExiting;
    private PlayerController pc;
    private float dashinitial, speedinitial;
    public Transform exitPoint;
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        dashinitial = pc.dashSpeed;
        speedinitial = pc.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerExiting)
        {
            pc.transform.position = Vector3.MoveTowards(pc.transform.position, exitPoint.position, 30 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!playerExiting)
            {
                pc.moveSpeed = 0;
                pc.dashSpeed = 0;
                StartCoroutine(UseDoorCo());
            }
        }
    }
    IEnumerator UseDoorCo()
    {
        playerExiting = true;
        //pc.anim.enabled = false;
        yield return new WaitForSeconds(1.5f);

        
        pc.moveSpeed = speedinitial;
        pc.dashSpeed = dashinitial;
        RespawnController.instance.SetSpawn(exitPoint.position);
        SceneManager.LoadScene(levelToLoad);
    }
}
