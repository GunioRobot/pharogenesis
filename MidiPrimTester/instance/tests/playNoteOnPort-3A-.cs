playNoteOnPort: portNum
	"MidiPrimTester new playNoteOnPort: 0"

	| noteOn noteOff bytesWritten |
	noteOn _ #(144 60 100) as: ByteArray.
	noteOff _ #(144 60 0) as: ByteArray.
	self openPort: portNum andDo: [
		bytesWritten _ self primMIDIWritePort: portNum from: noteOn at: 0.
		(Delay forMilliseconds: 500) wait.
		bytesWritten _ bytesWritten + (self primMIDIWritePort: portNum from: noteOff at: 0)].

	bytesWritten = 6 ifFalse: [self error: 'not all bytes were sent'].
