using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
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
                    crosshair.sprite = interact_crosshair;
                    crosshair.rectTransform.localScale = new Vector2(1, 1);
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
