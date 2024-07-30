using UnityEngine;
using UnityEngine.SceneManagement;

public class EffectFeedback : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    public void Effect()
    {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
    }
}
