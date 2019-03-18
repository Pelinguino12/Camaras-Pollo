using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo : MonoBehaviour {
	
	[SerializeField] int force = 100;
	private Rigidbody rb;
	bool tocoSuelo = true;
	[SerializeField] Transform posicionPies;
	float distanciaDeteccion = 0.1f;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	bool EstoyEnElSuelo ()
	{
		int layer = LayerMask.GetMask ("Terreno");
		tocoSuelo = Physics.CheckSphere (posicionPies.position, distanciaDeteccion, layer);
		return tocoSuelo;
	}
	// Update is called once per frame
	void Update ()
	{
		if (EstoyEnElSuelo ())
		{
			if (Input.GetKeyDown("up"))
			{
				rb.AddForce(new Vector3(0, 1, 1) * force);
			}
			if (Input.GetKeyDown("down"))
			{
				rb.AddForce(new Vector3(0, 1, -1) * force);
			}
			if (Input.GetKeyDown("left"))
			{
				rb.AddForce(new Vector3(-1, 1, 0) * force);
			}
			if (Input.GetKeyDown("right"))
			{
				rb.AddForce(new Vector3(1, 1, 0) * force);
			}
		}
	}
}
