using UdonSharp;
using UnityEngine;
using VRC.Udon.Common.Enums;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
[RequireComponent(typeof(Collider))]
public class SecurityDoor : UdonSharpBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void _Reset()
    {
        _audioSource.Stop();
    }

    public void _Play()
    {
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other) => _Play();

    private void OnTriggerExit(Collider other) => _Reset();

    private void OnCollisionEnter(Collision other) => _Play();

    private void OnCollisionExit(Collision other) => _Reset();
}
