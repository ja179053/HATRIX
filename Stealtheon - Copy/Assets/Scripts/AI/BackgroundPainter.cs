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
//		cc.CanConvertFrom (foreground);
		System.Drawing.Color cf = System.Drawing.ColorTranslator.FromOle(foreground.GetHashCode());
		System.Drawing.Color cb = System.Drawing.ColorTranslator.FromOle(background.GetHashCode());
		testBrush = new HatchBrush (HatchStyle.Cross, cb);
		System.Drawing.Image i;
		try{
			i = System.Drawing.Image.FromFile (Application.persistentDataPath + "/i");
		} catch {
			i = System.Drawing.Image.FromFile ("D://testImage.jpg");
		}
		System.Drawing.Graphics g = System.Drawing.Graphics.FromImage (i);
		g.FillRectangle (testBrush, new System.Drawing.Rectangle (0, 0, i.Width, i.Height));
		i.Save (Application.persistentDataPath + "/i", System.Drawing.Imaging.ImageFormat.Jpeg);
		i.Dispose ();
		g.Dispose ();
	}
//	System.Drawing.Color Adaptor(Color c){
//		return System.Drawing.ColorConverter
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
