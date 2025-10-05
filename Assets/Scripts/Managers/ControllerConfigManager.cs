using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerConfigManager : MonoBehaviour
{
    public static ControllerConfigManager instance;
    [SerializeField] private ControllerType controllerType;
    private Dropdown controllerDropdown;
    [SerializeField] private List<Button> options;

    void Start()
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
        // SetupDropdown();
    }

    public void SetController(ControllerType type)
    {
        controllerType = type;
    }

    public void DisableAllButtonExcept(int index)
    {
        var type = (ControllerType)index;
        foreach (var button in options)
        {
            button.interactable = false;
            if (button.GetComponentInChildren<TextMeshProUGUI>().text == type.ToString())
            {
                Debug.Log(button.GetComponentInChildren<TextMeshProUGUI>().text);
                button.interactable = true;
            }
        }
    }
    
    public void EnableAllButtonExcept(int index)
    {
        var type = (ControllerType)index;
        foreach (var button in options)
        {
            button.interactable = true;
            if (button.GetComponentInChildren<TextMeshProUGUI>().text != type.ToString()) continue;
            controllerType = type;
            button.interactable = false;
        }
    }

    public void SetupDropdown()
    {
        controllerDropdown.ClearOptions();
        var options = System.Enum.GetNames(typeof(ControllerType));
        controllerDropdown.AddOptions(new System.Collections.Generic.List<string>(options));
        controllerDropdown.value = (int)controllerType;
        controllerDropdown.RefreshShownValue();
    }

    public void SelectController(ControllerType type)
    {
        controllerType = type;
    }

    public ControllerType GetControllerType()
    {
        return controllerType;
    }
}

public enum ControllerType
{
    Keyboard,
    Mouse,
}