canDrawAtHigherResolution
	
	| pt |
	pt _ self scalePoint.
	^pt x < 1.0 or: [pt y < 1.0]