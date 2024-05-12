using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float offset;
    [SerializeField] float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        targetPos += target.up * offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * lerpSpeed);
    }
}
