justDroppedInto: newOwner event: evt

	newOwner == myBoard ifFalse:
		["Only allow dropping into my board."
		^ evt hand rejectDropMorph: self event: evt]