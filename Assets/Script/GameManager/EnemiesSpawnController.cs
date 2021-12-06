using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
    public Transform[] leftGroundSpawner;
    public Transform[] rightGroundSpawner;
    public Transform[] leftWaterSpawner;
    public Transform[] rightWaterSpawner;
    public ObjectPool groundPool;
    public ObjectPool waterPool;
    public float timeForDistance; // 0.23 max dif, 0.5 easy dif
    public float timeToStartGame;
    private int lastGround = -1;
    private int lastWater = -1;
    public bool playing = true;
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(timeToStartGame);
        while(playing)
        {
            ActiveObstacle(groundPool, leftGroundSpawner, rightGroundSpawner,ref lastGround);
            ActiveObstacle(waterPool, leftWaterSpawner, rightWaterSpawner,ref lastWater);
            yield return new WaitForSeconds(timeForDistance);
        }
    }
    void ActiveObstacle(ObjectPool pool,Transform[] left,Transform[] right,ref int last)
    {
        if (pool.enabled)
        {
           GMandMD obj = pool.GetPooledObject();
            if(obj.gm)
            {
                obj.gm.SetActive(true);
                if (Random.Range(-1, 2) > 0)
                {
                    obj.gm.transform.position = right[GetIndex(ref last,right.Length)].position;
                    obj.md.direction = Vector3.left;
                }
                else
                {
                    obj.gm.transform.position = left[GetIndex(ref last, left.Length)].position;
                    obj.md.direction = Vector3.right;
                }
            }
        }
    }
    int GetIndex(ref int last,int length)
    {
        int index;
        do
        {
            index = Random.Range(0, length);
        } while (index == last);
        last = index;
        return index;
    }
}
