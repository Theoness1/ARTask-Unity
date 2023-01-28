using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOutline : MonoBehaviour
{
    [SerializeField] private RayCastCamera _rayCastCamera;
    private Outline _outline;
    private GameObject _currentGo;
    private void Update()
    {
        OutlineObject();
    }

    private void AddOutline(GameObject gameObject)
    {
        if (_currentGo != gameObject)
        {
            ClearOutline();
            _outline = gameObject.GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineVisible;
            _currentGo = gameObject;
        }

    }

    private void ClearOutline()
    {
        if (_currentGo != null)
        {
            _outline = _currentGo.GetComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
            _currentGo = null;
        }
    }

    private void OutlineObject()
    {
        if (Physics.Raycast(_rayCastCamera.Rays, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Outline _))
            {
                GameObject hitObject = hit.collider.gameObject;
                AddOutline(hitObject);
            }
        }
        else
        {
            ClearOutline();
        }
    }


}
