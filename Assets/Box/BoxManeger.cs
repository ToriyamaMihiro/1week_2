using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManeger : MonoBehaviour
{
    public GameObject BoxPrefab;
    private string floorTag = "Floor";

    Rigidbody2D r;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        r = gameObject.GetComponent<Rigidbody2D>();
        Instantiate(BoxPrefab, new Vector3(5, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            r.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            r.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    void OnTriggerEnter2D(Collider2D floor)
    {
        if (floor.tag == floorTag)
        {
            isHit = true;
        }
    }

    void OnTriggerExit2D(Collider2D floor)
    {
        if (floor.tag == floorTag)
        {
            isHit = false;
        }
    }
}
