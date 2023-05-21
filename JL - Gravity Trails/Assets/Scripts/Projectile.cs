using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Throwable direction;
    public float speed;
    public Teleport Teleport;

    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.FindGameObjectWithTag("Player").GetComponent<Throwable>();
        Teleport = GameObject.FindGameObjectWithTag("Exit").GetComponent<Teleport>();
        Invoke("DestroyThrowable", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.offset * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Teleport.enemyCount -= 1;
            Destroy(gameObject);
        }
    }
    private void DestroyThrowable()
    {
        Destroy(gameObject);
    }
}
