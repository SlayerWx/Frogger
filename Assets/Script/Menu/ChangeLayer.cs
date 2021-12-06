using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public GameObject next;
    public GameObject previous;
    public void Change()
    {
        if (previous) previous.SetActive(false);
        if (next) next.SetActive(true);
    }
}
