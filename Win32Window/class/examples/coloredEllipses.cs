coloredEllipses "Win32Window coloredEllipses"
	"Draw a bunch of ellipses"
	| rnd pt1 pt2 w h colors newBrush oldBrush |
	colors _ Color colorNames collect:[:cName| (Color perform: cName)].
	"convert to COLORREF"
	colors _ colors collect:[:c| 
		(c red * 255) asInteger + 
			((c green * 255) asInteger << 8) + 
				((c blue * 255) asInteger << 16)].
	rnd _ Random new.
	w _ Display width.
	h _ Display height.
	self getFocus getHDCDuring:[:hDC|
		[Sensor anyButtonPressed] whileFalse:[
			newBrush _ Win32HBrush createSolidBrush: colors atRandom.
			oldBrush _ hDC selectObject: newBrush.
			pt1 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
			pt2 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
			hDC ellipse: (Rectangle encompassing: (Array with: pt1 with: pt2)).
			hDC selectObject: oldBrush.
			newBrush delete.
		].
	].
	Display forceToScreen.