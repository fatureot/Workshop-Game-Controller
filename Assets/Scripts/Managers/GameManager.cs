using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Instance
    public static GameManager instance;
    public bool isGameStarted = false;
    public Button startButton;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ControllerSelected()
    {
        startButton.interactable = true;
    }

    public void StartGame()
    {
        isGameStarted = true;
        playerMovement.ResetPlayer();
        Debug.Log("The controller selected are " + ControllerConfigManager.instance.GetControllerType());
    }
}