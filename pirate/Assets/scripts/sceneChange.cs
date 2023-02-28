using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    AudioSource audioSource;
    string sceneName;
    public AudioClip clip;
    bool clicked = false;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(audioSource != null)
        {
            if (clicked && !audioSource.isPlaying)
                SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (clicked)
                SceneManager.LoadScene(sceneName);
        }
        
    }
    public void changeScene(string name)//for the ui buttons
    {
        //playOnce temp = gameObject.GetComponent<playOnce>();
        sceneName = name;
        if(audioSource != null)
            audioSource.PlayOneShot(clip);
        clicked = true;
    }
}
