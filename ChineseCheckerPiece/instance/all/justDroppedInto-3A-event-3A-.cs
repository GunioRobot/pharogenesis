justDroppedInto: newOwner event: evt

	newOwner == myBoard ifFalse:
		["Only allow dropping into my board."
		^self rejectDropMorphEvent: evt].
	^super justDroppedInto: newOwner event: evt