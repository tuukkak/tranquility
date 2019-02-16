using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField NameField;
    public Button LoginButton;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(OnLoginClick);
    }

    void OnLoginClick()
    {

        Network.Login(NameField.text);
        //SceneManager.LoadScene("GameScene");
    }
}
