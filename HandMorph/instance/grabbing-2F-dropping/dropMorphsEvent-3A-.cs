dropMorphsEvent: evt
	"Drop all the morphs this hand is currently holding in response to the given event."
	"Details: All submorphs of the front-most composite morph under the hand are given an opportunity to accept the dropping morph. If none of these accepts it, or if there is no morph under the hand, then the morph drops into the world."

	| targetM toDrop |
	owner ifNil: [^ self].
	self changed.
	self submorphsReverseDo: [:m |
		"drop in reverse order to maintain back-to-front ordering"
		targetM _ self dropTargetFor: m event: evt.
		targetM ifNil:  "Drop not allowed"
			[^ self rejectDropMorph: m event: evt].

		toDrop _ targetM morphToDropFrom: m. 
		toDrop == m ifFalse: [submorphs size == 1 ifTrue: [self privateRemoveMorph: m]].
		"the above says: the thing to drop is not what I was carrying; silently vaporize what I was carrying lest it cause trouble later"
		targetM acceptDroppingMorph: toDrop event: evt.
		toDrop justDroppedInto: targetM event: evt.
		toDrop owner = self ifTrue: [self world addMorphFront: m]].
	self layoutChanged.
	formerOwner _ nil.
	formerPosition _ nil