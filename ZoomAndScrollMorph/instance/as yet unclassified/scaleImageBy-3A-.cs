scaleImageBy: pixels

	| scalePerPixel steps transform factor |

	transform _ self myTransformMorph.
	(steps _ (pixels * self getZoomFactor * 0.2) rounded) = 0 ifTrue: [^self].
	scalePerPixel _ 1.01.
	factor _ scalePerPixel raisedTo: steps abs.
	steps > 0 ifTrue: [
		factor _ 1.0 / factor.
	].
	self changeScaleTo: (transform scale * factor min: 10.0 max: 0.1).
