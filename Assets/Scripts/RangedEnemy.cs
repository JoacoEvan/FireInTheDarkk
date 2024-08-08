using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] float sightRange;
    [SerializeField] int hp;
    [SerializeField] Sprite deadSprite;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject DeadEnemy;
    [SerializeField] GameObject Triggerinho;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform player;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= range)
        {
            transform.up = (player.position - transform.position).normalized;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //rend.sprite = deadSprite;
            DeadEnemy.SetActive(true);
            Enemy.SetActive(false);
            Triggerinho.SetActive(false);
            //Destroy (gameObject);
        }
    }
}
