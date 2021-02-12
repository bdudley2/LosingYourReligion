using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D _collider)
    {
        _text.text = "This is some text.";
    }
}
