animationForMoveSuccess: success 
	| start stop slideForm |
	success
		ifTrue: [^ self]
		ifFalse: 
			[start _ self fullBounds origin.
			stop _ self source bounds origin].
	start = stop ifTrue: [^ self].
	slideForm _ self imageFormForRectangle: ((self fullBounds origin corner: self fullBounds corner + self activeHand shadowOffset)
					merge: self activeHand bounds).
	slideForm offset: 0 @ 0.
	slideForm
		slideWithFirstFrom: start
		to: stop
		nSteps: 12
		delay: 20