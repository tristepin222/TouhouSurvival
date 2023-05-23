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
    [SerializeField] GameObject parent;

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.parent = parent.transform;
        gameObject.SetActive(false);
    }

    public void SetUI(Sprite sprite, string text)
    {
        this.sprite.sprite = sprite;
        textMesh.text = text;
    }
}
