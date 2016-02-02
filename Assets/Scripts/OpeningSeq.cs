using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OpeningSeq : MonoBehaviour
{
    public float timeToDisplayImage;
    public int nextLevelToLoad;

    void Update() {
        if ((0 >= (timeToDisplayImage -= Time.deltaTime)) ||
            (Input.GetKeyDown(KeyCode.Return))) {
            SceneManager.LoadScene(nextLevelToLoad);
        }
        
    }
}