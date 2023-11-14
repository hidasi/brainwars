using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int threshold1, threshold2;
    public GameObject canvas;

    public float activeTime, fadeoutTime, inactiveTime;
    private float activeCounter, fadeCounter, inactiveCounter;

    public Transform[] spawnPoints;
    private Transform targetPoint;
    public float moveSpeed;

    private float moveinitial;

    public Animator anim;
    public Transform theBoss;

    private bool fadein;

    public float timeBetweenShots1, timeBetweenShots2;
    private float shotCounter;
    public GameObject bullet;
    public Transform shotPoint;

    public GameObject abilityprefab;
    public ParticleSystem particle;
    public Transform transf;

    public Color colorboss;

    public bool pausar;
    private int chefe;

    public PlayerController player;

    public GameObject gate;
    private bool End;

    // Start is called before the first frame update
    void Start()
    {
        activeCounter = activeTime;
        shotCounter = timeBetweenShots1;

        

        chefe = PlayerPrefs.GetInt("boss1");
        if(chefe == 1)
        {
            
            Instantiate(particle, transf);
            abilityprefab.SetActive(true);
            
        }
        if(chefe==1 || chefe == 2)
        {
            gate.SetActive(true);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        if (pausar == false)
        {
            if (BossHealthController.instance.bosscurrentHealth > threshold1)
            {
                if (activeCounter > 0)
                {
                    if (fadein == false)
                    {
                        anim.SetTrigger("fadein");
                        fadein = true;
                    }

                    activeCounter -= Time.deltaTime;
                    if (activeCounter <= 0)
                    {

                        fadeCounter = fadeoutTime;
                        anim.SetTrigger("fadeout");

                    }
                    shotCounter -= Time.deltaTime;
                    if (shotCounter <= 0)
                    {
                        shotCounter = timeBetweenShots1;

                        Instantiate(bullet, shotPoint.position, Quaternion.identity);
                    }
                }
                else if (fadeCounter > 0)
                {
                    fadeCounter -= Time.deltaTime;
                    if (fadeCounter <= 0)
                    {
                        theBoss.gameObject.SetActive(false);
                        inactiveCounter = inactiveTime;
                    }
                }
                else if (inactiveCounter > 0)
                {
                    inactiveCounter -= Time.deltaTime;
                    if (inactiveCounter <= 0)
                    {
                        theBoss.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                        theBoss.gameObject.SetActive(true);

                        fadein = false;

                        activeCounter = activeTime;

                        shotCounter = timeBetweenShots1;
                    }
                }
            }


            else
            {
                if (targetPoint == null)
                {
                    targetPoint = theBoss;
                    fadeCounter = fadeoutTime;
                    anim.SetTrigger("fadeout");
                }
                else
                {
                    if (Vector3.Distance(theBoss.position, targetPoint.position) > 0.02f)
                    {
                        theBoss.position = Vector3.MoveTowards(theBoss.position, targetPoint.position, moveSpeed * Time.deltaTime);
                        if (Vector3.Distance(theBoss.position, targetPoint.position) <= 0.02f)
                        {
                            /*if (fadein == false)
                            {
                                anim.SetTrigger("fadein");
                                fadein = true;
                            }*/
                            fadeCounter = fadeoutTime;
                            
                        }

                        shotCounter -= Time.deltaTime;
                        if (shotCounter <= 0)
                        {
                            if (PlayerHealthController.instance.currentHealth > threshold2)
                            {
                                shotCounter = timeBetweenShots1;
                            }
                            else
                            {
                                shotCounter = timeBetweenShots2;
                            }

                            Instantiate(bullet, shotPoint.position, Quaternion.identity);
                        }

                    }
                    else if (fadeCounter > 0)
                    {
                        fadeCounter -= Time.deltaTime;
                        if (fadeCounter <= 0)
                        {
                            //anim.SetTrigger("fadeout");
                            theBoss.gameObject.SetActive(false);
                            inactiveCounter = inactiveTime;
                        }
                    }
                    else if (inactiveCounter > 0)
                    {
                        inactiveCounter -= Time.deltaTime;
                        if (inactiveCounter <= 0)
                        {
                            theBoss.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                            targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                            int whileBreaker = 0;
                            while (targetPoint.position == theBoss.position && whileBreaker < 100)
                            {
                                targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                                whileBreaker++;
                            }
                            fadein = false;
                            theBoss.gameObject.SetActive(true);

                            if (PlayerHealthController.instance.currentHealth > threshold2)
                            {
                                shotCounter = timeBetweenShots1;
                            }
                            else
                            {
                                shotCounter = timeBetweenShots2;
                            }
                        }
                    }
                }
            }
        }
    }
        

    public void EndBattle()
    {
        if (End == false)
        {
            colorboss = FindObjectOfType<SpriteRenderer>().color;
            colorboss.a = 1f;
            StartCoroutine(EndedBattle());
            End = true;
        }
        
    }

    IEnumerator EndedBattle()
    {
        
        pausar = true;
        player = FindObjectOfType<PlayerController>();
        moveinitial = player.moveSpeed;
        player.moveSpeed = 0;
        
        theBoss.gameObject.SetActive(true);
        
        anim.SetTrigger("fadeout");
        anim.SetTrigger("fadein");

        colorboss = FindObjectOfType<SpriteRenderer>().color;
        colorboss.a = 1f;

        yield return new WaitForSeconds(2f);
        colorboss.a = 1f;
        anim.SetTrigger("death");
        AudioManager.instance.PAUSEMUSIC();
        AudioManager.instance.PlaySFX(33);
        yield return new WaitForSeconds(29f);
        Instantiate(particle, transf);
        abilityprefab.SetActive(true);
        PlayerPrefs.SetInt("boss1",1);
        gate.SetActive(true);
        AudioManager.instance.PlayLevelMusic();
        player.moveSpeed = moveinitial;
        Destroy(canvas);
        Destroy(gameObject);
        
    }
}
