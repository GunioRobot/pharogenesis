bounds
	| min max |
	min _ max _ self at: 1.
	self do:[:pt|
		min _ min min: pt.
		max _ max max: pt].
	^min corner: max
		