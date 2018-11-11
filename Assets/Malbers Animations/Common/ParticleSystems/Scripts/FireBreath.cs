using UnityEngine;

namespace MalbersAnimations
{
    public class FireBreath : MonoBehaviour
    {
        ParticleSystem.EmissionModule emission;

        void Start()
        {
            emission = GetComponent<ParticleSystem>().emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(0);
        }

        public void Activate(bool value)
        {
            if (value)
            {
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(500f);
            }
            else
            {
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(0);
            }
        }
    }
}
