using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Drawing.Drawing2D;

public class BackgroundPainter : MonoBehaviour {
	Texture2D texture;
	HatchBrush testBrush;
	public Color foreground = Color.red, background = Color.black;
	public Image image;
	System.Drawing.Image i;
	System.Drawing.Color cf, cb;
//	public rect r;
	// Use this for initialization
	void Start () {
//		cc.CanConvertFrom (foreground);
		cf = System.Drawing.ColorTranslator.FromHtml("" + foreground.GetHashCode());
		cb = System.Drawing.ColorTranslator.FromHtml("" + background.GetHashCode());
		testBrush = new HatchBrush (HatchStyle.Cross, cf, cb);
		//i = System.Drawing.ImageConverter image;
		if (i == null) {
			try {
				i = System.Drawing.Image.FromFile (Application.persistentDataPath + "/ComputerGeneratedImage");
			} catch {
				i = System.Drawing.Image.FromFile ("D://testImage.jpg");
			}
		}
		System.Drawing.Graphics g = System.Drawing.Graphics.FromImage (i);
		g.FillRectangle (testBrush, new System.Drawing.Rectangle (0, 0, i.Width, i.Height));
		i.Save (Application.persistentDataPath + "/ComputerGeneratedImage", System.Drawing.Imaging.ImageFormat.Jpeg);
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
