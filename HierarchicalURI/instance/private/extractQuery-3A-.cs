extractQuery: remainder
	| queryIndex |
	queryIndex _ remainder indexOf: $?.
	queryIndex > 0
		ifFalse: [^remainder].
	query _ remainder copyFrom: queryIndex to: remainder size.
	^remainder copyFrom: 1 to: queryIndex-1