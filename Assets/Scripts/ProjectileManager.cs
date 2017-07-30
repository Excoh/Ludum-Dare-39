using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Transform bulletSpawnRotator;

	[Header("Properties")]
	[Range(0,90)]
	public float projectileAngleMaxRotation;
	public float bulletGravity;
	public float timeToReachTop; 
	public Vector3 originalRot;

	// Use this for initialization
	void Start () {
		//originalRot = bulletSpawnRotator.transform.eulerAngles;
	}

	
	// Update is called once per frame
	void Update () {
		//bulletSpawn.LookAt(Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
		if (Physics.Raycast(ray, out hit))
		{
			DebugWindow.instance.LogHitInfo(hit);
		}
		DebugWindow.instance.LogMousePos(Input.mousePosition.x, Input.mousePosition.y);

	}

	public void Shoot()
	{
		GameObject go = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity) as GameObject;
		Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25)); // distance from the camera is the z position!!!!!!!!!!!!!!!!!

		Debug.Log("Target: " + target);
		go.transform.LookAt(target);
	}

}
