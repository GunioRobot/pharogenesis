popUpAdjacentTo: rightOrLeftPoint forHand: hand from: sourceItem
	"Present this menu at the given point under control of the given hand."

	| delta tryToPlace selectedOffset |

	hand world startSteppingSubmorphsOf: self.
	popUpOwner _ sourceItem.
	self fullBounds.  "ensure layout is current"
	selectedOffset := (selectedItem ifNil:[self items first]) position - self position.

	tryToPlace :=
		[ :where :mustFit |
		self position: where - selectedOffset.
		delta _ self fullBoundsInWorld amountToTranslateWithin: sourceItem worldBounds.
		(delta x = 0 or: [mustFit]) ifTrue:
			[delta = (0@0) ifFalse: [self position: self position + delta].
			sourceItem owner owner addMorphFront: self.
			^ self]].
	tryToPlace 
		value: rightOrLeftPoint first value: false;
		value: rightOrLeftPoint last  - (self width @ 0) value: false;
		value: rightOrLeftPoint first value: true

	