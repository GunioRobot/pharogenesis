positionOfColor: aColor
	"Compute the position of the given color in the color chart form"
	| rgbRect x y h s v |
	rgbRect _ (0@0 extent: originalForm boundingBox extent) insetBy: (1@10 corner: 11@1).
	h _ aColor hue.
	s _ aColor saturation.
	v _ aColor brightness.
	h = 0.0 ifTrue:["gray"
		^(rgbRect right + 6) @ (rgbRect height * (1.0 - v) + rgbRect top)].
	x _ (h + 22 \\ 360 / 360.0 * rgbRect width) rounded.
	y _ 0.5.
	s < 1.0 ifTrue:[y _ y - (1.0 - s * 0.5)].
	v < 1.0 ifTrue:[y _ y + (1.0 - v * 0.5)].
	y _ (y * rgbRect height) rounded.
	^x@y + (1@10)