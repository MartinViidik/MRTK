using UnityEngine;
public class Marker : MonoBehaviour
{
    public NewsBoard boardUI;
    public GameObject MarkerMesh;
    public AudioClip[] spawnSFX;
    public AudioClip[] clickSFX;

    private MarkerContents contents;
    private WorldCoordinates coordinates;

    private Animator animator;
    private AudioSource ac;

    private void Update()
    {
        // Keep the actor & its contents always facing the camera
        transform.rotation = Camera.main.transform.rotation;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        ac = GetComponent<AudioSource>();
        boardUI.ToggleState();
        PlayRandomSound(spawnSFX);
    }
    public void SetMarkerContents(MarkerContents _contents)
    {
        contents = _contents;
        boardUI.SetContent(contents.Headline, contents.Content);
    }
    public void SetCoordinates(WorldCoordinates _coordinates)
    {
        coordinates = _coordinates;
        SetMarkerContents(NewsController.Instance.TargetNews(coordinates.id));
    }
    void PlayRandomSound(AudioClip[] soundClips)
    {
        if (!ac.isPlaying)
        {
            int i = Random.Range(0, soundClips.Length);
            ac.pitch = Random.Range(0.75f, 1.15f);
            ac.PlayOneShot(soundClips[i], Random.Range(0.5f, 0.75f));
        }
    }
    public void ToggleNewsBoard()
    {
        boardUI.ToggleState();
        animator.Play("Base Layer.MarkerClick");
        PlayRandomSound(clickSFX);
    }
}
