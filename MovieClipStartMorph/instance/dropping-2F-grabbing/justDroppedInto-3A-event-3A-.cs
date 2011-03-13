justDroppedInto: newOwner event: evt
	| pianoRoll syncMorph |
	"When dropping this morph into a pianoRoll, add a corresponding
	event to the score so that it will always appear when played,
	in addition to possibly triggering other actions"

	(newOwner isKindOf: PianoRollScoreMorph)
	ifTrue:
		[pianoRoll := newOwner.
		pianoRoll movieClipPlayer ifNil:
			["This PianoRoll is not a clip player -- replace me by a SyncMorph"
			syncMorph := MovieFrameSyncMorph new
						image: image
						player: moviePlayerMorph
						frameNumber: frameNumber.
			pianoRoll replaceSubmorph: self by: syncMorph.
			"rewrite to use justDroppedInto:..."
			pianoRoll score removeAmbientEventWithMorph: self;
					addAmbientEvent: (scoreEvent
						morph: syncMorph;
						time: (pianoRoll timeForX: self left)).
			^ self].

		self movieClipPlayer: pianoRoll movieClipPlayer.
		self setTimeInScore: pianoRoll score
					near: (pianoRoll timeForX: self left).
		self endTime > newOwner scorePlayer durationInTicks ifTrue:
			[newOwner scorePlayer updateDuration]]
	ifFalse:
		["Dropped it somewhere else -- delete related morphs"
		endMorph ifNotNil: [endMorph delete].
		soundTrackMorph ifNotNil: [soundTrackMorph delete]].

	super justDroppedInto: newOwner event: evt
