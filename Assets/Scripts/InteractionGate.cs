//using UnityEngine;

//public class InteractionGate : MonoBehaviour
//{
//    [SerializeField] private Collider[] treeColliders;
//    [SerializeField] private Collider farmerCollider;

//    void Start()
//    {
//        SetColliders(false); // Disable all interactions at start
//    }

//    public void OnContinueClicked()
//    {
//        SetColliders(true); // Enable interactions when continue is clicked
//        // Your other logic: show options, animate farmer, play audio, etc.
//    }

//    public void DisableInteractions()
//    {
//        SetColliders(false);
//    }

//    public void EnableInteractions()
//    {
//        SetColliders(true);
//    }

//    private void SetColliders(bool state)
//    {
//        foreach (Collider col in treeColliders)
//        {
//            if (col != null)
//                col.enabled = state;
//        }

//        if (farmerCollider != null)
//            farmerCollider.enabled = state;
//    }
//}


using UnityEngine;

public class InteractionGate : MonoBehaviour
{
    [SerializeField] private Collider farmerCollider;

    public void DisableFarmer()
    {
        if (farmerCollider != null)
            farmerCollider.enabled = false;
    }

    public void EnableFarmer()
    {
        if (farmerCollider != null)
            farmerCollider.enabled = true;
    }

    public void DisableInteractions()
    {
        return;
    }
}
