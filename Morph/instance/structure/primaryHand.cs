primaryHand
	^ self activeHand ifNil: [self world firstHand]