using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T:MonoBehaviour {
	static T instance;
	static bool applicationIsQuitting = false;
	public static T Instance{
		get{
			if (applicationIsQuitting) {
				//Instance already destroyed won't create again.
				return null;
			}
			lock (_lock) {
				T[] instances = FindObjectsOfType<T> ();
				if (instance == null) {
					instance = instances[0];
				}
				if (instances.Length > 1) {
					for (int i = 1; i < instances.Length - 1; i++) {
						Destroy (instances [i]);
					}
				}

				return instance;
			}
			
		}
	}
	static object _lock = new object();

	void OnDestroy(){
		applicationIsQuitting = false;
	}
}
