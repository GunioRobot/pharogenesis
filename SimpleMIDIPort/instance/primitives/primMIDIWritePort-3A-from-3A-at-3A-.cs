primMIDIWritePort: portNum from: byteArray at: midiClockValue
	"Queue the given data to be sent through the given MIDI port at the given time. If midiClockValue is zero, send the data immediately."

	<primitive: 529>
	self primitiveFailed.
