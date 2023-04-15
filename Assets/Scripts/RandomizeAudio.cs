using UnityEngine;

public class RandomizeAudio : MonoBehaviour {
	[SerializeField] private AudioClip[] audio;
	private AudioSource audioSource;

	private void Awake() {
		if(!TryGetComponent(out audioSource)) {
			audioSource = gameObject.AddComponent<AudioSource>();
		}
	}

	public void PlayAudio() {
		if(audio.Length > 0) {
			int index = Random.Range(0, audio.Length);
			audioSource.clip = audio[index];
			audioSource.Play();
		}
	}
}
