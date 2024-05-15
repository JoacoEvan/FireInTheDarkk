using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject ShotLightPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float TakeDamage;
    [SerializeField] float fireRate;
    float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Obtenemos la posicion del mouse con Input.mousePosition
        //Unity separa entre el espacio de la pantalla y el del mundo
        //Para traducir de uno a otro usamos ScreenToWorldPoint, con la Main Camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //El sprite del target va a estar en la posicion
        target.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        transform.up = (target.position - transform.position).normalized;

        fireTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0;
            }     
        }
    }

    void Shoot()
    {
        GameObject ShotLight = Instantiate(ShotLightPrefab);
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.up = transform.up;
        Destroy(ShotLight, 0.1f);
        Destroy(bullet, 5);
    }

    void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, vertical, 0).normalized * speed * Time.deltaTime;
    }
}
