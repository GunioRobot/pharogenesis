positionAt: aPoint relativeTo: selectedItem
	"Note: items may not be laid out yet (I found them all to be at 0@0),  
	so we have to add up heights of items above the selected item."

	| i yOffset sub delta |
	i _ 0.
	yOffset _ 0.
	[(sub _ self submorphs at: (i _ i + 1)) == selectedItem]
		whileFalse: [yOffset _ yOffset + sub height].

	self position: aPoint - (2 @ (yOffset + 8)).

	"If it doesn't fit, show it to the left, not to the right of the hand."
	self right > popUpOwner worldBounds right
		ifTrue: [self left: self left - self width + 4].

	"Make sure that the menu fits in the world."
	delta _ self bounds amountToTranslateWithin: popUpOwner worldBounds.
	delta = (0 @ 0) ifFalse: [self position: self position + delta]