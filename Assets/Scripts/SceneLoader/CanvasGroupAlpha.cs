using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupAlpha : MonoBehaviour
{
    public float m_fadeSpeed;
    public CanvasGroup m_canvasGroup;
    private bool m_fading = false;
    private bool m_fadingIn = false;
    public bool m_fadeComplete = false;

    private void Start()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Fade()
    {
        m_canvasGroup.alpha = 0;
        m_fading = true;
        m_fadeComplete = false;
        m_canvasGroup.blocksRaycasts = true;
    }
    public void FadeIn()
    {
        m_canvasGroup.alpha = 1;
        m_fadingIn = true;
        m_fadeComplete = false;
        m_canvasGroup.blocksRaycasts = true;
    }

    private void Update()
    {
        if (m_fading)
        {
            m_canvasGroup.alpha += Time.deltaTime * m_fadeSpeed;
            if (m_canvasGroup.alpha >= 1)
            {
                m_fading = false;
                m_fadeComplete = true;
            }
        }

        if (m_fadingIn)
        {
            m_canvasGroup.alpha -= Time.deltaTime * m_fadeSpeed;
            if (m_canvasGroup.alpha <= 0)
            {
                m_fadingIn = false;
                m_fadeComplete = true;
            }
        }
    }

}
