using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float countdown = 3;
    public bool hasExploded = false;
    public GameObject FlareLight;
    public float throwForce = 40f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
        if(speed > 0)
        {
            speed -= 0.05f;
        }
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        print("boomm");
        FlareLight.SetActive(true);
        Destroy(FlareLight, 30);
    }
}
