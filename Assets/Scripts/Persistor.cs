using UnityEngine;

/*
 * @author: Philipp Rösner
 * @date: 2017
 */

/*
 * @description: Makes an object persistable when the scene is changed, so it wont be destroyed like normaly
 */

public class Persistor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
}
