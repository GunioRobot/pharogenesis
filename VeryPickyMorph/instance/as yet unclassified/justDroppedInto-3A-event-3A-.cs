justDroppedInto: targetMorph event: evt

	passengerMorph ifNil: [^self "delete"].
	passengerMorph noLongerBeingDragged.
	(targetMorph isKindOf: IndentingListItemMorph) ifFalse: [
		passengerMorph changed.
		passengerMorph _ nil.
		owner privateRemoveMorph: self.
		self privateOwner: nil.
	].