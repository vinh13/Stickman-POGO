using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour
{
	[Header ("Verticle")]
	public bool isVerticle = false;
	public RectTransform rectContent;
	public float min, max;
	public float scrollBarValue = 0;
	public float scrollBarSize = 0;
	void Start ()
	{
	}
	void Update ()
	{
		if (isVerticle) {
			rectContent.localPosition = new Vector3 (this.rectContent.localPosition.x,
				Mathf.Clamp (this.rectContent.localPosition.y, min, max),
				this.rectContent.localPosition.z);


			scrollBarValue = this.rectContent.localPosition.y / max;
		} else {
			rectContent.localPosition = new Vector3 (Mathf.Clamp (this.rectContent.localPosition.x, min, max),
				this.rectContent.localPosition.y,
				this.rectContent.localPosition.z);
			scrollBarValue = this.rectContent.localPosition.x / min;
		}
	}
}
