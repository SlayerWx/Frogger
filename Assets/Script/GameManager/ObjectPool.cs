using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct GMandMD
{
    public GameObject gm;
    public MoveToDirection md;
}
public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    private List<MoveToDirection> directionComponents;
    public Color[] randomColors;
    public GameObject objectToPool;
    public int amountToPool;
    void Start()
    {
        pooledObjects = new List<GameObject>();
        directionComponents = new List<MoveToDirection>();
        GameObject aux;
        for (int i = 0; i < amountToPool; i++)
        {
            aux = Instantiate(objectToPool);
            aux.SetActive(false);
            pooledObjects.Add(aux);
            aux.GetComponent<SpriteRenderer>().color = randomColors[Random.Range(0,randomColors.Length)];
            directionComponents.Add(aux.GetComponent<MoveToDirection>());
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
                return aux;
            }
        }
        aux.gm = null;
        aux.md = null;
        return aux;
    }
}
