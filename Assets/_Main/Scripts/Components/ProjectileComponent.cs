using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionParticle;
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionParticle,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
