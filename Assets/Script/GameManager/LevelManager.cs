using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static int lvl = 1;
    public GameObject winUI;
    public GameObject lossUI;
    public UIPoints points;
    public int basicPoints = 10;
    bool fakeLoadActive = false;
    public GameObject fakeLoad;
    public float waitInFake = 2.0f;
    public Text fakeLoadtext;
    public int lastLevel = 3;
    public GameObject winGame;
    bool pause;
    public GameObject pauseLayer;
    public PlayerMove player;
    private void OnEnable()
    {
        fakeLoadActive = false;
        PlayerMove.OnLifeChange+=LossCheck;
        WinCondition.OnPlayerWin+= WinCheck;
        Time.timeScale = 1.0f;
        pause = false;
        if(lvl == 1)
        {
        }
    }
    private void OnDisable()
    {
        PlayerMove.OnLifeChange -= LossCheck;
        WinCondition.OnPlayerWin -= WinCheck;

    }
    void LossCheck(int aux)
    {
        if (aux <= 0)
        {
            lossUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    void WinCheck()
    {

        Time.timeScale = 0.0f;
        if (lvl >= lastLevel)
            winGame.SetActive(true);
        else
            winUI.SetActive(true);
        points.SetPoints(basicPoints * lvl);
    }
    public void CallFakeLoad()
    {
        if (!fakeLoadActive)
        {
            StartCoroutine(FakeLoad());
        }
    }
    IEnumerator FakeLoad()
    {
        fakeLoadActive = true;
        fakeLoad.SetActive(true);
        lvl++;
        fakeLoadtext.text = "Level "+lvl;
        yield return new WaitForSecondsRealtime(waitInFake);
        SceneManager.LoadScene("Gameplay");
    }
    public void Pause()
    {
       if(!pause)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;

        }
       pause = !pause;
        pauseLayer.SetActive(pause);
        player.inPause = pause;
    }
}
