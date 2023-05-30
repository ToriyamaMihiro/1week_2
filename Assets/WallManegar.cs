using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManegar : MonoBehaviour
{
    public GameObject RightWallPrefab;
    public GameObject LeftWallPrefab;
    public GameObject UPWallPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(RightWallPrefab, new Vector3(15, 0, 0), Quaternion.identity);
        Instantiate(LeftWallPrefab, new Vector3(-15, 0, 0), Quaternion.identity);
        Instantiate(UPWallPrefab, new Vector3(0,7.5f, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
