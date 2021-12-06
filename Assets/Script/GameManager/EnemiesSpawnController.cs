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
    public float substractDifLvl1 = 0.5f;
    public float substractDifLvl2 = 0.35f;
    public float substractDifLvl3 = 0.23f;
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(timeToStartGame);
        if (LevelManager.lvl == 1)
            timeForDistance = substractDifLvl1;
        if (LevelManager.lvl == 2)
            timeForDistance = substractDifLvl2;
        if (LevelManager.lvl == 3)
            timeForDistance = substractDifLvl3;
        while (playing)
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
                    obj.sp.flipX = true;
                }
                else
                {
                    obj.gm.transform.position = left[GetIndex(ref last, left.Length)].position;
                    obj.md.direction = Vector3.right;
                    obj.sp.flipX = false;
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
