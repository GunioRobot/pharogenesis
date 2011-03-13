turnOffActiveMIDINotesAt: scoreTick
	"Turn off any active MIDI notes that should be turned off at the given score tick."

	| evt someNoteEnded |
	midiPort ifNil: [^ self].
	someNoteEnded := false. 
	activeMIDINotes do: [:pair |
		evt := pair first.
		evt endTime <= scoreTick ifTrue: [
			evt endNoteOnMidiPort: midiPort.
			someNoteEnded := true]].

	someNoteEnded ifTrue: [
		activeMIDINotes := activeMIDINotes select: [:p | p first endTime > scoreTick]].
