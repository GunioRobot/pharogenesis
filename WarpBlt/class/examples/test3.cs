test3   "Display restoreAfter: [WarpBlt test3]"

	"The Squeak Release Mandala - 9/23/96 di"

	"Move the mouse near the center of the square.
	Up and down affects shrink/grow
	Left and right affect rotation angle"
	| warp pts p0 p box map d t |
	box _ 100@100 extent: 300@300.
	Display border: (box expandBy: 2) width: 2.

	"Make a color map that steps through the color space"
	map _ (Display depth > 8
		ifTrue: ["RGB is a bit messy..."
				d _ Display depth = 16 ifTrue: [5] ifFalse: [8].
				(1 to: 512) collect: [:i | t _ i bitAnd: 511.
					((t bitAnd: 16r7) bitShift: d-3)
					+ ((t bitAnd: 16r38) bitShift: d-3*2)
					+ ((t bitAnd: 16r1C0) bitShift: d-3*3)]]
		ifFalse: ["otherwise simple"
				1 to: (1 bitShift: Display depth)])
			as: Bitmap.
	warp _ (WarpBlt toForm: Display)
		clipRect: box;
		sourceForm: Display;
		colorMap: map;
		combinationRule: Form over.
	p0 _ box center.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint.
		pts _ (box insetBy: p y - p0 y) innerCorners
			collect: [:pt | pt rotateBy: p x - p0 x / 50.0 about: p0].
		warp copyQuad: pts toRect: box]