changeVariableType
	| slotName |
	(slotName _ self chooseUserSlot) ifNil: [^ self].
	self chooseSlotTypeFor: slotName asSymbol