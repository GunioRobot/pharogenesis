removeSlotNamed: aSlotName

	self basicRemoveSlotNamed: aSlotName.
	turtles removeVectorSlotNamed: aSlotName.
