using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;

	public void LoadLevel (int sceneIndex)
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	
	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		loadingScreen.SetActive(true);

		while (!operation.isDone) {
			yield return null;
		}
	}
}
