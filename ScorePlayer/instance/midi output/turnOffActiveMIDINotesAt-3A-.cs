turnOffActiveMIDINotesAt: scoreTick
	"Turn off any active MIDI notes that should be turned off at the given score tick."

	| evt someNoteEnded |
	midiPort ifNil: [^ self].
	someNoteEnded _ false. 
	activeMIDINotes do: [:pair |
		evt _ pair first.
		evt endTime <= scoreTick ifTrue: [
			evt endNoteOnMidiPort: midiPort.
			someNoteEnded _ true]].

	someNoteEnded ifTrue: [
		activeMIDINotes _ activeMIDINotes select: [:p | p first endTime > scoreTick]].
