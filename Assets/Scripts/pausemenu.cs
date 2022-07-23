using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public GameObject ui;
    public Text nbookstext;
    public PlayerController player;
    private float moveinitial;
    private float dashinitial;
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
        if (Input.GetButtonDown("Start"))
        {
            if (GameManager.instance.isPaused)
            {
                ResumeGame();
            }
            else if (!GameManager.instance.isPaused)
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        //ui = pauseSCREEN.gameObject;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        nbookstext.text = "X " + PlayerPrefs.GetInt("books");
        ui.SetActive(true);
        player.moveSpeed = 0;
        player.dashSpeed = 0;
        GameManager.instance.isPaused = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        ui.SetActive(false);
        player.moveSpeed = moveinitial;
        player.dashSpeed = dashinitial;
        GameManager.instance.isPaused = false;
    }
}
