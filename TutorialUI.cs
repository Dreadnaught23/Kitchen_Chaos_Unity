using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUP;
    [SerializeField] private TextMeshProUGUI keyMoveDOWN;
    [SerializeField] private TextMeshProUGUI keyMoveLEFT;
    [SerializeField] private TextMeshProUGUI keyMoveRIGHT;
    [SerializeField] private TextMeshProUGUI interact;
    [SerializeField] private TextMeshProUGUI interactALt;
    [SerializeField] private TextMeshProUGUI pause;


    private void Start()
    {
        GameInput.Instance.onBindingRebind += GameInput_onBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateVisual();

        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.IsCountdownToStartActive()){
            Hide();
        }
    }

    private void GameInput_onBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUP.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDOWN.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLEFT.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRIGHT.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interact.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactALt.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        pause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
