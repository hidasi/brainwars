using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }

    public GameObject ui;
    public int nbooks;
    public Text nbookstext;
    private bool isPaused;
    private float moveinitial;
    private float dashinitial;
    public PlayerController player;

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
            if (isPaused)
            {
                ResumeGame();
            } else if (!isPaused)
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        nbookstext.text = "X " + nbooks;
        ui.SetActive(true);
        player.moveSpeed = 0;
        player.dashSpeed = 0;
        isPaused = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        ui.SetActive(false);
        player.moveSpeed = moveinitial;
        player.dashSpeed = dashinitial;
        isPaused = false;
    }
}
