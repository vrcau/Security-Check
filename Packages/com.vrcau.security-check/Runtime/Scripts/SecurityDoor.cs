using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Enums;
using VRC.Udon.Common.Interfaces;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class SecurityDoor : UdonSharpBehaviour
{
    private AudioSource _audioSource;

    public GameObject testObject;
    public float rayDistance = 5f;
    public LayerMask layerMask = -1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        testObject.SetActive(false);
    }

    public void Test()
    {
        testObject.SetActive(true);
    }

    public void _TestNetworked() => SendCustomNetworkEvent(NetworkEventTarget.All, nameof(Test));

    public void Reset()
    {
        testObject.SetActive(false);
        _audioSource.Stop();
    }

    public void _RestNetworked() => SendCustomNetworkEvent(NetworkEventTarget.All, nameof(Reset));

    public void _Play()
    {
        _audioSource.Play();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position + Vector3.down, Vector3.up, rayDistance,
                layerMask) && !_audioSource.isPlaying)
            _Play();
    }
}