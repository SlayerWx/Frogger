using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILifes : MonoBehaviour
{
    public Text txt;
    public string first;
    private void OnEnable()
    {
        PlayerMove.OnLifeChange +=valueChanged;
    }
    private void OnDisable()
    {
        PlayerMove.OnLifeChange -=valueChanged;

    }
    void valueChanged(int a)
    {
        txt.text = first + a;
    }
}
