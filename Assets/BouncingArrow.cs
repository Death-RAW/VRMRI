using UnityEngine;

public class BouncingArrow : MonoBehaviour
{
    private float initialPositionY;
    public float movementRange = 0.1f;
    public float movementSpeed = 1.0f;
    public GameObject buttonCube; // Reference to the Button Cube GameObject
    public float handProximityDistance = 0.2f; // Adjust this value as needed

    private GameObject signIn; // Reference to the SignIn GameObject

    void Start()
    {
        initialPositionY = transform.position.y;
        signIn = GameObject.FindGameObjectWithTag("SignIn");

        // Find Content2 and deactivate it initially
        Transform content2 = signIn.transform.Find("content2");
        if (content2 != null)
        {
            content2.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("content2 not found in the hierarchy.");
        }
    }

    void Update()
    {
        // Check if either Playerhand1 or Playerhand2 is near the button cube
        if (IsHandNearButtonCube("Playerhand1") || IsHandNearButtonCube("Playerhand2"))
        {
            // Stop the bouncing and hide the arrow
            StopBouncingAndHideArrow();

            // Deactivate Content1 and activate Content2
            ActivateContent(signIn, "content2");
            return; // Exit the Update method to prevent further arrow movement
        }

        // Continue the bouncing movement
        float t = Mathf.PingPong(Time.time * movementSpeed, movementRange) / movementRange;
        float easedT = EaseInOutQuad(t);
        float newY = Mathf.Lerp(initialPositionY - movementRange / 2f, initialPositionY + movementRange / 2f, easedT);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    bool IsHandNearButtonCube(string handTag)
    {
        // Replace "PlayerHand" with the actual tag of your VR hand collider
        Collider handCollider = GameObject.FindGameObjectWithTag(handTag).GetComponent<Collider>();
        Collider buttonCollider = buttonCube.GetComponent<Collider>();

        // Check the distance between the hand and the button cube
        float distance = Vector3.Distance(handCollider.bounds.center, buttonCollider.bounds.center);

        // Return true if the hand is within the specified proximity distance
        return distance <= handProximityDistance;
    }

    void StopBouncingAndHideArrow()
    {
        // Stop the bouncing movement
        enabled = false;

        // Hide or deactivate the arrow GameObject
        gameObject.SetActive(false);
    }

    void ActivateContent(GameObject parent, string contentObjectName)
    {
        // Deactivate Content1
        Transform content1 = parent.transform.Find("content1");
        if (content1 != null)
        {
            content1.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Content1 not found in the hierarchy.");
        }

        // Activate Content2
        Transform content2 = parent.transform.Find(contentObjectName);
        if (content2 != null)
        {
            content2.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Content2 not found in the hierarchy.");
        }
    }

    float EaseInOutQuad(float t)
    {
        return t < 0.5f ? 2f * t * t : -1f + (4f - 2f * t) * t;
    }
}
