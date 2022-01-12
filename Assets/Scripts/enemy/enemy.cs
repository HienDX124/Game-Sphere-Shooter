﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    const string playerTag = "Player";
    const string bulletTag = "Bullet";

    public float minSpeed = 1.0f;
    public float maxSpeed = 6.0f;

    float speed;

    GameObject player;

    public GameObject enemyExplosionPrefab;

    AudioSource audioSource;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag(playerTag);
    }

    void FixedUpdate()
    {
        if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);

            scoreManager.instance.IncreaseScore(1);
        }
        if (col.gameObject.CompareTag(playerTag) ||
            col.gameObject.CompareTag(bulletTag))
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        GameObject explosionInstance = Instantiate(enemyExplosionPrefab, transform.position, enemyExplosionPrefab.transform.rotation);

        Destroy(explosionInstance, 5.0f);

        Transform trailRenderer = transform.GetChild(0);

        if (trailRenderer)
        {
            trailRenderer.parent = null;
            Destroy(trailRenderer.gameObject, trailRenderer.GetComponent<TrailRenderer>().time);
        }
        audioSource.Play();
        Destroy(this.gameObject);
    }
}