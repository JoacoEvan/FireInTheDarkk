using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float spikeTimer;
    public GameObject spikesOff;
    public GameObject spikesOn;
    // Start is called before the first frame update
    void Start()
    {
        spikeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spikeTimer += Time.deltaTime;
        if(spikeTimer > 3 && spikeTimer < 6)
        {
            TurnOn();
        }
        if(spikeTimer > 6)
        {
            spikeTimer = 0;
            TurnOff();
        }
    }

    void TurnOn()
    {
        spikesOff.SetActive(false);
        spikesOn.SetActive(true);
    }

    void TurnOff()
    {
        spikesOn.SetActive(false);
        spikesOff.SetActive(true);
    }
}
