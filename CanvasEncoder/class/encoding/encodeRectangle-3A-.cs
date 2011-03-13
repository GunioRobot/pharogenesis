encodeRectangle: rectangle
	| x y encoded cornerX cornerY |

	x _ rectangle origin x asInteger.
	y _ rectangle origin y asInteger.
	cornerX _ rectangle corner x asInteger.
	cornerY _ rectangle corner y asInteger.

	CanvasEncoder at: 2 count:  1.
	encoded := String new: 16.
	encoded putInteger32: x at: 1.
	encoded putInteger32: y at: 5.
	encoded putInteger32: cornerX at: 9.
	encoded putInteger32: cornerY at: 13.

	^encoded