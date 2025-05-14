using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody _rb;
    private Vector3 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        PickRandomDirection();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        _direction = Vector3.Reflect(_direction, normal).normalized;
    }

    private void PickRandomDirection()
    {
        _direction = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
    }
}