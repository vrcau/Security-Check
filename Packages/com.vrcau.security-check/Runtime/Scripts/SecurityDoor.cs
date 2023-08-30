using UdonSharp;
using UnityEngine;
using VRC.Udon.Common.Enums;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
[RequireComponent(typeof(Collider))]
public class SecurityDoor : UdonSharpBehaviour
{
    public GameObject testObject;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void _Reset()
    {
        _audioSource.Stop();
        testObject.SetActive(false);
    }

    public void _Play()
    {
        _audioSource.Play();
    }

    public void _Test()
    {
        testObject.SetActive(true);
        SendCustomEventDelayedSeconds(nameof(_StopTest), 3, EventTiming.LateUpdate);
    }

    public void _StopTest()
    {
        testObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) => _Play();

    private void OnTriggerExit(Collider other) => _Reset();

    private void OnCollisionEnter(Collision other) => _Play();

    private void OnCollisionExit(Collision other) => _Reset();
}
