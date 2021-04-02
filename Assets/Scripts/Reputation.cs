using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reputation : MonoBehaviour
{
    public static int Karma = 0;
    public static int Positive = 0;
    public static int Negative = 0;
    private Text karmaUI;

    void Start()
    {
        karmaUI = GetComponent<Text>();
        waitFor();
    }

    void Update()
    {
        karmaUI.text = "Карма: " + Karma + "\n" + "+: " + Positive + "\n" + "-: " + "1" + "\n";
    }

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(7.7f);
        SceneManager.LoadScene(0);
    }

}
