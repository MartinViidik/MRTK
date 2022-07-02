
using System.Collections;
using UnityEngine;

public class WorldPopulater : MonoBehaviour
{
    public WorldCoordinates[] coordinates;
    public GameObject MarkerPrefab;
    public GameObject EarthMesh;

    private float radius = 1f;

    private void Awake()
    {
        StartCoroutine(PopulateWorld(3, 0.25f));
    }
    IEnumerator PopulateWorld(float initialDelay, float spawnDelay)
    {
        yield return new WaitForSecondsRealtime(initialDelay);

        foreach (WorldCoordinates location in coordinates)
        {
            yield return new WaitForSecondsRealtime(spawnDelay);
            Marker NewMarker = Instantiate(MarkerPrefab, transform).GetComponent<Marker>(); ;
            NewMarker.transform.position = GetMarkerLocation(location.latitude, location.longitude);
            NewMarker.SetCoordinates(location);
        }
        StopAllCoroutines();
    }

    Vector3 GetMarkerLocation(float latitude, float longitude)
    {
        latitude = Mathf.PI * latitude / 180;
        longitude = Mathf.PI * longitude / 180;

        latitude -= 1.570795765134f;

        float xPosition = EarthMesh.transform.position.x + (radius * Mathf.Sin(latitude) * Mathf.Cos(longitude));
        float zPosition = EarthMesh.transform.position.z + (radius * Mathf.Sin(latitude) * Mathf.Sin(longitude));
        float yPosition = EarthMesh.transform.position.y + (radius * Mathf.Cos(latitude));

        return new Vector3(xPosition, yPosition, zPosition);
    }
}
