using UnityEngine;

public class DragY : MonoBehaviour
{
	private bool mouseDownOnObject;
	void Update()
	{
		if(!mouseDownOnObject) return;
		
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		pos.x = transform.position.x;
		pos.z = 0;

		transform.position = pos;
	}

	private void OnMouseDown()
	{
		mouseDownOnObject = true;
	}

	private void OnMouseUp()
	{
		mouseDownOnObject = false;
	}
}