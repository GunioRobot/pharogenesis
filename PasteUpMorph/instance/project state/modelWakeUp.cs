modelWakeUp

	| aWindow |
	"I am the model of a SystemWindow, that has just been activated"
	owner == nil ifTrue: [^ self].  "Not in Morphic world"
	(owner isKindOf: TransformMorph) ifTrue: [^ self viewBox: self fullBounds].
	(aWindow _ self containingWindow) ifNotNil:
		[self viewBox = aWindow panelRect ifFalse:
			[self viewBox: aWindow panelRect]]