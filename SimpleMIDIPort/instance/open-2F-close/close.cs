close
	"Close this MIDI port."

	portNumber ifNotNil: [self primMIDIClosePort: portNumber].
	accessSema _ nil.
	lastCommandByteOut _ nil.
