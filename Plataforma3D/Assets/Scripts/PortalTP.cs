using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTP : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    private bool playerIsOverlapping = false;

    void Update()
    {
        if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// Teleport him!
				float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
				rotationDiff += 0;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = receiver.position + positionOffset;

				playerIsOverlapping = false;
			}
		}
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            playerIsOverlapping = true;

        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            playerIsOverlapping = false;
        }
    }
}
