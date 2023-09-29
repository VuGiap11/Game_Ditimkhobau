using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ExplosionAudio, LaserAudio,PointAudio, DieAudio;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void PlayAudio(string name)
    {
        switch (name)
        {
            case "Explosion":
                audioSource.PlayOneShot(ExplosionAudio);
                break;
            case "Laser":
                audioSource.PlayOneShot(LaserAudio);
                break;
            case "Point":
                audioSource.PlayOneShot(PointAudio);
                break;
            case "Die":
                audioSource.PlayOneShot(DieAudio);
                break;
        }
    }
}
