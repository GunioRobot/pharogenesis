justDroppedInto: newOwner event: evt 
	| pianoRoll |
	"When dropping this morph into a pianoRoll, add a corresponding
	event to the score so that it will always appear when played,
	in addition to possibly triggering other actions"

	(self isMemberOf: MovieFrameSyncMorph) ifFalse:
		[^ super justDroppedInto: newOwner event: evt].

	(newOwner isKindOf: PianoRollScoreMorph)
	ifTrue:
		["Legacy code for existing sync morphs"
		pianoRoll := newOwner.
		pianoRoll score
			removeAmbientEventWithMorph: self;
			addAmbientEvent: (AmbientEvent new
						morph: self;
						time: (pianoRoll timeForX: self left))].

	super justDroppedInto: newOwner event: evt
