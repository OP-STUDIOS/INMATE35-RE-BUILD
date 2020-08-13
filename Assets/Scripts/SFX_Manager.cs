using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;
	private AudioSource source;
	[Range(0.5f, 1.5f)]
	[SerializeField] float pitch = 0.7f;
	[Range(0f, 1f)]
	[SerializeField] float volume = 1f;

	public void SetSource(AudioSource _source)
	{
		source = _source;
		source.clip = clip;
	}

	public void Play()
	{
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
	}

	public void PlayOnLoop()
	{
		source.volume = volume;
		source.pitch = pitch;
		source.loop = true;
		source.Play();
	}

	public void Stop()
	{
		source.volume = volume;
		source.pitch = pitch;
		source.Stop();
	}
}

public class SFX_Manager : MonoBehaviour
{
	[SerializeField]
	Sound[] sounds;

	void Awake()
	{
		int sfxManagerCount = FindObjectsOfType<SFX_Manager>().Length;

		if (sfxManagerCount > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
			AudioSource newSource = _go.AddComponent<AudioSource>();
			sounds[i].SetSource(newSource);
		}
	}

	public void PlaySound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Play();
				return;
			}
		}
		Debug.Log("Sound Not found in the list " + _name);
	}

	public void PlaySoundOnLoop(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].PlayOnLoop();
				return;
			}
		}
		Debug.Log("Sound Not found in the list " + _name);
	}

	public void StopSound(string _name)
	{
		for (int i = 0; i < sounds.Length; i++)
		{
			if (sounds[i].name == _name)
			{
				sounds[i].Stop();
				return;
			}
		}
		Debug.Log("Sound Not found in the list " + _name);
	}
}
