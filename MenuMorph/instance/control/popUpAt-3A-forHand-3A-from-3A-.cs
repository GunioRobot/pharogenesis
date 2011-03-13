popUpAt: aPoint forHand: hand from: sourceItem
	"Present this menu at the given point under control of the given hand."

	| selectedItem delta |
	popUpOwner _ sourceItem.
	originalEvent _ MorphicEvent new setHand: hand.
	selectedItem _ self items detect:
		 [:each | each == lastSelection] ifNone: [self items first].
	self fullBounds.  "ensure layout is current"
	self position: aPoint - (selectedItem position - self position).
	sourceItem owner owner addMorphFront: self.
	delta _ self fullBoundsInWorld amountToTranslateWithin: hand worldBounds.
	delta = (0@0) ifFalse: [self position: self position + delta].
