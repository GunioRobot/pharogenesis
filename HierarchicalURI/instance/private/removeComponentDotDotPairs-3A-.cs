removeComponentDotDotPairs: pathComponents
	| dotDotIndex |
	dotDotIndex _ pathComponents indexOf: '..'.
	[dotDotIndex > 1]
		whileTrue: [
			pathComponents
				removeAt: dotDotIndex;
				removeAt: dotDotIndex-1.
			dotDotIndex _ pathComponents indexOf: '..']