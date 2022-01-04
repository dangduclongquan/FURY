using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public float speed
    {
        get
        {
            return rigidBody.velocity.magnitude;
        }
        set
        {
            rigidBody.velocity = rigidBody.transform.forward * value;
        }
    }
    float _damage;
    public float damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.collider.gameObject.GetComponent<Health>();
        if (health!=null)
        {
            health.DealDamage(damage);
        }
        Destroy(gameObject);
    }
}
