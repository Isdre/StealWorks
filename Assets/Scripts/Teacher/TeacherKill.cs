using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Teacher {
    public class TeacherKill : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float shotDistance = 3f;
        private TeacherMovement teacherMovement;
        [SerializeField] private int bulletPerShot = 5;
        private System.Random _rand;
        [SerializeField] private float reloadTime = 1f;
        private float reloadTimer = 0f;

        private void Awake() {
            teacherMovement = GetComponent<TeacherMovement>();
            _rand = new System.Random();
        }

        private void Update() {
            reloadTimer -= Time.deltaTime;
            if (teacherMovement.run) {
                Vector3 dS = GameObject.FindWithTag("Player").transform.position - transform.position;
                if (reloadTimer > 0f) return;
                if (dS.magnitude <= shotDistance) Shot(dS.normalized);
            }
        }

        private void Shot(Vector3 d) {
            for(int i=0;i<bulletPerShot;i++) {
                d += new Vector3((float)_rand.NextDouble(),(float)_rand.NextDouble(),0f) * 0.3f;
                TeacherBullet b = Instantiate(bullet,transform.position+d, Quaternion.identity).GetComponent<TeacherBullet>();
                b.Direction = d.normalized;
            }
            reloadTimer = reloadTime;
        }
    }
}