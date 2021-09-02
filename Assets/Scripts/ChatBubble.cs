using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{

    
    public Vector2 padding = new Vector2(7f, 2f);
    public Vector3 offset = new Vector2(-0.5f, 0f);
    private SpriteRenderer BackgroundSpriteRenderer;
    private TextMeshPro textMeshPro;


    public static void Create(Transform parent, Vector3 localPosition, string text)
    {
        Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, parent);
        chatBubbleTransform.localPosition = localPosition;
        chatBubbleTransform.GetComponent<ChatBubble>().SetUpText(text);
        //TextMeshPro textBoxInstance = chatBubbleTransform.GetComponent<ChatBubble>().textMeshPro;
        //chatBubbleTransform.GetComponent<ChatBubble>().textWriter.AddWriter(textBoxInstance, text, 1f);
        //Destroy(chatBubbleTransform.gameObject, 4f);
        

    }
    public void DestroyText()
    {
        Destroy(textMeshPro.gameObject.transform.parent.gameObject);
    }
    private void Awake()
    {
        BackgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

    }


    private void SetUpText(string text)
    {
        
        
        textMeshPro.SetText(text);

        textMeshPro.renderer.enabled = false;
        textMeshPro.ForceMeshUpdate();

        textMeshPro.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 10f); ///////////
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        BackgroundSpriteRenderer.size = textSize + padding;
        BackgroundSpriteRenderer.transform.localPosition = new Vector3(BackgroundSpriteRenderer.size.x / 2f, 0f) + offset;
        TextWriter.AddWriter_static(textMeshPro, 0.1f, true,true);
    }
}
