using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TreeDetector : MonoBehaviour
{
    public GameObject detectionFrameUI;
    public GameObject learnMoreButton;
    public GameObject closeButton;
    public GameObject farmer;
    public GameObject[] treeObjects;
    public GameObject ground;
    public float stillnessThreshold = 0.01f;
    public float detectionTime = 3f;

    private float stillnessTimer = 0f;
    private Vector3 lastPosition;
    public Texture treeImage;

    void Start()
    {
        detectionFrameUI.SetActive(false);
        learnMoreButton.SetActive(false);
        closeButton.SetActive(false);
    }

    public void StartDetection()
    {
        farmer.SetActive(false);
        ground.SetActive(false);
        for(int i = 0; i < treeObjects.Length; i++)
        {
            treeObjects[i].SetActive(false);
        }

        closeButton.SetActive(true);
        detectionFrameUI.SetActive(true);
        learnMoreButton.SetActive(false);
        stillnessTimer = 0f;
        lastPosition = Input.acceleration;
    }

    void Update()
    {
        if (!detectionFrameUI.activeSelf) return;

        Vector3 currentAcceleration = Input.acceleration;
        float movement = Vector3.Distance(currentAcceleration, lastPosition);

        if (movement < stillnessThreshold)
        {
            stillnessTimer += Time.deltaTime;
            if (stillnessTimer >= detectionTime)
            {
                ShowLearnMore();
            }
        }
        else
        {
            stillnessTimer = 0f; // Reset if phone moved
        }

        lastPosition = currentAcceleration;
    }

    void ShowLearnMore()
    {
        detectionFrameUI.SetActive(false);
        learnMoreButton.SetActive(true);
    }

    public void OnLearnMoreClicked()
    {
        learnMoreButton.SetActive(false);
        closeButton.SetActive(false);
        // Show your existing tree dialogue here
        FindObjectOfType<TreeDialogueUI>().ShowDialogue(treeImage, "Tree Type: Avocado (Persea americana)\r\n\r\nOrigin:\r\nNative to south-central Mexico, the avocado tree is now cultivated in tropical and Mediterranean climates around the world.\n\nCharacteristics:\n-Evergreen tree, typically 10–15 meters tall.\n-Produces pear-shaped fruits (avocados) with creamy, nutrient-rich flesh.\n-Glossy, dark green leaves; small greenish-yellow flowers bloom seasonally.");
        farmer.SetActive(true);
        ground.SetActive(true);
        for (int i = 0; i < treeObjects.Length; i++)
        {
            treeObjects[i].SetActive(true);
        }
    }

    public void OnCloseDetectionClicked()
    {
        closeButton.SetActive(false);
        learnMoreButton?.SetActive(false);
        detectionFrameUI?.SetActive(false);
        farmer.SetActive(true);
        ground.SetActive(true);
        for (int i = 0; i < treeObjects.Length; i++)
        {
            treeObjects[i].SetActive(true);
        }
    }

}
