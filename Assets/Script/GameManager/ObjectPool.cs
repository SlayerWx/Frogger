using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct GMandMD
{
    public GameObject gm;
    public MoveToDirection md;
    public SpriteRenderer sp;
}
public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    private List<MoveToDirection> directionComponents;
    private List<SpriteRenderer> sprite;
    public Color[] randomColors;
    public GameObject objectToPool;
    public int amountToPool;
    void Start()
    {
        pooledObjects = new List<GameObject>();
        directionComponents = new List<MoveToDirection>();
        sprite = new List<SpriteRenderer>();
        GameObject aux;
        for (int i = 0; i < amountToPool; i++)
        {
            aux = Instantiate(objectToPool);
            aux.SetActive(false);
            pooledObjects.Add(aux);
            SpriteRenderer aux2 = aux.GetComponent<SpriteRenderer>();
            aux2.color = randomColors[Random.Range(0,randomColors.Length)];
            directionComponents.Add(aux.GetComponent<MoveToDirection>());
            sprite.Add(aux2);
        }
    }
    public GMandMD GetPooledObject()
    {
        GMandMD aux;
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                aux.gm = pooledObjects[i];
                aux.md = directionComponents[i];
                aux.sp = sprite[i];
                return aux;
            }
        }
        aux.gm = null;
        aux.md = null;
        aux.sp = null;
        return aux;
    }
}
