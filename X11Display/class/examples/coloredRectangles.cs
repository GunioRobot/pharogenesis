coloredRectangles
	"X11Display coloredRectangles"
	| display window gc colors rnd w h pt1 pt2 r nPixels time n |
	display _ X11Display XOpenDisplay: nil.
	window _ display ourWindow.
	gc _ X11GC on: window.
	colors _ Color colorNames collect:[:cn| (Color perform: cn) pixelWordForDepth: 32].
	rnd _ Random new.
	w _ Display width.
	h _ Display height.
	n _ 0.
	nPixels _ 0.
	time _ Time millisecondClockValue.
	[Sensor anyButtonPressed] whileFalse:[
		pt1 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
		pt2 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
		r _ Rectangle encompassing: (Array with: pt1 with: pt2).
		gc foreground: colors atRandom.
		gc fillRectangle: r.
		gc foreground: 0.
		gc drawRectangle: r.
		display sync.
		n _ n + 1.
		nPixels _ nPixels + ((r right - r left) * (r bottom - r top)).
		(n \\ 100) = 0 ifTrue:[
			'Pixel fillRate: ', (nPixels * 1000 // (Time millisecondClockValue - time))
				asStringWithCommas displayAt: 0@0].
	].
	gc free.
	display closeDisplay.
	Display forceToScreen.