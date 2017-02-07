using UnityEngine;
using System.Collections;
using System.Drawing.Drawing2D;

public class BackgroundPainter : MonoBehaviour {
	Texture2D texture;
	HatchBrush testBrush;
	public Material m;
	public Color foreground, background;
	System.Drawing.ColorConverter cc;
//	public rect r;
	// Use this for initialization
	void Start () {
	//	cc.CanConvertFrom (foreground);
		System.Drawing.Color converted = (System.Drawing.Color) cc.ConvertFrom (foreground);
		testBrush = new HatchBrush (HatchStyle.Cross, converted);
		texture = new Texture2D(1,1);
		texture.wrapMode = TextureWrapMode.Repeat;
		m.SetTexture("_MainTex", texture);
	}
//	System.Drawing.Color Adaptor(Color c){
//		return System.Drawing.ColorConverter
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
