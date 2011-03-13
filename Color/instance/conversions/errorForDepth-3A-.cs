errorForDepth: d
    "How close the nearest color at this depth is to this abstract color.  Sum of the squares of the RGB differences, square rooted and normalized to 1.0.  Multiply by 100 to get percent. 6/19/96 tk"

	| p col r g b rdiff gdiff bdiff diff |
	p _ self pixelValueForDepth: d.
	col _ Color colorFromPixelValue: p depth: d.
	r _ self privateRed.  g _ self privateGreen.  b _ self privateBlue.
	rdiff _ r - col privateRed.
	gdiff _ g - col privateGreen.
	bdiff _ b - col privateBlue.
	diff _ (rdiff*rdiff) + (gdiff*gdiff) + (bdiff*bdiff).
	^ diff asFloat sqrt / 1771.89		"= (1023*1023*3) sqrt" 