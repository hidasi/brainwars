using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Continue", SceneManager.GetActiveScene().name);
        GameManager.instance.nbooks = PlayerPrefs.GetInt("books");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
