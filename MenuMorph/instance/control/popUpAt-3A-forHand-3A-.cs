popUpAt: aPoint forHand: hand 
	"Present this menu at the given point under control of the given hand."
	| selectedItem i yOffset sub delta |

	hand resetClickState.
	popUpOwner _ hand.
	originalEvent _ hand lastEvent.
	selectedItem _ self items detect: [:each | each == lastSelection]
				ifNone: [self items isEmpty
						ifTrue: [^ self]
						ifFalse: [self items first]].
	"Note: items may not be laid out yet (I found them all to be at 0@0), 
	so have to add up heights of items above the selected item."
	i _ 0.
	yOffset _ 0.
	[(sub _ self submorphs at: (i _ i + 1)) == selectedItem]
		whileFalse: [yOffset _ yOffset + sub height].
	self position: aPoint - (2 @ (yOffset + 8)).
	self bounds right > hand worldBounds right
		ifTrue: [self position: self position - (self bounds width - 4 @ 0)].
	delta _ self bounds amountToTranslateWithin: hand worldBounds.
	delta = (0 @ 0) ifFalse: [self position: self position + delta].
	hand world addMorphFront: self; startSteppingSubmorphsOf: self.
	hand newMouseFocus: selectedItem.
	self changed