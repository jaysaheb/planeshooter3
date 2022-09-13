using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerbullet;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public GameObject flash;
    public float bulletSpawnTime = 1f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
       
           
    }
    void Fire()
    {
        Instantiate(playerbullet, spawnpoint1.position, Quaternion.identity);
        Instantiate(playerbullet, spawnpoint2.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            flash.SetActive(false);
        }
    }
}
