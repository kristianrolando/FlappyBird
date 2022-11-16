using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] PipeList[] pipe;
    [SerializeField] Transform posSpawn;
    [SerializeField] float _maxY;
    [SerializeField] float _minY;

    int pipeType;
    float spawnTime;
    float speedPipe;
    float time;
    bool isStart;

    private void Update()
    {
        if(isStart)
            Spawn();
        SetDataPipe();
    }

    void Spawn()
    {
        time -= Time.deltaTime;
        if(time <= 0 )
        {
            float y = Random.Range(_minY, _maxY);
            Vector3 _pos = new Vector3(posSpawn.position.x, y, posSpawn.position.z);

            pipe[pipeType].pipePref.speed = speedPipe;
            pipe[pipeType].CreateObject(_pos, this.transform);

            time = spawnTime;
        }
    }
    void SetDataPipe()
    {
        var g = GameManager.Instance;
        spawnTime = g.spawnTime;
        pipeType = g.pipeType;
        speedPipe = g.speedPipe;

    }
    private void OnEnable()
    {
        GameManager.OnGameStarted += () => { isStart = true; };
    }
    private void OnDisable()
    {
        GameManager.OnGameStarted -= () => { isStart = true; };
    }
}
