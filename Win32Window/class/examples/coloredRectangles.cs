coloredRectangles "Win32Window coloredRectangles"
	"Draw a bunch of ellipses"
	| rnd pt1 pt2 w h colors newBrush oldBrush n nPixels time r |
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
		n _ 0.
		nPixels _ 0.
		time _ Time millisecondClockValue.
		[Sensor anyButtonPressed] whileFalse:[
			newBrush _ Win32HBrush createSolidBrush: colors atRandom.
			oldBrush _ hDC selectObject: newBrush.
			pt1 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
			pt2 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
			hDC rectangle: (r _ Rectangle encompassing: (Array with: pt1 with: pt2)).
			hDC selectObject: oldBrush.
			newBrush delete.
			n _ n + 1.
			nPixels _ nPixels + ((r right - r left) * (r bottom - r top)).
			(n \\ 100) = 0 ifTrue:[
				'Pixel fillRate: ', (nPixels * 1000 // (Time millisecondClockValue - time))
					asStringWithCommas displayAt: 0@0].
		].
	].
	Display forceToScreen.