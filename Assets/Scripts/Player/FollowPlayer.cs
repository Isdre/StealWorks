using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Transform _camera;
    private Transform _player;

    private void Start()
    {
        _camera = transform;
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        _camera.position = _player.position + offset;
    }
}
}