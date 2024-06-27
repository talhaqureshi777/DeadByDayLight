using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource BackGroungSound;
    public GameObject MainMenuPanal;
    // Start is called before the first frame update
    void Start()
    {
        BackGroungSound.Play();
        MainMenuPanal.SetActive(true);
    }
    


    public void OnPlaybtnClicked()
    {
        SceneManager.LoadScene(1); 
    }


    public void OnQuitBtnClicked()
    {
       Application.Quit();
    }
    
}
