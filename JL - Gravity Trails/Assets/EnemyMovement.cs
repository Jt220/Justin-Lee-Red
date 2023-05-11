using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float yForce;
    public float maximumXPosition;
    public float minimumXPosition;
    public float speed;
    private Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Vector2 jumpForce = new Vector2(0, yForce);
            enemyRigidBody.AddForce(jumpForce);
        }
    }

    private void FixedUpdate()
    {
        float newXPosition = transform.position.x + speed * Time.deltaTime;
        float newYPosition = transform.position.y;
        float newZPosition = -2f;
        Vector3 newPosition = new Vector3(newXPosition, newYPosition, newZPosition);
        transform.position = newPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= minimumXPosition)
        {
            speed = Mathf.Abs(speed);
        }
        if(transform.position.x >= maximumXPosition)
        {
            speed = Mathf.Abs(speed) * -1;
        }
    }
}
