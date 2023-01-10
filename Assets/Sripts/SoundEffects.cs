using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip effect1;
    public AudioClip effect2;
    public AudioClip effect3;
    public AudioClip effect4;
    public AudioClip effect5;
    public AudioClip effect6;
    public static AudioClip effect;

    public static AudioClip[] effects;

    public static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        effects = new AudioClip[] {effect1, effect2, effect3, effect4, effect5, effect6};
    }

    public static void playSoundEffect()
    {   
        effect = effects[Random.Range(0, effects.Length)];
        audioSource.PlayOneShot(effect, 0.6F);
    }
}
