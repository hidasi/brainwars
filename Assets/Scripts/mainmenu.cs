using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public GameObject lightning1,lightning2,image1,image2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
