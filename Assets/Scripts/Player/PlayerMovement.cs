using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform _transform;

    private void Start() {
        _transform = transform;
    }

    private void Update(){
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f).normalized;
        _transform.position += direction * Time.deltaTime;
    }
}
}