using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richard : MonoBehaviour {
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(128.0f, 128.0f);

	public float strength = 0.0f;

	public float recoilStrength = 0.0f;
	public float recoilRadius = 0.0f;
	public float recoilUpwardsModifier = 0.0f;


	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)) {
			Camera camera = GetComponentInChildren<Camera>();

			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)) {
				// Throw target.
				if(hit.rigidbody != null) {
					hit.rigidbody.AddForceAtPosition(ray.direction * strength, hit.point, ForceMode.Impulse);
				}

				// Throw us.
				Rigidbody richardBuddy = GetComponent<Rigidbody>();

				richardBuddy.AddExplosionForce(recoilStrength, hit.point, recoilRadius, recoilUpwardsModifier, ForceMode.Impulse);
			}
		}
	}
}
