using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSound : MonoBehaviour
{
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] float stepInterval = 0.5f;
    [SerializeField] float velocityThreshold = 0.1f;

    private AudioSource audioSource;
    private CharacterController characterController;
    private float stepTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded &&
            characterController.velocity.magnitude > velocityThreshold)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length == 0) return;

        // Randomize pitch slightly for variety
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        // Play random footstep sound
        AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
