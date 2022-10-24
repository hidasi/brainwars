using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject bossToActivate;
    private int chefe;
    public GameObject gate;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossToActivate.SetActive(true);
            
            AudioManager.instance.PlayMainMenuMusic();
            //gameObject.SetActive(false);
            
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        chefe = PlayerPrefs.GetInt("boss1");
        if (chefe == 1 || chefe == 2)
        {
            gate.SetActive(true);
            Destroy(canvas);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
