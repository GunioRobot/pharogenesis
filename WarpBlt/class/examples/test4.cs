test4   "Display restoreAfter: [WarpBlt test4]"

	"The Squeak Release Mandala - 9/23/96 di
	This version does smoothing"

	"Move the mouse near the center ofhe square.
	Up and dn affects shrink/grow
	Left and right affect rotation angle"
	| warp pts p0 p box |
	box _ 100@100 extent: 300@300.
	Display border: (box expandBy: 2) width: 2.

	warp _ (WarpBlt toForm: Display)
		clipRect: box;
		sourceForm: Display;
		cellSize: 2;  "installs a colormap"
		combinationRule: Form over.
	p0 _ box center.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint.
		pts _ (box insetBy: p y - p0 y) innerCorners
			collect: [:pt | pt rotateBy: p x - p0 x / 50.0 about: p0].
		warp copyQuad: pts toRect: box]