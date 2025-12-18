using UnityEngine;

public class AutomousEnemy : MonoBehaviour
{
    public float moveForce = 50f;
    private Rigidbody rb;
    public float moveSpeed = -15f;
    public float randomMin = -20f;
    public float randomMax = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(randomMin, randomMax);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(0, rb.angularVelocity.y, moveSpeed);
    }
}
