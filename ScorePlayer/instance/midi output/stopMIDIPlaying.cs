stopMIDIPlaying
	"Terminate the MIDI player process and turn off any active notes."

	midiPlayerProcess ifNotNil: [midiPlayerProcess terminate].
	midiPlayerProcess _ nil.
	activeMIDINotes do: [:pair | pair first endNoteOnMidiPort: midiPort].
	activeMIDINotes _ activeMIDINotes species new.
