extractSchemeSpecificPartAndFragment: remainder
	| fragmentIndex |
	fragmentIndex _ remainder indexOf: $# .
	fragmentIndex > 0
		ifTrue: [
			schemeSpecificPart _ remainder copyFrom: 1 to: fragmentIndex-1.
			fragment _ remainder copyFrom: fragmentIndex+1 to: remainder size]
		ifFalse: [schemeSpecificPart _ remainder]