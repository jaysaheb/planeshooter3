using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public Transform[] gunpoint;
    public GameObject enemyBullet;
    public GameObject enemyFlash;
    public GameObject enemyExplosionPrefeb;
    public healthbar healthbar;
    public GameObject DamageEffect;
    public float speed = 1f;
    public float health = 10f;
    public GameObject coinPrefab;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;

    float barSize = 1f;
    float damage = 0;
    public float EnemyBulletSpawnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="playerbullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthbar();
            Destroy(collision.gameObject);
          GameObject damageVfx=Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVfx, 0.05f);
            if (health<=0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefeb, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.4f);
            }
            
        }
    }
    void DamageHealthbar()
    {
        if (health>0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthbar.SetSize(barSize);
        }
    }
    void EnemyFire()
    {
        for (int i =0; i < gunpoint.Length; i++)
        {
            Instantiate(enemyBullet, gunpoint[i].position, Quaternion.identity);
        }
        //Instantiate(enemyBullet, gunpoint1. position, Quaternion.identity);
       // Instantiate(enemyBullet, gunpoint2.position, Quaternion.identity);
    }
    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(EnemyBulletSpawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false);
        }
       
    }
}
