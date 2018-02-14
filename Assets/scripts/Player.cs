using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
		animator.Play ("flying");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.back * (2 * Time.deltaTime));

	}
}
