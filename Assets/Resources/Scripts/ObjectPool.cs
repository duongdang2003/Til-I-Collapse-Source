using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Dictionary<string,Queue<GameObject>> pools = new ();
    public static ObjectPool Instance;
    [Serializable]
    public struct Object {
        public GameObject obj;
        public int quantity;
        public string poolName;
    }
    public Object[] objectList;
    private void Awake() {
        if(!Instance)
        Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        foreach(Object objectEl in objectList){
            Queue<GameObject> objQueue = new ();
            for(int i=0; i < objectEl.quantity; i++){
                GameObject obj = Instantiate(objectEl.obj);
                obj.SetActive(false);
                objQueue.Enqueue(obj);
            }
            pools.Add(objectEl.poolName, objQueue);
        }


    }
    public GameObject GetObjectFromPool(string poolName){
        GameObject obj = pools[poolName].Dequeue();
        obj.SetActive(true);
        pools[poolName].Enqueue(obj);
        return obj;
    }
    
}
