using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT2 : MonoBehaviour
{
    public GameObject puppet;
    private PlayerController player;
    private float moveinitial;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        moveinitial = player.moveSpeed;
        if (PlayerPrefs.GetInt("EVENT2") == 1)
        {
            Destroy(puppet.gameObject);
            Destroy(gameObject);
        }
        else
        {
            player.moveSpeed = 0;
            StartCoroutine(cin());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }


    IEnumerator cin()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.instance.warningMusic();
        yield return new WaitForSeconds(3f);
        AudioManager.instance.PlaySFX(32);
        yield return new WaitForSeconds(93f);
        //puppet.transform.localScale = new Vector3(-7.213856f, 7.741699f, 1f);
        puppet.gameObject.GetComponent<Animator>().SetTrigger("fade");
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlayLevelMusic();
        PlayerPrefs.SetInt("EVENT2", 1);
        player.moveSpeed = moveinitial;
    }

}
