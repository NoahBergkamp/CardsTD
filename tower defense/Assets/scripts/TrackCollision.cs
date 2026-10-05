using System.Diagnostics.Contracts;
using UnityEngine;

public class TrackCollision : MonoBehaviour
{
    public bool onTrack;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            onTrack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            onTrack = false;
        }
    }
}
