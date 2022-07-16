using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class introfim : MonoBehaviour
{
    public Ease ease = Ease.Linear;

    public GameObject nave;

    public GameObject player;

    public GameObject nave2;

    public GameObject airsteam;

    private Rigidbody2D rb;
    private bool comeco;
    private int intro;
    // Start is called before the first frame update
    void Start()
    {
        intro=PlayerPrefs.GetInt("introfim");
        if (intro != 1)
        {
            rb = nave.GetComponent<Rigidbody2D>();
            StartCoroutine(intro0co());
        }
        else
        {
            nave2.SetActive(true);
            AudioManager.instance.PlayLevelMusic();
        }

        //AudioManager.instance.PlayLevelMusic();

    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator intro0co()
    {
        yield return new WaitForSeconds(2f);
        nave.transform.DOMoveY(-4.91f, 3f);
        comeco = true;
        AudioManager.instance.PlaySFX(30);
        airsteam.SetActive(true);
        yield return new WaitForSeconds(4f);
        player.SetActive(true);
        airsteam.SetActive(false);
        AudioManager.instance.PlayLevelMusic();
        PlayerPrefs.SetInt("introfim", 1);
        //SceneManager.LoadScene("level1");
    }

}