makePianoRoll
	"Create a piano roll viewer for this score player."

	| pianoRoll hand |
	pianoRoll _ PianoRollScoreMorph new on: scorePlayer.
	hand _ self world activeHand.
	hand ifNil: [self world addMorph: pianoRoll]
		ifNotNil: [hand attachMorph: pianoRoll.
				hand lastEvent shiftPressed ifTrue:
					["Special case for NOBM demo"
					pianoRoll contractTime; contractTime; enableDragNDrop]].
	pianoRoll startStepping.
