highlightForDrop: evt

	(self wantsDroppedMorph: evt hand firstSubmorph event: evt)
		ifTrue: [self borderColor: self dropColor].