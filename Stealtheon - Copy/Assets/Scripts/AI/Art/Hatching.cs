using UnityEngine;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
public class Hatching : MonoBehaviour {
	public Texture2D t;
	// Use this for initialization
	void Start () {
		Graphics graphics = new Graphics ();
		Rect clipRect = new Rect(1,1,1,1);
	/*	PaintEventArgs e = new PaintEventArgs (graphics as Graphics, clipRect as Rect);
		HatchBrush hBrush = new HatchBrush (HatchStyle.Cross, System.Drawing.Color.White, System.Drawing.Color.Black);
		e.Graphics.FillEllipse (hBrush, 0, 0, 100, 60);*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
