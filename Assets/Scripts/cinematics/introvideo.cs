using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introvideo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(intro0co());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator intro0co()
    {
        yield return new WaitForSeconds(92f);
        SceneManager.LoadScene("Intro0");
    }
}