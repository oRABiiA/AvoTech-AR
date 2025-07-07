using UnityEngine;

public class FarmerMover : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDuration = 3f;

    private bool isMoving = false;
    private float timer = 0f;

    public void StartMoving()
    {
        isMoving = true;
        timer = 0f;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= moveDuration)
            {
                isMoving = false;
            }
        }
    }
}

