using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public float size = 0.2f;
	public int row = 5;
	public int explosionForce = 100;
	public int explosionRadius = 2;
	public float explosionUpward = 0.4f;
	private float pivotDistance;
	private Vector3 pivot;
	void Start()
	{
		pivotDistance = size * row / 2;
		pivot = new Vector3(pivotDistance, pivotDistance, pivotDistance);
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.transform.CompareTag("Bullet"))
		{
			for (int x = 0; x < row; x++)
			{
				for (int y = 0; y < row; y++)
				{
					for (int z = 0; z < row; z++)
					{
						CreatePrim(x, y, z);
					}
				}
			}
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
			foreach (Collider item in colliders)
			{
				Rigidbody rb = item.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
				}
			}
			Explode();
		}
	}
	private void Explode()
	{
		Destroy(gameObject);
	}

	private void CreatePrim(int x, int y, int z)
	{
		GameObject prim;
		prim = GameObject.CreatePrimitive(PrimitiveType.Cube);
		prim.transform.position = transform.position + new Vector3(size * x, size * y, size * z) - pivot;
		prim.transform.localScale = new Vector3(size, size, size);
		prim.AddComponent<Rigidbody>().mass = size;
	}
}
