playMidiFile: fullName
	"Play a MIDI file."
 
	| f score |
	Smalltalk at: #MIDIFileReader ifPresent: [:midiReader |
			f _ (FileStream oldFileNamed: fullName) binary.
			score _ (midiReader new readMIDIFrom: f) asScore.
			f close.
			self openOn: score title: (FileDirectory localNameFor: fullName)]
