using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float dashSpeed = 10.5f;
    public float speed = 5.5f;
    Vector3 movement;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    public string respawnScene;
    public string nextLevelScene;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(respawnScene);
        }
        if (collision.gameObject.tag == "Goal")
        {
            Invoke("NextScene", 2);
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        if (Input.GetButtonDown("space"))
        {
            movement = movement.normalized * dashSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
        }

        else
        {
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition(transform.position + movement);
        }
    }
        void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    void NextScene ()
    {
        SceneManager.LoadScene(nextLevelScene);
    }
}
