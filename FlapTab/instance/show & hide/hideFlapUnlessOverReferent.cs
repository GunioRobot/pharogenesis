hideFlapUnlessOverReferent
	"Hide the flap unless the mouse is over my referent."

	| aWorld where |
	(referent isInWorld and: 
		[where _ self outermostWorldMorph activeHand lastEvent cursorPoint.
			referent bounds containsPoint: (referent globalPointToLocal: where)])
				ifTrue: [^ self].
	(aWorld _ self world) ifNil: [^ self].  "In case flap tabs just got hidden"
	self referent delete.
	aWorld removeAccommodationForFlap: self.
	flapShowing _ false.
	self isInWorld ifFalse:
		[self inboard ifTrue: [aWorld addMorphFront: self]].
	self adjustPositionAfterHidingFlap