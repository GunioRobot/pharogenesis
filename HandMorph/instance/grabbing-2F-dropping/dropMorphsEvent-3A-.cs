dropMorphsEvent: evt
	"Drop all the morphs this hand is currently holding in response to the given event."
	"Details: All submorphs of the front-most composite morph under the hand are given an opportunity to accept the dropping morph. If none of these accepts it, or if there is no morph under the hand, then the morph drops into the world."

	| newOwner morphToDrop tfm localPt grabbedMorph pos |
	owner ifNil: [^ self].
	self changed.
	self submorphsReverseDo: [:m |
		"drop in reverse order to maintain back-to-front ordering"
		addedFlexAtGrab == true
			ifTrue: [pos _ m firstSubmorph position.
					grabbedMorph _ m removeFlexShell.
					self privateRemoveMorph: grabbedMorph.
					grabbedMorph position: pos  "undo offset from removeFlexShell"]
			ifFalse: [grabbedMorph _ m].
		newOwner _ self dropTargetFor: grabbedMorph event: evt.
		newOwner ifNil:  "Drop not allowed"
			[self rejectDropMorph: grabbedMorph event: evt.
			addedFlexAtGrab == true
			ifTrue: [self privateRemoveMorph: m.
					addedFlexAtGrab _ false].
			^ self].

		morphToDrop _ newOwner morphToDropFrom: grabbedMorph. 
		morphToDrop == grabbedMorph ifFalse: [submorphs size == 1 ifTrue:
			[self privateRemoveMorph: m.
			m privateOwner: nil.
			addedFlexAtGrab _ false]].
		"the above says: the thing to drop is not what I was carrying; silently vaporize what I was carrying lest it cause trouble later; keep the owner/submorph relationship invariant, but don't go through the standard delete protocol"

		tfm _ newOwner transformFromWorld.
		localPt _ tfm globalPointToLocal: self position.
		addedFlexAtGrab == true
			ifTrue: [morphToDrop position: localPt
			 			+ (morphToDrop position - (m transform globalPointToLocal: self position)).
					self privateRemoveMorph: m.
					addedFlexAtGrab _ false]
			ifFalse: [morphToDrop position: localPt + (morphToDrop position - self position)].
		newOwner acceptDroppingMorph: morphToDrop event: evt.
		morphToDrop justDroppedInto: newOwner event: evt.
		morphToDrop owner = self ifTrue: [self world addMorphFront: m]].
	self layoutChanged.
	formerOwner _ nil.
	formerPosition _ nil