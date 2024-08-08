using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject ShotLightPrefab;
    [SerializeField] GameObject FlarePrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform grenadeSpawn;
    [SerializeField] float TakeDamage;
    public float fireRate;
    [SerializeField] AudioSource src;
    [SerializeField] AudioSource src2;
    [SerializeField] AudioSource src3;
    [SerializeField] AudioSource src4;
    [SerializeField] AudioSource src5;
    [SerializeField] int maxAmmo = 15;
    [SerializeField] int currentAmmo;
    [SerializeField] int flaresAmmo = 3;
    [SerializeField] int currentFlares;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] float reloadTimer;
    [SerializeField] float powerUpTimer;
    float fireTimer;
    float reloadTiminginhopowerupinho = 2f;
    float PlayerSpeed;
    public float throwForce = 40f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpeed = speed;
        currentAmmo = maxAmmo;
        currentFlares = flaresAmmo;
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
        reloadTimer += Time.deltaTime;
        fireTimer += Time.deltaTime;
        if(reloadTimer > reloadTiminginhopowerupinho)
        {
            if(currentAmmo > 0)
            {
                if (Input.GetMouseButton(0))
                {
                    if(fireTimer >= fireRate)
                    {
                        src.Play();
                        Shoot();
                        fireTimer = 0;
                    }     
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if(fireTimer >= fireRate)
                    {
                        src2.Play();
                        fireTimer = 0;
                    }     
                }
            }
            if(Input.GetKey("r"))
            {
                src3.Play();
                StartCoroutine(Reload());
                return;
            }
        }
        if(Input.GetKeyDown("g") && currentFlares > 0)
        {
            src5.Play();
            currentFlares--;
            Grenade();
        }
        if(fireRate == 0.1f)
        {
            powerUpTimer += Time.deltaTime;
            if(powerUpTimer > 5)
            {
                print("devolvendo o fireratinho");
                fireRate = 0.3f;
                reloadTime = 2f;
                reloadTiminginhopowerupinho = 2f;
            }
        }
    }

    void Shoot()
    {
        GameObject ShotLight = Instantiate(ShotLightPrefab);
        GameObject bullet = Instantiate(bulletPrefab);
        currentAmmo--;
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.up = transform.up;
        Destroy(ShotLight, 0.1f);
        Destroy(bullet, 5);
    }

    void Grenade()
    {
        GameObject flare = Instantiate(FlarePrefab);
        flare.transform.position = grenadeSpawn.position;
        flare.transform.up = transform.up;
        //Rigidbody rb = flare.GetComponent<Rigidbody>();
        //rb.AddForce(transform.up * throwForce, ForceMode.VelocityChange);
    }

    IEnumerator Reload()
    {
        print("reloading...");
        reloadTimer = 0;
        yield return new WaitForSeconds(reloadTime);
        src4.Play();
        currentAmmo = maxAmmo;
    }

    void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal, vertical, 0).normalized * speed * Time.deltaTime;
        if (Input.GetKey("left shift"))
        {
            speed = 4f;
        }
        else
        {
            speed = PlayerSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            print("ME MORI AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            SceneManager.LoadScene(3);
        }
        if(collision.gameObject.CompareTag("Spikes"))
        {
            print("ME MORI AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            SceneManager.LoadScene(3);
        }
        if(collision.gameObject.CompareTag("Blob"))
        {
            print("Blob");
            SceneManager.LoadScene(4);
        }
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            print("seu triggereou o triggerinho");
            fireRate = 0.1f;
            reloadTime = 0.5f;
            reloadTiminginhopowerupinho = 0.5f;
            Destroy(collision.gameObject);
        }
    }
}
