using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public GameObject lightning1,lightning2,image1,image2, A, W, S;
    public float timerfull = 4f, timerfullactive=1;
    public float timer,timeractive;
    private bool calc;
    private int rand=3;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerfull;
        timeractive = timerfullactive;
        AudioManager.instance.PlayMainMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (calc == false)
            {
                rand = Random.Range(0, 3);
                calc = true;
            }
            if (rand == 0)
            {
                A.SetActive(true);
                timeractive -= Time.deltaTime;
                if (timeractive <= 0)
                {
                    A.SetActive(false);
                    rand = 3;
                    timeractive = timerfullactive;
                    timer = timerfull;
                    calc = false;
                }
            }
            if (rand == 1)
            {
                W.SetActive(true);
                timeractive -= Time.deltaTime;
                if (timeractive <= 0)
                {
                    W.SetActive(false);
                    rand = 3;
                    timeractive = timerfullactive;
                    timer = timerfull;
                    calc = false;
                }
            }
            if (rand == 2)
            {
                S.SetActive(true);
                timeractive -= Time.deltaTime;
                if (timeractive <= 0)
                {
                    S.SetActive(false);
                    rand = 3;
                    timeractive = timerfullactive;
                    timer = timerfull;
                    calc = false;
                }
            }
        }

        float direction = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        if (direction > 0)
        {
            image1.SetActive(true);
            image2.SetActive(false);
            lightning1.SetActive(true);
            lightning2.SetActive(false);
        }
        if (direction < 0)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            lightning1.SetActive(false);
            lightning2.SetActive(true);
        }
    }
}
