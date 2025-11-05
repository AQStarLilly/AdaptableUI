using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private UIDocument uIDocument;
    private Label debugLabel;

    private void Awake()
    {
        ApplyDeviceResolution();
    }

    private void Start()
    {
        if(uIDocument != null)
        {
            var root = uIDocument.rootVisualElement;
            debugLabel = root.Q<Label>("DebugText");

            if(debugLabel != null)
            {
                debugLabel.text = $"Current Resolution: {Screen.width}x{Screen.height}";
            }
        }
    }

    private void ApplyDeviceResolution()
    {
        int width = Display.main.systemWidth;
        int height = Display.main.systemHeight;

        Screen.SetResolution(width, height, FullScreenMode.Windowed);
        Debug.Log($"Applied Resolution:{width}x{height}");
    }
}
