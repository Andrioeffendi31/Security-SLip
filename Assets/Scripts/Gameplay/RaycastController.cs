using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    private readonly Color COLOR_ALLOW_ENTRY = new Color32(125, 221, 49, 255);
    private readonly Color COLOR_DENY_ENTRY = new Color32(221, 82, 49, 255);
    private readonly Color COLOR_DEFAULT = new Color32(0, 0, 0, 255);

    [SerializeField]
    private GameObject tooltip;

    [SerializeField]
    private Text tooltip_text;

    private Ray ray;
    private RaycastHit hit;
    private Transform _selection;

    public Image crosshair;
    public Sprite normal_crosshair, interact_crosshair;

    private void Update()
    {
        Raycast();
    }

    public void Raycast()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 300f, Color.blue);
        Highlighter();
    }

    public void Highlighter()
    {
        if (_selection != null)
        {
            tooltip.SetActive(false);
            crosshair.sprite = normal_crosshair;
            crosshair.rectTransform.localScale = new Vector2(0.3f, 0.3f);
            _selection = null;
        }

        if (Physics.Raycast(ray, out hit))
        {
            Transform selection = hit.transform;
            
            if (selection.tag == "Interactable")
            {
                if (selection != null)
                {
                    if (selection.name == "Approve")
                    {
                        tooltip.SetActive(true);
                        tooltip_text.text = "Allow Entry";
                        tooltip_text.color = COLOR_ALLOW_ENTRY;
                    }

                    if (selection.name == "Reject")
                    {
                        tooltip.SetActive(true);
                        tooltip_text.text = "Deny Entry";
                        tooltip_text.color = COLOR_DENY_ENTRY;
                    }

                    if (selection.name == "Computer")
                    {
                        tooltip.SetActive(true);
                        tooltip_text.text = "Open Computer";
                        tooltip_text.color = COLOR_DEFAULT;
                    }

                    crosshair.sprite = interact_crosshair;
                    crosshair.rectTransform.localScale = new Vector2(1, 1);
                }

                _selection = selection;
            }
        }
    }

    public string GetObjectOnRaycastName()
    {
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.name;
        } else
        {
            return null;
        }      
    }
}
