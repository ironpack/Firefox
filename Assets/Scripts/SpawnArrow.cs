using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject [] locations;
    public int location;

    void Spawn()
    {
        Instantiate(arrowPrefab, transform.position + new Vector3(0,3,1), Quaternion.identity);
    }
}
