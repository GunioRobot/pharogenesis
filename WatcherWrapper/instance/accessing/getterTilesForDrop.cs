getterTilesForDrop
	"Answer getter tiles to use if there is an attempt to drop me onto a tile pad"

	| aCategoryViewer |
	aCategoryViewer _ CategoryViewer new initializeFor: player categoryChoice: #basic.
	^ aCategoryViewer getterTilesFor: (Utilities getterSelectorFor: variableName)  type: self resultType