﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    public float speed;

    private Rigidbody2D bulletRigidbody;

	// Use this for initialization
	void Start ()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.up * speed;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Animator anim = other.GetComponent<Animator>();

        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            anim.SetBool("IsDead", true);
            other.gameObject.GetComponent<Rigidbody2D>().Sleep();
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            addPoints();
            DestroyObject(other.gameObject, 0.5f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void addPoints()
    {
        EnemyControl enemy = FindObjectOfType<EnemyControl>();
        GameControl.control.score += enemy.points;
    }
}
