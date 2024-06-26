using UnityEngine;

public class OnClick : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip[] sounds;

    #region Audio OnClick
    private void OnMouseDown()
    {
        AudioClip clip = sounds[Random.Range(0, sounds.Length)];
        AudioManager.instance.PlaySound(clip);
    }
    #endregion
}
