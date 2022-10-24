using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EVENT1 : MonoBehaviour
{
    public GameObject cam2;
    public GameObject puppet;
    private PlayerController player;
    private float moveinitial;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        moveinitial = player.moveSpeed;
        if (PlayerPrefs.GetInt("EVENT1") == 1)
        {
            Destroy(puppet.gameObject);
            Destroy(gameObject);
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam2.SetActive(true);
            player.moveSpeed = 0;
            StartCoroutine(cin());
        }
        
    }

    IEnumerator cin()
    {
        AudioManager.instance.warningMusic();
        yield return new WaitForSeconds(5f);
        AudioManager.instance.PlaySFX(31);
        yield return new WaitForSeconds(7f);
        puppet.transform.localScale = new Vector3(-7.213856f, 7.741699f,1f);
        yield return new WaitForSeconds(27f);
        puppet.gameObject.GetComponent<Animator>().SetTrigger("fade");
        yield return new WaitForSeconds(3f);
        cam2.SetActive(false);
        RespawnController.instance.vcam = FindObjectOfType<cinecam>().GetComponent<CinemachineVirtualCamera>();
        //RespawnController.instance.vcam.Follow = FindObjectOfType<CharacterController>().transform;
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlayLevelMusic();
        PlayerPrefs.SetInt("EVENT1", 1);
        player.moveSpeed = moveinitial;
        Destroy(gameObject);
    }

}
