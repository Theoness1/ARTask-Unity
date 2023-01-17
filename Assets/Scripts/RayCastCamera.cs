using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastCamera : MonoBehaviour
{

    [SerializeField] private Button _useButton;
    public Ray Rays 
    { 
        get
        {
            Ray Rays = new (transform.position, transform.forward);
            return Rays;
        }
    }

    private void Update()
    {
        OnRayHit(Rays);
    }

    public void OnRayHit(Ray ray)
    {
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
        if (Physics.Raycast(ray))
        {
            _useButton.gameObject.SetActive(true);
        }
        else
            _useButton.gameObject.SetActive(false);
    }
}
