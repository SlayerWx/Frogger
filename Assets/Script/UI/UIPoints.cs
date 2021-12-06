using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPoints : MonoBehaviour
{

    public Text txt;
    public static int points = 0;
    public string first;
    void OnEnable()
    {
        txt.text = first + points;
    }

    public void SetPoints(int aux)
    {
        points += aux;
        txt.text = first + points;
    }
}
