using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightBlink : MonoBehaviour
{

    public float blinkSpeed;

    private bool lightUp;
    private Light light;

    // Use this for initialization
    void Start()
    {
        //object is lighting down by default;
        lightUp = false;

        light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.intensity <= 0)
            lightUp = true;
        if (light.intensity >= 8)
            lightUp = false;
        if (lightUp)
            light.intensity += 1f * blinkSpeed * Time.deltaTime;
        else light.intensity -= 1f * blinkSpeed * Time.deltaTime;

    }

}
