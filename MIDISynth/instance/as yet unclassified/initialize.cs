initialize

	midiParser _ MIDIInputParser on: nil.
	channels _ (1 to: 16) collect: [:ch | MIDISynthChannel new initialize].
