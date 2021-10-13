﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p8BallController : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
    public float speed = 5f;
    private Vector3 target;
    public string tagName;
    public Text Textscore;
    private int scores = 0;
    public GameObject spanw;
    public float x;
    public float y;
    public static GameObject sprefab;
 
    void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
        target = transform.position;
    }
     
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }    
    
    void OnCollisionEnter2D(Collision2D myCol) { 
		if (myCol.gameObject.tag == tagName) {
			Destroy(myCol.gameObject); 
            scores = scores + 1;
            Textscore.text = scores.ToString ("0")+" "+"score"; 
            StartCoroutine(delaySpawn(3f));
		}	
	}

    IEnumerator delaySpawn(float s)
    {
		yield return new WaitForSeconds(s);
        p8spawner.spawnagain(spanw,x,y);
	}
}
