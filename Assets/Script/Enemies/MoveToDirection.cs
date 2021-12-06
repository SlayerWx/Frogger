using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDirection : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float waitToDisable;
    public void OnEnable()
    {
        StartCoroutine(WaitAndDisable());
    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(waitToDisable);
        gameObject.SetActive(false);
    }
}
