using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour
{
    [SerializeField] GameObject NightLightPrefab;
    [SerializeField] float nightvisionTimer;
    [SerializeField] float nightvisionDuration;
    [SerializeField] float nightvisionRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nightvisionTimer += Time.deltaTime;
        if (nightvisionTimer > nightvisionRate)
        {
            if (Input.GetKeyDown("f"))
            {
                Vizzionne();
                nightvisionTimer = 0;
            }
        }
    }

    void Vizzionne()
    {
        GameObject nightlight = Instantiate(NightLightPrefab);
        Destroy(nightlight, nightvisionDuration);
    }
}
