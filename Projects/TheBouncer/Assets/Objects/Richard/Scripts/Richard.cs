using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richard : MonoBehaviour {
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = new Vector2(128.0f, 128.0f);

	public float strength = 0.0f;


	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)) {
			Camera camera = GetComponentInChildren<Camera>();

			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)) {
				Debug.Log("" + hit.distance + hit.collider.gameObject.name);
				Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, 1.0f);

				if(hit.rigidbody != null) {
					hit.rigidbody.AddForceAtPosition(ray.direction * strength, hit.point, ForceMode.Impulse);
				}
			}
		}
	}
}
