debugDrawPt: pt
	| canvas |
	canvas _ Display getCanvas.
	canvas
		fillRectangle:((pt-2) corner: pt+2) color: Color red