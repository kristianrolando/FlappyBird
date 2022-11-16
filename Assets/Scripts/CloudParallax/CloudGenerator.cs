using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public Cloud[] cloudPref;
    PoolingSystem pool = new PoolingSystem();
    public GameObject CreateObject(Vector3 pos)
    {
        int c = Random.Range(0, cloudPref.Length);
        return pool.CreateObject(cloudPref[c], pos, this.transform).gameObject;
    }

    [SerializeField] Transform posSpawn;
    [SerializeField] float _maxY;
    [SerializeField] float _minY;

    float spawnTime;
    float time;
    bool isStart;
    private void Start()
    {
        isStart = true;
    }
    private void Update()
    {
        if (isStart)
            Spawn();
    }

    void Spawn()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            float y = Random.Range(_minY, _maxY);
            Vector3 _pos = new Vector3(posSpawn.position.x, y, posSpawn.position.z);
            CreateObject(_pos);

            spawnTime = Random.Range(1f, 2f);
            time = spawnTime;
        }
    }

}
