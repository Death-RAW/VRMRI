using UnityEngine;
using System.Collections;

public class FlashOutline : MonoBehaviour
{
    public Outline outlineScript;
    public float chairFlashSpeed = 0.5f;
    public float chairMaxOutlineWidth = 5f;

    public GameObject glow1;
    public float cubeFlashSpeed = 0.3f;
    public float cubeMaxOutlineWidth = 3f;

    private bool isFlashing = false;

    void Start()
    {
        if (outlineScript == null)
        {
            outlineScript = GetComponent<Outline>();
        }
        // The flashing effect is off by default
    }

    void StartFlashing()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashCoroutine());
        }
    }

    void StopFlashing()
    {
        if (isFlashing)
        {
            isFlashing = false;
            StopAllCoroutines();
            SetOutlineWidth(outlineScript.gameObject, 0f);
            SetOutlineWidth(glow1, 0f);
        }
    }

    // Method to enable the flashing
    public void EnableFlashing()
    {
        if (!isFlashing)
        {
            StartFlashing();
        }
    }

    // Method to disable the flashing
    public void DisableFlashing()
    {
        if (isFlashing)
        {
            StopFlashing();
        }
    }

    void SetOutlineWidth(GameObject obj, float width)
    {
        Outline objOutline = obj.GetComponent<Outline>();
        if (objOutline != null)
        {
            objOutline.OutlineWidth = width;
        }
    }

    IEnumerator FlashCoroutine()
    {
        while (isFlashing)
        {
            // Gradually increase the outline width for chairs
            while (outlineScript.OutlineWidth < chairMaxOutlineWidth)
            {
                outlineScript.OutlineWidth += Time.deltaTime * chairFlashSpeed;
                yield return null;
            }

            // Gradually increase the outline width for cubes
            Outline glow1Outline = glow1.GetComponent<Outline>();
            while (glow1Outline.OutlineWidth < cubeMaxOutlineWidth)
            {
                glow1Outline.OutlineWidth += Time.deltaTime * cubeFlashSpeed;
                yield return null;
            }

            // Wait for a moment with the maximum outline width
            yield return new WaitForSeconds(1.0f);

            // Gradually decrease the outline width for chairs
            while (outlineScript.OutlineWidth > 0)
            {
                outlineScript.OutlineWidth -= Time.deltaTime * chairFlashSpeed;
                yield return null;
            }

            // Gradually decrease the outline width for cubes
            while (glow1Outline.OutlineWidth > 0)
            {
                glow1Outline.OutlineWidth -= Time.deltaTime * cubeFlashSpeed;
                yield return null;
            }

            // Wait for a moment with no outline
            yield return new WaitForSeconds(1.0f);
        }
    }
}
