handleMouseUp: evt
	"Dispatch a mouseUp event."
	| oldFocus |
	clickState ~~ #idle ifTrue: [self checkForDoubleClick: evt].

	"drop morphs being carried, if any"
	self hasSubmorphs ifTrue: [self dropMorphsEvent: evt].
	mouseDownMorph = nil ifTrue: [^ self].

	oldFocus := mouseDownMorph.	"make sure that focus becomes nil."
	mouseDownMorph _ nil.  "mouse focus transaction ends when mouse goes up"
	oldFocus mouseUp: (self transformEvent: evt).
