hideFlapUnlessOverReferent
	| aWorld |
	(referent isInWorld and: [referent bounds containsPoint: self world activeHand lastEvent cursorPoint])
		ifFalse:
			[aWorld _ self world.
			self referent delete.
			aWorld removeAccommodationForFlap: self.
			flapShowing _ false.
			self isInWorld ifFalse:
				[self inboard ifTrue: [aWorld addMorphFront: self]].
			self adjustPositionAfterHidingFlap]