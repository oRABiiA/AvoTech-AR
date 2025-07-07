using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject optionsModal;
    public GameObject optionsButton;

    public void showOptionsbutton()
    {
        optionsButton.SetActive(true);
    }

    public void hideOptionsbutton()
    {
        optionsButton.SetActive(false);
    }

    public void CloseOptionsModal()
    {
        if (optionsModal != null)
        {
            optionsModal.SetActive(false);
        }
    }
}
