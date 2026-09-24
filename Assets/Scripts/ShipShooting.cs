using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawner;
    public float fireRate = 1f;
    public float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.targetVector = transform.right;
    }
}
