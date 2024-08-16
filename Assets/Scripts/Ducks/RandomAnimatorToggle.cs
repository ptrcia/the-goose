using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorToggle : MonoBehaviour
{
    public float minTime = 1f;
    public float maxTime = 5f; 

    [SerializeField] GameObject rightWing;
    [SerializeField] GameObject leftWing;

    private Animator animatorRight; 
    private Animator animatorLeft;

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

            bool newState = !animatorRight.enabled; 
            animatorLeft.enabled = newState;
            animatorRight.enabled = newState;
        }
    }
}