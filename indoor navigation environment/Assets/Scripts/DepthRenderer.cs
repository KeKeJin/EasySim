using UnityEngine;

[ExecuteInEditMode]
public class DepthRenderer : MonoBehaviour
{
    [Range(0f, 3f)]
    public float depthLevel = 0.5f;
    public Camera camera;
    public Shader _shader;
    private Shader shader
    {
        get { return _shader != null ? _shader : (_shader = Shader.Find("Custom/RenderDepth.Shader")); }
    }

    private Material _material;
    private Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }
   /* private void Awake()
    {
        camera = GetComponent<Camera>();
    }*/

    private void Start()
    {
       // Camera.main.rect = new Rect(0.8f, 0.8f, 0.2f, height: 0.2f);
        if (!SystemInfo.supportsImageEffects)
        {
            Debug.Log("System doesn't support image effects");
            enabled = false;
            return;
        } else
        {
            Debug.Log("system does support");
        }
        if (shader == null || !shader.isSupported)
        {
            enabled = false;
            Debug.Log("Shader " + shader.name + " is not supported");
            return;
        }

        // turn on depth rendering for the camera so that the shader can access it via _CameraDepthTexture
        camera.depthTextureMode = DepthTextureMode.Depth;
    }

    private void OnDisable()
    {
        if (_material != null)
            DestroyImmediate(_material);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (shader != null)
        {
            material.SetFloat("_DepthLevel", depthLevel);
            Graphics.Blit(src, dest, material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
    void RenderToTexture()
    {
        /* var w = 512;
         var h = w;

         var tempRt = new RenderTexture(w, h, 0);
         camera.targetTexture = tempRt;
         camera.Render();

         RenderTexture.active = tempRt;

         var tex2d = new Texture2D(w, h, TextureFormat.ARGB32, false);
         tex2d.ReadPixels(new Rect(0, 0, w, h), 0, 0);
         tex2d.Apply();

         var imageData = tex2d.EncodeToPNG();
         File.WriteAllBytes(Path.Combine("Assets", "depth_img.png"), imageData);

         RenderTexture.active = null;
         camera.targetTexture = null;
         Destroy(tempRt);*/
        Debug.Log("here");
        ScreenCapture.CaptureScreenshot("depth_image.png");
    }
    private void Update()
    {
        camera.depthTextureMode = DepthTextureMode.Depth;
        depthLevel = Mathf.Clamp(depthLevel, 0 , 5);
    }
}