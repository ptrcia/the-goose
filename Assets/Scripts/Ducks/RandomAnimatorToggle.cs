using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorToggle : MonoBehaviour
{
    public float minTime = 1f; // Tiempo mínimo entre activaciones/desactivaciones
    public float maxTime = 5f; // Tiempo máximo entre activaciones/desactivaciones

    [SerializeField] GameObject rightWing;
    [SerializeField] GameObject leftWing;

    //private Animator animator; // El componente Animator del objeto
    private Animator animatorRight; // El componente Animator del objeto
    private Animator animatorLeft; // El componente Animator del objeto



    void Start()
    {
        {
            if (rightWing != null && leftWing != null)
            {
                animatorRight = rightWing.GetComponent<Animator>();
                animatorLeft = leftWing.GetComponent<Animator>();

                if (animatorRight == null || animatorLeft == null)
                {
                    Debug.LogError("One or both wings do not have an Animator component.");
                    return;
                }

                StartCoroutine(ToggleAnimation());
            }
            else
            {
                Debug.LogError("Right wing and/or left wing GameObjects are not assigned.");
            }
        }
    }

    private IEnumerator ToggleAnimation()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            bool newState = !animatorRight.enabled; // Obtener el nuevo estado basado en el ala derecha (puede ser cualquier ala)
            animatorLeft.enabled = newState;
            animatorRight.enabled = newState;
        }
    }
}