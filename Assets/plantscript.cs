using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantscript : MonoBehaviour
{
    bool picked = false;
    public GameObject guy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plantfound()
    {
        Debug.Log("Hit!");
        if(picked)
        {
            Debug.Log("Found Me!");
            Destroy(gameObject);
            GameObject newGuy = Instantiate(guy, transform.position, Quaternion.identity);
            newGuy.GetComponent<GuyScript>().SetHat(GetComponent<SpriteRenderer>().sprite);
        }
    }

    public void pickplant()
    {
        picked = true;  
    }

}
