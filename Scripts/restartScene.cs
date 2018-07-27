using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour {

	// Use this for initialization
	public void OnClick () {
        SceneManager.LoadScene(0);
	}
}
