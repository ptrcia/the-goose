using System;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip[] sounds;
    AudioClip clip;

    [Header("Raycast")]
    Ray ray;
    RaycastHit hit; 
    [SerializeField]
    LayerMask ignoreLayer;
 
    bool isClicked;
    private void Update()
    {
        Debug.Log("Is clicled? ---> "+isClicked);
        Check3DObjectClicked();
    }
    #region Audio OnClick
    /*
    private void OnMouseDown()
    {
        isClicked = true;
        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        AudioManager.instance.PlaySound(clip);


        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
    }*/
    #endregion

    #region Raycast

    public void Check3DObjectClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is pressed down");

            int layerMask = ~ignoreLayer.value;

            hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("Object Hit is " + hit.collider.gameObject.name);

                //If you want it to only detect some certain game object it hits, you can do that here
                if (hit.collider.gameObject.CompareTag("Duck"))
                {
                    Debug.Log("Duck hit");
                    isClicked = true;
                    clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
                    AudioManager.instance.PlaySound(clip);

                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
                }
            }

        }
    }
    #endregion
}
