using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition= Vector3.zero;  
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime<0)
        {
            Destroy(gameObject);
        }
    }
}
