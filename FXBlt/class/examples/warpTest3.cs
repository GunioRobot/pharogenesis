warpTest3   "Display restoreAfter: [FXBlt warpTest3]"

	"The Squeak Release Mandala - 9/23/96 di"

	"Move the mouse near the center of the square.
	Up and down affects shrink/grow
	Left and right affect rotation angle"
	| warp pts p0 p box |
	box _ 100@100 extent: 300@300.
	Display border: (box expandBy: 2) width: 2.

	warp _ (self toForm: Display)
		clipRect: box;
		sourceForm: Display;
		combinationRule: Form over.
	p0 _ box center.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint.
		pts _ (box insetBy: p y - p0 y) innerCorners
			collect: [:pt | pt rotateBy: p x - p0 x / 50.0 about: p0].
		warp copyQuad: pts toRect: box]