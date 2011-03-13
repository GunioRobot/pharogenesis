points

	| env |
	points isNil ifTrue: [
		env _ self target envelopes first.
		points _ OrderedCollection new.
		points
			add: 0@(self delta * 5 + 0.5);
			add: (env points at: env loopStartIndex)x@(self highLimit -1 * 5 + 0.5);
			add: (env points at: env loopEndIndex)x@(self highLimit -1 * 5 + 0.5);
			add: (env points last)x@(self lowLimit -1 * 5 + 0.5).
		loopStartIndex _ 2.
		loopEndIndex _ 3.
	].
	^points