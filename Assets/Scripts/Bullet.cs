using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float currentTime = 0f;
    public float lifeTime = 3f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ResetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void SetVelocity()
    {
        rb.linearVelocity = -transform.right * speed;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (currentTime >= lifeTime)
        {
            currentTime = 0f;
            ObjectPool.Instance.ReturnObject(this.gameObject);
        }
        currentTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ObjectPool.Instance.ReturnObject(this.gameObject);
    }
}
