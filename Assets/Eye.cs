using System.Collections;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Material eyeMaterial;

    Vector3 targetRotation = new Vector3(0, 0, 0);

    IEnumerator Start()
    {
        var wait = new WaitForSeconds(2);
        while (Application.isPlaying)
        {
            yield return Blink();

            ChangeRotation();

            yield return wait;
            yield return null;
        }
    }

    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * 5);
    }

    IEnumerator Blink()
    {
        float t = 0;
        float blickDuration = Random.Range(0.3f, .5f);
        while (t <= blickDuration)
        {
            t += Time.deltaTime;
            eyeMaterial.SetFloat("_BlinkTime", Mathf.Lerp(1, 0, t / blickDuration));
            yield return null;
        }
        t = 0; // I am lazy just for the sake of this example. You should use different code.
        while (t <= blickDuration)
        {
            t += Time.deltaTime;
            eyeMaterial.SetFloat("_BlinkTime", Mathf.Lerp(0, 1, t / blickDuration));
            yield return null;
        }
    }

    void ChangeRotation()
    {
        float yRange = 50;
        float zRange = 30;

        targetRotation = new Vector3(0, Random.Range(-yRange, yRange), Random.Range(-zRange, zRange));
    }
}
