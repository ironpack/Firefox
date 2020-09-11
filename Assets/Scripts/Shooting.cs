using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet;
    public Transform spawnLocation;
    public float fireRate;
    private float Timer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Timer < 0)
        {
            bullet = Instantiate(bulletPrefab, spawnLocation.position, spawnLocation.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnLocation.up * 10;
            Timer=fireRate;
        }
        Timer -= Time.deltaTime;
    }
}
