using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float bulletSpeed = 1000f;
    public float bulletDelay = 3f;
    public int bulletCount = 5;
    public Queue<GameObject> bulletPool;
    public Vector3 bulletVector;
    

    private void Pooling()
    {
        for(int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(0, 0, -10), Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }



    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletDelay);
            GameObject bullet = bulletPool.Dequeue();
            bulletPool.Enqueue(bullet);
            bullet.SetActive(true);
            bullet.transform.position = transform.position;

            float parentYRotation = transform.parent.rotation.eulerAngles.y;
            Debug.Log(parentYRotation);
            Quaternion newRotation = Quaternion.Euler(90, parentYRotation, 0); // Y축만 변경
            bullet.transform.rotation = newRotation;

            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        Pooling();
        StartCoroutine(ShootCoroutine());
    }
}
