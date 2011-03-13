unhighlight

	self currentSelectionDo:
		[:innerMorph :mouseDownLoc :outerMorph |
		(self == outerMorph or: [owner notNil and: [owner isSyntaxMorph not]])
			ifTrue: [self borderColor: #raised]
			ifFalse: [self borderColor: self stdBorderColor]]