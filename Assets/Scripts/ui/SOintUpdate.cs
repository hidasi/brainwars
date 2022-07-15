using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOintUpdate : MonoBehaviour
{
    public SOInt soint;
    public Text uiTextValue;
    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = "X "+soint.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = "X " +soint.value.ToString();
    }
}
