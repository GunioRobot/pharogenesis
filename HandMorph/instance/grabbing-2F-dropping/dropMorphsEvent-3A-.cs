dropMorphsEvent: evt
	"Drop all the morphs this hand is currently holding in response to the given event."
	"Details: All submorphs of the front-most composite morph under the hand are given an opportunity to accept the dropping morph. If none of these accepts it, or if there is no morph under the hand, then the morph drop drops into the world."

	| targetM |
	owner ifNil: [^ self].  "there is no world to drop the morphs into"
	self changed.
	self submorphsReverseDo: [:m |
		"drop in reverse order to maintain back-to-front ordering"
		targetM _ self dropTargetFor: m event: evt.
		targetM acceptDroppingMorph: m event: evt.
		m justDroppedInto: targetM event: evt.
		m owner = self ifTrue: [self world addMorphFront: m]].
	self layoutChanged.