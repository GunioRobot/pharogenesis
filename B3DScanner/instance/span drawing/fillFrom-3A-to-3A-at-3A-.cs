fillFrom: leftEdge to: rightEdge at: yValue
	| face |
	leftEdge xValue >= rightEdge xValue ifTrue:[^self]. "Nothing to do"
	face _ fillList first.
	face == nil ifTrue:[^self].
	face texture == nil
		ifTrue:[self rgbFill: face from: leftEdge to: rightEdge at: yValue]
		ifFalse:[self rgbstwFill: face from: leftEdge to: rightEdge at: yValue]