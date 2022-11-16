using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PipeList
{
    public Pipe pipePref;
    PoolingSystem pool = new PoolingSystem();
    public GameObject CreateObject(Vector3 pos, Transform parent)
    {
        return pool.CreateObject(pipePref, pos, parent).gameObject;
    }
}
