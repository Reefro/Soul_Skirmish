using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplePlayerCamera : MonoBehaviour
{
    public List<Transform> players;
    public Vector3 offset;
    public float smoothTime = 0.5f;
    public float minimumZoom = 70f;
    public float maximumZoom = 10f;
    public float zoomLimit = 30f;

    private Vector3 velocity;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera> ();
    }

    void LateUpdate()
    {
        if (players.Count == 0) return;

        Move();
        Zoom();
    }

    Vector3 GetCameraCenter()
    {
        if (players.Count == 1)
        {
            return players[0].position;
        }

        var bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 0; i < players.Count; i++) 
        {
            bounds.Encapsulate(players[i].position);
        }
        
        return bounds.center;
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maximumZoom, minimumZoom, GetGreatestDistance() / zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);
        for (int i = 0; i < players.Count; i++) 
        {
            bounds.Encapsulate(players[i].position);
        }

        return bounds.size.x;
    }

    void Move()
    {
        Vector3 cameraCenter = GetCameraCenter();

        Vector3 newPosition = cameraCenter + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
