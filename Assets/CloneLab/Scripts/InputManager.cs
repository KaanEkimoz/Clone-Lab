using StarterAssets;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    public static StarterAssetsInputs starterAssetsInput { get; private set; }
    private void Awake()
    {
        starterAssetsInput = FindObjectOfType<StarterAssetsInputs>();
    }
}
