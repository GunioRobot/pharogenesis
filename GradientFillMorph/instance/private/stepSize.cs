stepSize
	| n |
	n _ gradientDirection == # vertical ifTrue: [self height] ifFalse: [self width].
	n < 100 ifTrue: [^ 1].
	n < 200 ifTrue: [^ 2].
	^ 4