using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    [SerializeField] private RayCastCamera _rayCastCamera;
    [SerializeField] private TextMeshPro _text;

    public void OnClick()
    {
        if(Physics.Raycast(_rayCastCamera.Rays, out RaycastHit hit))
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            hit.collider.gameObject.GetComponent<Renderer>().material.color = color;

            if (hit.collider.gameObject.GetComponent<TextMeshPro>())
            {
                _text.color = color;
            }
        }
    }
}
