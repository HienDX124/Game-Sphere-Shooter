using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;

public class bulletSystem : MonoBehaviour
{
    private GameObject gunActive;
    private Transform bulletEnd;
    public Rigidbody bulletPrefab;

    public float force;
    public float delay;

    public SO_bulletDetailsList so_BulletDetailsList;
    private bulletDetails bullet;

    float currentTime;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetBulletDetails();
        bulletEnd = gunActive.transform.GetChild(0);
    }

    private void SetBulletDetails()
    {
        if (GunManager.instance.gun1.activeInHierarchy)
        {
            gunActive = GunManager.instance.gun1;
            bullet = so_BulletDetailsList.GetBulletDetailsByName("BulletCannon");
        }
        else
        {
            gunActive = GunManager.instance.gun2;
            bullet = so_BulletDetailsList.GetBulletDetailsByName("BulletSMG");
        }
    }

    void FixedUpdate()
    {
        SetBulletDetails();
        if (((Mathf.Abs(SimpleInput.GetAxisRaw("MouseX")) > 0.75f) ||
             (Mathf.Abs(SimpleInput.GetAxisRaw("MouseY")) > 0.75f)) &&
        ((Time.time - currentTime > bullet.delay) || (currentTime < 0.01f)))
        {
            currentTime = Time.time;
            audioSource.Play();

            GameObject bulletInstance = Instantiate(bullet.bulletPrefab, bulletEnd.position, bulletEnd.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(bulletEnd.forward * force);
        }
    }
}
