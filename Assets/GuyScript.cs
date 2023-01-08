using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyScript : MonoBehaviour
{
    public SpriteRenderer hat;
    Vector3 targ;
    public float speed;
    public GameObject plant;
    public GameObject poof;

    // Start is called before the first frame update
    void Start()
    {
        getTarget();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targ, speed *Time.deltaTime);

        if(targ == transform.position)
        {
            getTarget();
        }
    }

    public void WrongHit()
    {
        Destroy(gameObject);
        GameObject newPlant = Instantiate(plant, transform.position, Quaternion.identity);
        newPlant.GetComponent<SpriteRenderer>().sprite = hat.sprite;
        Instantiate(poof, newPlant.transform);
    }

    public void SetHat(Sprite spr)
    {
        hat.sprite = spr;
    }

    void getTarget()
    {
        targ = Random.insideUnitCircle * 6;
    }
}
