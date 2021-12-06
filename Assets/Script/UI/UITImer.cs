using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITImer : MonoBehaviour
{
    public float timer;
    public Text txt;
    void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        txt.text = "Time: " +(int)timer;
    }


}
