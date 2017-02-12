using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	void onTriggerExit(Collider Other)
    {
        Destroy(Other.gameObject);	
	}
}
