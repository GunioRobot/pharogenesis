removeComponentDotDotPairs: pathParts
	| dotDotIndex |
	dotDotIndex := pathParts indexOf: '..'.
	[dotDotIndex > 1]
		whileTrue: [
			pathParts
				removeAt: dotDotIndex;
				removeAt: dotDotIndex-1.
			dotDotIndex := pathParts indexOf: '..']