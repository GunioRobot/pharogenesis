soundForMidiKey: midiKey dur: d loudness: l
	"Answer an initialized sound object that generates a note for the given MIDI key (in the range 0..127), duration (in seconds), and loudness (in the range 0.0 to 1.0)."

	| keymap note |
	l >= loudThreshold
		ifTrue: [
			d >= sustainedThreshold
				ifTrue: [keymap _ sustainedLoud]
				ifFalse: [keymap _ staccatoLoud]]
		ifFalse: [
			d >= sustainedThreshold
				ifTrue: [keymap _ sustainedSoft]
				ifFalse: [keymap _ staccatoSoft]].
	keymap ifNil: [keymap _ sustainedLoud].
	note _ (keymap at: midiKey) copy.
	^ note
		setPitch: (AbstractSound pitchForMIDIKey: midiKey)
		dur: d
		loudness: (l * note gain)
