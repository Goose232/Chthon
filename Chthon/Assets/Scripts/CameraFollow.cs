using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float cameraSpeed;

    [SerializeField] private float offsetY = 0;

    private void Awake()
    {
        if (this.playerTransform == null)
            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;

        transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y+ offsetY,
            z = playerTransform.position.z -5,
        };
    }

    void Update()
    {
        if (playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x,
                y = playerTransform.position.y+ offsetY,
                z = playerTransform.position.z - 5,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, cameraSpeed*Time.deltaTime);

            transform.position = pos;
        }
    }
}
