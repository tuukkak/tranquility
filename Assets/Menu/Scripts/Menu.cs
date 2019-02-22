using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button JoinButton;

    void Start()
    {
        JoinButton.onClick.AddListener(OnJoinClick);
    }

    void OnJoinClick()
    {
        Network.Join();
        JoinButton.GetComponentsInChildren<Text>()[0].text = "Looking for game...";
    }

    void Update()
    {
        if (!string.IsNullOrEmpty(Game.LoadScene))
        {
            SceneManager.LoadScene(Game.LoadScene);
            Game.LoadScene = "";
        }
    }
}
