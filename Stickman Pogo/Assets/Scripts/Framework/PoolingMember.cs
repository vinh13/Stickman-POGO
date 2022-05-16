using UnityEngine;
using System.Collections;

namespace TungDz
{
	public class PoolingMember : MonoBehaviour
	{
		public Pooling pooling;

		void OnDisable ()
		{  
			pooling.nextThing = gameObject;  
		}
	}
}
