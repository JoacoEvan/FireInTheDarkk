using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;
using UnityEditor.SceneManagement;

public class Meleeenemyguard : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] int hp;
    public Transform Target;
    AIPath aipath;
    float distance;
    [SerializeField] Sprite deadSprite;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject DeadEnemy;

    private void Start()
    {
        aipath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp > 0)
        {
            aipath = GetComponent<AIPath>();
            distance = Vector2.Distance(transform.position, Target.transform.position);
            if (distance < sightRange)
            {
                aipath.canMove = true;
            }
            else
            {
                aipath.canMove = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //rend.sprite = deadSprite;
            aipath.canMove = false;
            DeadEnemy.SetActive(true);
            Enemy.SetActive(false);
            //Destroy (gameObject);
        }
    }

}
