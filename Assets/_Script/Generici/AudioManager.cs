using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;
   
   public Sound[] musicSound, sfxSound;
   public AudioSource musicSource, sfxSource;

   [SerializeField] private string themeName;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         //DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }
   }

   private void Start()
   {
      PlayMusic(themeName);
   }

   public void MusicVolume(float volume)
   {
      musicSource.volume = volume;
   }

   public void SfxVolume(float volume)
   {
      sfxSource.volume = volume;
   }

   public void PlayMusic(string name)
   {
      Sound s = Array.Find(musicSound, x => x.soundName == name);

      if (s != null)
      {
         musicSource.clip = s.clip;
         musicSource.Play();
      }
      else
      {
         Debug.Log("Niente musica idiota");
      }
   }
   
   public void PlaySFX(string name)
   {
      Sound s = Array.Find(sfxSound, x => x.soundName == name);

      if (s != null)
      {
         sfxSource.PlayOneShot(s.clip);
      }
      else
      {
         Debug.Log("Niente musica idiota");
      }
   }
   
}

[System.Serializable]
public class Sound
{
   public string soundName;
   public AudioClip clip;
}
