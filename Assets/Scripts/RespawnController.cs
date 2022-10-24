using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;
    private void Awake()
    {
        instance = this;
    }
    public Vector3 respawnPoint;
    public float waitToRespawn;
    public PlayerController playermovement;
    private GameObject thePlayer;
    public CinemachineVirtualCamera vcam;
    private float speedinitial, dashinitial;
    public void SetSpawn(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = PlayerHealthController.instance.gameObject;
        respawnPoint = thePlayer.transform.position;
        
        playermovement = FindObjectOfType<PlayerController>();
        vcam= FindObjectOfType<cinecam>().GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = playermovement.transform;
        dashinitial = playermovement.dashSpeed;
        speedinitial = playermovement.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        playermovement.moveSpeed = 0;
        playermovement.dashSpeed = 0;
        

        yield return new WaitForSeconds(waitToRespawn);
        thePlayer.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        thePlayer.transform.position = respawnPoint;
        thePlayer.SetActive(true);

        PlayerHealthController.instance.FillHealth();
        
        
        thePlayer = GameObject.FindWithTag("Player");
        vcam.Follow = thePlayer.transform;

        playermovement.moveSpeed = speedinitial;
        playermovement.dashSpeed = dashinitial;
    }
}
