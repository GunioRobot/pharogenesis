freeSlot: number
	number > 0 ifTrue: [
		lock critical: [
			(bars at: number) delete.
			(labels at: number) delete.
			activeSlots _ activeSlots - 1.
			activeSlots = 0
				ifTrue: [self delete]
				ifFalse: [self align: self fullBounds center with: Display boundingBox center]]]