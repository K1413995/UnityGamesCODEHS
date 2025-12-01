using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectibleScript : MonoBehaviour {

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if(collectSound)
			{
				AudioSource.PlayClipAtPoint(collectSound, transform.position);
			}
			Destroy (gameObject);
		}
	}
}
