using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public Vector3 offset = new Vector3(0,10,-10);
    // Start is called before the first frame update
    void Start()
    {
        GameObject activePlayer = GameObject.FindGameObjectWithTag("Player");
        if(activePlayer != null)
        {
            player = activePlayer.transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = targetPosition;

            transform.LookAt(player);
        }
    }
}
