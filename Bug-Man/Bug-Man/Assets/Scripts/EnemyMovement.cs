
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float xEnd = 10f;

    private float zStart;

    private void Start()
    {
        zStart = transform.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, xEnd) + zStart, transform.position.z);

    }

    private void OnCollisionEnter3D(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }






}
