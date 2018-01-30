
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float xEnd = 3f;

    private float xStart;

    private void Start()
    {
        xStart = transform.position.x;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, xEnd) + xStart, transform.position.y);

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
