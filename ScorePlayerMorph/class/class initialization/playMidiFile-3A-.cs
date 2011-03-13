playMidiFile: fullName
	"Play a MIDI file."
 
	| f score |
	Smalltalk at: #MIDIFileReader ifPresent: [:midiReader |
			f := (FileStream oldFileNamed: fullName) binary.
			score := (midiReader new readMIDIFrom: f) asScore.
			f close.
			self openOn: score title: (FileDirectory localNameFor: fullName)]
