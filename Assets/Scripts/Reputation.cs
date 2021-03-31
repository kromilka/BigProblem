using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reputation : MonoBehaviour
{
    public static int Karma = 0;
    private Text karmaUI;

    void Start()
    {
        karmaUI = GetComponent<Text>();
    }

    void Update()
    {
        karmaUI.text = "Карма: " + Karma;
    }

}
