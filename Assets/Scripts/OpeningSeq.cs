using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OpeningSeq : MonoBehaviour
{
    public Texture imageToDisplay;
    public float timeToDisplayImage;
    public int nextLevelToLoad;

    private float timeForNextLevel;

    public void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeToDisplayImage);
        SceneManager.LoadScene(nextLevelToLoad);
    }

    //public void OnGUI()
    //{
    //    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
    //    if (Time.time >= timeForNextLevel)
    //    {
    //        SceneManager.LoadScene("Opening Scene");
    //    }
    //}
}