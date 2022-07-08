using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class book : MonoBehaviour
{
    public GameObject printer;
    public PlayerController player;
    public Text texting;
    public int nbook;
    private float moveinitial;
    private float dashinitial;
    private bool comecar;
    private bool um;
    private bool dois;
    private bool tres;
    private bool quatro;
    public string[] dialogLines;
    public int currentLine;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        moveinitial = player.moveSpeed;
        dashinitial = player.dashSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (comecar && nbook==1)
        {
            player.moveSpeed=0;
            player.dashSpeed = 0;
            printer.SetActive(true);
            texting.text = "Anaxagoras was a great presocratic philosopher who wrote a book called On Nature, where he talked about various things.";
            StartCoroutine(waitum());
            if ((Input.GetButtonDown("Fire1")&&um) || dois)
            {
                texting.text = "For example, he said that the Sun was not divine, but rather it was a giant thing on fire. Religious people didn't like the book, so they kidnapped Anaxagoras.";
                StartCoroutine(waitdois());
                if ((Input.GetButtonDown("Fire1")&&dois) || tres)
                {
                    texting.text = "He remained kidnapped until Pericles, a great politician, told everyone to free Anaxagoras.";
                    StartCoroutine(waittres());
                    if ((Input.GetButtonDown("Fire1") && tres) || quatro)
                    {
                        quatro = true;
                        texting.text = "";
                        printer.SetActive(false);
                        Destroy(this.gameObject);
                        player.moveSpeed = moveinitial;
                        player.dashSpeed = dashinitial;
                    }
                }
            }
        }*/
        if (comecar)
        {
            player.moveSpeed = 0;
            player.dashSpeed = 0;
            printer.SetActive(true);
            if (!um)
            {
                texting.text = dialogLines[0];
                currentLine=0;
                um = true;
            }
            
            if (Input.GetButtonDown("Fire3"))
            {
                currentLine++;
                if (currentLine >= dialogLines.Length)
                {
                    printer.SetActive(false);
                    player.moveSpeed = moveinitial;
                    player.dashSpeed = dashinitial;
                    GameManager.instance.nbooks++;
                    Destroy(this.gameObject);
                }
                else
                {          
                    texting.text = dialogLines[currentLine];
                }
            }
        }
        




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        comecar=true;
    }
    IEnumerator waitum()
    {
        yield return new WaitForSeconds(2f);
        um = true;
    }
    IEnumerator waitdois()
    {
        yield return new WaitForSeconds(2f);
        dois = true;
    }
    IEnumerator waittres()
    {
        yield return new WaitForSeconds(2f);
        tres = true;
    }
    IEnumerator waitquatro()
    {
        yield return new WaitForSeconds(2f);
        quatro = true;
    }
}
