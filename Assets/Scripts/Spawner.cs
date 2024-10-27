using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPointsParent;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int maxCount = 5;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float playerDistance = 40f;
    private float _spawnTimer = 20f;
    private Transform _player;
    
    private void Start()
    {
        spawnPoints = new List<Transform>();
        foreach (Transform sp in spawnPointsParent) {
            spawnPoints.Add(sp);
        }
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update() {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0f) Spawn();
    }

    private void Spawn() {
        _spawnTimer = spawnInterval;
        int toSpawn = maxCount - transform.childCount;
        if (toSpawn == 0) return;
        spawnPoints.Shuffle();
        foreach (Transform spawnPoint in spawnPoints) {
            if (toSpawn == 0) return;
            if ((spawnPoint.position - _player.position).magnitude < playerDistance) continue;
            Instantiate(objectToSpawn, transform).transform.position = spawnPoint.position;
            toSpawn--;
        }
    }
}
