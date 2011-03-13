playMidiFile
	"Play a midi file."
 
	Smalltalk at: #MIDIFileReader ifPresent: [:midiReaderClass |
		midiReaderClass playMidiStream: (directory oldFileNamed: self fullName) 
				title: fileName].
