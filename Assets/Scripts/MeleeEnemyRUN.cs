using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Meleeenemyguard : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] int hp;
    public Transform Target;
    Pathfinding.AIPath aipath;
    float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Target.transform.position);
        if(distance < sightRange)
        {
            aipath.canMove = true;
        }
        else
        {
            aipath.canMove = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy (gameObject);
        }
    }

}
