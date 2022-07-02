using TMPro;
using UnityEngine;

public class NewsBoard : MonoBehaviour
{
    public TMP_Text titleTMP;
    public TMP_Text contentTMP;
    public TMP_Text markerNameTMP;

    private string title;
    private string content;
    private bool currentState;

    private void Awake()
    {
        SetState(false);
    }
    public void SetContent(string _title, string _content)
    {
        title = _title;
        titleTMP.text = title;
        content = _content;
        contentTMP.text = content;
    }
    public void ToggleState()
    {
        SetState(!currentState);
    }

    private void SetState(bool state)
    {
        currentState = state;
        gameObject.SetActive(currentState);
    }
}
