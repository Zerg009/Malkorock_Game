using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterAnimation : MonoBehaviour
{
    
    [SerializeField]
    public float typingSpeed = 0.05f;

    private TextMeshProUGUI textMeshPro;
    private string currentText = "";
    private string fullText;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
            fullText = textMeshPro.text;
        else
            fullText = "";
    }

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
