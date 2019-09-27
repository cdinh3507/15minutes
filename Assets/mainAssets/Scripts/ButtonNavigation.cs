using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNavigation : MonoBehaviour
{
    int index = 0;
    public int totalLevels = 2;
    public float yOffset = 100f;
    //float Xpos, Ypos;
    RectTransform m_RectTransform;
    public GameObject pauseUI;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        m_RectTransform = GetComponent<RectTransform>();
        active = false;
        //Xpos = m_RectTransform.anchoredPosition.x;
        //Ypos = m_RectTransform.anchoredPosition.y;


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GO.activeSelf && !active)
        {
            active = true;
            index = 0;
            m_RectTransform.anchoredPosition = new Vector2(Xpos, Ypos);
        }

        if (!GO.activeSelf)
        {

            active = false;

        }*/
            if (Input.GetButtonDown("Crouch"))
        {
            if (index < totalLevels - 1)
            {
                index++;

                m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x, m_RectTransform.anchoredPosition.y - yOffset);

            }
        } 

        if (Input.GetButtonDown("Up"))
        {
            if (index > 0)
            {
                index--;

                m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x, m_RectTransform.anchoredPosition.y + yOffset);

            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            //resume case
            if (index == 0)
            {
                pauseUI.GetComponent<PauseMenu>().Resume();

            }
            else 
            //quit case
            if (index == 1)
            {

            }
        }

    }
}
