justDroppedInto: targetMorph event: evt

	passengerMorph ifNil: [^self "delete"].
	passengerMorph noLongerBeingDragged.
	(targetMorph isKindOf: IndentingListItemMorph) ifFalse: [
		passengerMorph changed.
		passengerMorph _ nil.
		owner removeMorph: self.
		self privateOwner: nil.
	].