myMenuColor

	| c |
	c _ myWorld color.
	c isColor ifTrue: [^c atLeastAsLuminentAs: 0.2].
	^Color white