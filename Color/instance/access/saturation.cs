saturation
	"Return the saturation of this color, a value between 0.0 and 1.0."

	| r g b max min |
	r _ self privateRed.
	g _ self privateGreen.
	b _ self privateBlue. 

	max _ ((r max: g) max: b).
	min _ ((r min: g) min: b).
	max = 0
		ifTrue: [ ^ 0.0 ]
		ifFalse: [ ^ (max - min) asFloat / max asFloat ].
