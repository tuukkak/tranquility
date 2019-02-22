using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField NameField;
    public Button LoginButton;

    void Start()
    {
        LoginButton.onClick.AddListener(OnLoginClick);
    }

    void OnLoginClick()
    {
        Network.Login(NameField.text);
    }

    void Update()
    {
        if (!string.IsNullOrEmpty(Game.LoadScene)) {
            SceneManager.LoadScene(Game.LoadScene);
            Game.LoadScene = "";
        }
    }
}
