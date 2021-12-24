using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[Serializable]
public class _2dxFX_SkyCloud : MonoBehaviour
{
	private void Awake()
	{
		if (base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			this.CanvasSpriteRenderer = base.gameObject.GetComponent<SpriteRenderer>();
		}
	}

	private void Start()
	{
		this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
		this.ShaderChange = 0;
		if (this.CanvasSpriteRenderer != null)
		{
			this.CanvasSpriteRenderer.sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
		}
		else if (this.CanvasImage != null)
		{
			this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
		}
		this.XUpdate();
	}

	public void CallUpdate()
	{
		this.XUpdate();
	}

	private void Update()
	{
		if (this.ActiveUpdate)
		{
			this.XUpdate();
		}
	}

	private void XUpdate()
	{
		if (this.CanvasImage == null && base.gameObject.GetComponent<Image>() != null)
		{
			this.CanvasImage = base.gameObject.GetComponent<Image>();
		}
		if (this.CanvasSpriteRenderer == null && base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			this.CanvasSpriteRenderer = base.gameObject.GetComponent<SpriteRenderer>();
		}
		if (this.ShaderChange == 0 && this.ForceMaterial != null)
		{
			this.ShaderChange = 1;
			if (this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial = this.ForceMaterial;
			}
			else if (this.CanvasImage != null)
			{
				this.CanvasImage.material = this.ForceMaterial;
			}
			this.ForceMaterial.hideFlags = HideFlags.None;
			this.ForceMaterial.shader = Shader.Find(this.shader);
		}
		if (this.ForceMaterial == null && this.ShaderChange == 1)
		{
			if (this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			this.tempMaterial = new Material(Shader.Find(this.shader));
			this.tempMaterial.hideFlags = HideFlags.None;
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial = this.tempMaterial;
			}
			else if (this.CanvasImage != null)
			{
				this.CanvasImage.material = this.tempMaterial;
			}
			this.ShaderChange = 0;
		}
		if (this.ActiveChange)
		{
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_Zoom", this._Zoom);
				this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_Intensity", this._Intensity);
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasSpriteRenderer.sharedMaterial.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			else if (this.CanvasImage != null)
			{
				this.CanvasImage.material.SetFloat("_Alpha", 1f - this._Alpha);
				this.CanvasImage.material.SetFloat("_Zoom", this._Zoom);
				this.CanvasImage.material.SetFloat("_Intensity", this._Intensity);
				if (!this._AutoScrollX && !this._AutoScrollY)
				{
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (this._AutoScrollX && !this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._OffsetY);
				}
				if (!this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._OffsetX);
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
				if (this._AutoScrollX && this._AutoScrollY)
				{
					this._AutoScrollCountX += this._AutoScrollSpeedX * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetX", this._AutoScrollCountX);
					this._AutoScrollCountY += this._AutoScrollSpeedY * Time.deltaTime;
					this.CanvasImage.material.SetFloat("_OffsetY", this._AutoScrollCountY);
				}
			}
			if (this._AutoScrollCountX > 1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountX < -1f)
			{
				this._AutoScrollCountX = 0f;
			}
			if (this._AutoScrollCountY > 1f)
			{
				this._AutoScrollCountY = 0f;
			}
			if (this._AutoScrollCountY < -1f)
			{
				this._AutoScrollCountY = 0f;
			}
		}
	}

	private void OnDestroy()
	{
		if (!Application.isPlaying && Application.isEditor)
		{
			if (this.ForceMaterial != null && this.tempMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			}
			if (base.gameObject.activeSelf)
			{
				if (this.CanvasSpriteRenderer != null)
				{
					this.CanvasSpriteRenderer.sharedMaterial = this.defaultMaterial;
					this.CanvasSpriteRenderer.sharedMaterial.hideFlags = HideFlags.None;
					return;
				}
				if (this.CanvasImage != null)
				{
					this.CanvasImage.material = this.defaultMaterial;
					this.CanvasImage.material.hideFlags = HideFlags.None;
				}
			}
		}
	}

	private void OnDisable()
	{
		if (this.ForceMaterial != null && this.tempMaterial != null)
		{
			UnityEngine.Object.DestroyImmediate(this.tempMaterial);
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial = this.defaultMaterial;
				this.CanvasSpriteRenderer.sharedMaterial.hideFlags = HideFlags.None;
				return;
			}
			if (this.CanvasImage != null)
			{
				this.CanvasImage.material = this.defaultMaterial;
				this.CanvasImage.material.hideFlags = HideFlags.None;
			}
		}
	}

	private void OnEnable()
	{
		if (this.defaultMaterial == null)
		{
			this.defaultMaterial = new Material(Shader.Find("Sprites/Default"));
		}
		if (this.ForceMaterial == null)
		{
			this.ActiveChange = true;
			this.tempMaterial = new Material(Shader.Find(this.shader));
			this.tempMaterial.hideFlags = HideFlags.None;
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial = this.tempMaterial;
			}
			else if (this.CanvasImage != null)
			{
				this.CanvasImage.material = this.tempMaterial;
			}
			this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
		}
		else
		{
			this.ForceMaterial.shader = Shader.Find(this.shader);
			this.ForceMaterial.hideFlags = HideFlags.None;
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial = this.ForceMaterial;
			}
			else if (this.CanvasImage != null)
			{
				this.CanvasImage.material = this.ForceMaterial;
			}
			this.__MainTex2 = (Resources.Load("_2dxFX_ShadowTXT") as Texture2D);
		}
		if (this.__MainTex2)
		{
			this.__MainTex2.wrapMode = TextureWrapMode.Repeat;
			if (this.CanvasSpriteRenderer != null)
			{
				this.CanvasSpriteRenderer.sharedMaterial.SetTexture("_MainTex2", this.__MainTex2);
				return;
			}
			if (this.CanvasImage != null)
			{
				this.CanvasImage.material.SetTexture("_MainTex2", this.__MainTex2);
			}
		}
	}

	public Material ForceMaterial;

	public bool ActiveChange = true;

	private string shader = "2DxFX/Standard/SkyCloud";

	public float _Alpha = 1f;

	public Texture2D __MainTex2;

	public float _OffsetX;

	public float _OffsetY;

	public float _Zoom = 0.2f;

	public float _Intensity = 0.3f;

	public bool _AutoScrollX;

	public float _AutoScrollSpeedX = 0.08f;

	public bool _AutoScrollY;

	public float _AutoScrollSpeedY = 0.02f;

	private float _AutoScrollCountX;

	private float _AutoScrollCountY;

	public int ShaderChange;

	private Material tempMaterial;

	private Material defaultMaterial;

	private Image CanvasImage;

	private SpriteRenderer CanvasSpriteRenderer;

	public bool ActiveUpdate = true;
}