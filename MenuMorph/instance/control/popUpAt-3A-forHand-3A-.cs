popUpAt: aPoint forHand: hand
	"Present this menu at the given point under control of the given hand."

	| selectedItem delta |
	popUpOwner _ hand.
	selectedItem _ self items detect: [:each | each == lastSelection] ifNone: [self items first].
	self position: aPoint - selectedItem position + self position.
	delta _ self bounds amountToTranslateWithin: hand worldBounds.
	delta = (0@0) ifFalse: [self position: self position + delta].
	hand world addMorphFront: self.
	hand newMouseFocus: selectedItem.
	self changed.
