popUpAdjacentTo: rightOrLeftPoint forHand: hand from: sourceItem
	"Present this menu at the given point under control of the given hand."

	| selectedItem delta tryToPlace selectedOffset |

	hand world startSteppingSubmorphsOf: self.
	popUpOwner _ sourceItem.
	originalEvent _ hand lastEvent.
	selectedItem _ self selectedItem.
	self fullBounds.  "ensure layout is current"
	selectedOffset _ selectedItem position - self position.
	tryToPlace _
		[:where :mustFit |
		self position: where - selectedOffset.
		delta _ self fullBoundsInWorld amountToTranslateWithin: hand worldBounds.
		(delta x = 0 or: [mustFit]) ifTrue:
			[delta = (0@0) ifFalse: [self position: self position + delta].
			sourceItem owner owner addMorphFront: self.
			^ self]].
	tryToPlace 
		value: rightOrLeftPoint first value: false;
		value: rightOrLeftPoint last  - (self width @ 0) value: false;
		value: rightOrLeftPoint first value: true

	