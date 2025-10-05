using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterText : MonoBehaviour
{
    TMP_Text _tmpProText;
    string writer;

    Coroutine typingCoroutine;

    public bool isTyping { get; private set; }

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    // Use this for initialization
    void Awake()
    {
        _tmpProText = GetComponent<TMP_Text>()!;

        if (_tmpProText != null)
        {
            writer = _tmpProText.text;
            _tmpProText.text = "";
        }
    }

    IEnumerator TypeWriterTMP(string text)
    {
        isTyping = true;
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in text)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
        isTyping = false;
    }

    public void ShowText(string newText)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeWriterTMP(newText));
    }
}