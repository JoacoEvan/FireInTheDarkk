using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
        } 
        Destroy(gameObject);

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        } 
        Destroy(gameObject);

    }
   
}
