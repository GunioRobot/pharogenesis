resetPotentialDropMorph
	potentialDropMorph ifNotNil: [
		potentialDropMorph resetHighlightForDrop.
		potentialDropMorph _ nil]
