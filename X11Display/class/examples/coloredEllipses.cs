coloredEllipses
	"X11Display coloredEllipses"
	| display window gc colors rnd w h pt1 pt2 r |
	display _ X11Display XOpenDisplay: nil.
	window _ display ourWindow.
	gc _ X11GC on: window.
	colors _ Color colorNames collect:[:n| (Color perform: n) pixelWordForDepth: 32].
	rnd _ Random new.
	w _ Display width.
	h _ Display height.
	[Sensor anyButtonPressed] whileFalse:[
		pt1 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
		pt2 _ (rnd next * w) asInteger @ (rnd next * h) asInteger.
		r _ Rectangle encompassing: (Array with: pt1 with: pt2).
		gc foreground: colors atRandom.
		gc fillOval: r.
		gc foreground: 0.
		gc drawOval: r.
		display sync.
	].
	gc free.
	display closeDisplay.
	Display forceToScreen.