closeAllPorts
	"Close all MIDI ports."
	"SimpleMIDIPort closeAllPorts"

	| lastPortNum |
	lastPortNum _ self primPortCount - 1.
	0 to: lastPortNum do: [:portNum | self basicNew primMIDIClosePort: portNum].
