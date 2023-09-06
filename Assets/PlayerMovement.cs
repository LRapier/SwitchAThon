using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    Renderer rend;
    public GameObject player;
    public float forwardForce = 2000f;
    public float sideForce = 3000f;

    public bool polarity = true;
    public Material posMat;
    public Material negMat;
    public int posLayer;
    public int negLayer;

    void Start()
    {
        rend = GetComponent<Renderer>();
        posLayer = LayerMask.NameToLayer("Positive");
        negLayer = LayerMask.NameToLayer("Negative");
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            if (polarity)
            {
                polarity = false;
                rend.sharedMaterial = negMat;
                player.layer = negLayer;
            }
            else
            {
                polarity = true;
                rend.sharedMaterial = posMat;
                player.layer = posLayer;
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
