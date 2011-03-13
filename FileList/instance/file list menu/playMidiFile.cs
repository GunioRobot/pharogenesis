playMidiFile
	"Play a MIDI file."
 
	| f score |
	Smalltalk at: #MIDIFileReader ifPresent: [:midiReader |
		Smalltalk at: #ScorePlayerMorph ifPresent: [:scorePlayer |
			f _ (directory readOnlyFileNamed: self fullName) binary.
			score _ (midiReader new readMIDIFrom: f) asScore.
			f close.
			scorePlayer openOn: score title: fileName]].
