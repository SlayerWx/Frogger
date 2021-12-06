using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WinCondition : MonoBehaviour
{
    public static Action OnPlayerWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerWin?.Invoke();
    }
}
