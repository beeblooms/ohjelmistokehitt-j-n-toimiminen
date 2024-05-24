using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string text;

    public void ShowText()
    {
        TextObject.text = text;

       
    }
    
}
