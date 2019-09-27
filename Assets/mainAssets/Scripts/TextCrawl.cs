using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCrawl : MonoBehaviour
{

    public float delay = 0.1f;
    public float time = 5f;
    public float xPos = 0f;
    public float yPos = 0f;
    public string fullText;
    public Animator animator;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xPos, yPos, 0f);
    }

    public void StartText()
    {
        StartCoroutine(ShowText());
        StartCoroutine(FadeOutTime());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator FadeOutTime()
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("FadeOut", true);

    }

}
