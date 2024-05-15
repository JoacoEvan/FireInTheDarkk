using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] Transform Target;
    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] Transform[] waypoints;
    [SerializeField] int currentwaypoints;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) <= sightRange)
        {
            transform.up = (Target.position - transform.position).normalized;
            canMove = true;
        }
        else if (waypoints.Length > 0)
        {
            if (Vector3.Distance(transform.position, waypoints[currentwaypoints].position) <= 0.03f)
            {
                currentwaypoints++;
                if(currentwaypoints >= waypoints.Length)
                {
                    currentwaypoints = 0;
                }
            }
            transform.up = (waypoints[currentwaypoints].position - transform.position). normalized;
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("El enemigo ha muerto");
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
