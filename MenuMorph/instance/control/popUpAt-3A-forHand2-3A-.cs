popUpAt: aPoint forHand2: hand
	"Present this menu at the given point under control of the given hand."

	| selectedItem delta |
	popUpOwner _ hand.
	originalEvent _ MorphicEvent new setHand: hand.
	selectedItem _ self items detect: [:each | each == lastSelection] ifNone: [self items first].
	self position: aPoint - selectedItem position + self position.
	delta _ self bounds amountToTranslateWithin: hand worldBounds.
	delta = (0@0) ifFalse: [self position: self position + delta].
	hand world addMorphFront: self.
	self changed.
