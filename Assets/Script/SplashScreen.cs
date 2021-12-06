using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // asAS
    [SerializeField] string nextScene = null;
    [SerializeField] float time = 0;
    public GameObject layer1;
    public GameObject layer2;
    void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        layer1.SetActive(true);
        yield return new WaitForSeconds(time);
        layer1.SetActive(false);
        layer2.SetActive(true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }
}
