using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPhysicsSimple : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
	bool pointer = false;
	float timer = 0;
	public int direction = 1;

	public void OnPointerDown (PointerEventData eventData)
	{
		print ("dcm mm");
		pointer = true;
		timer = 0;
		TdzInputManager.horizontal = timer;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		pointer = false;
		timer = 0;
		TdzInputManager.horizontal = timer;
	}

	void Update ()
	{
		if (pointer) {
			timer += Time.unscaledDeltaTime;
			timer = Mathf.Clamp (timer, 0, 1F * direction);
			TdzInputManager.horizontal = timer;
		}
	}
}
