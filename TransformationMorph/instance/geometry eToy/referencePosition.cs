referencePosition
	"Answer the  receiver's reference position, bullet-proofed against infinite recursion in the unlikely but occasionally-seen case that I am my own renderee"

	| rendered |
	^ (rendered _ self renderedMorph) == self
		ifTrue:
			[super referencePosition]
		ifFalse:
			[transform localPointToGlobal: rendered referencePosition]