using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class UIOnHoverItem : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] Image sprite;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject button;
    [SerializeField] bool inGame;

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.parent = parent.transform;
        gameObject.SetActive(false);
    }

    public void SetUI(Sprite sprite, string text, string description)
    {
        if (inGame)
        {
            button.SetActive(false);
        }
        this.sprite.sprite = sprite;
        textMesh.text = text;
        this.description.text = description;
    }
}
