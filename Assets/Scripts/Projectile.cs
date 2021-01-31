using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy;

        if (enemy = collision.transform.root.GetComponent<Enemy>())
        {
            enemy.GotHit();
        }
    }
}
