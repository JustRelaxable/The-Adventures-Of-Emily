using UnityEngine;

public class TerrainFootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] grassClips;

    private AudioSource audioSource;
    private TerrainTextureData terrainTextureData;

    [SerializeField] EmilyAnimator emilyAnimator;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        emilyAnimator.OnStepped += EmilyAnimator_OnStepped;
        audioSource = GetComponent<AudioSource>();
    }

    private void EmilyAnimator_OnStepped()
    {
        Step();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private void Update()
    {
        //GetRandomClip();
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down)/10, out hit,1f, layerMask))
        {
            terrainTextureData = hit.transform.gameObject.GetComponent<TerrainTextureData>();
        }
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainTextureData.GetActiveTerrainTextureIdx(transform.position);
        switch (terrainTextureIndex)
        {
            case 0:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
            case 1:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            default:
                return null;
        }
    }
}