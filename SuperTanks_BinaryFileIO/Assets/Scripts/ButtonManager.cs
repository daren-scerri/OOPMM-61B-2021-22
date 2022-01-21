using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    [SerializeField] Button m_startButton, m_quitButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_startButton.onClick.AddListener(StartGame);
        m_quitButton.onClick.AddListener(QuitGame);
       
    }

    void StartGame()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("Game Started!");
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
    
        //Output this to console when Button1 is clicked
        Debug.Log("You have clicked the quit button!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif



    }


}
