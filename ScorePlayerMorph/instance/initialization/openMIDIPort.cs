openMIDIPort

	| portNum |
	portNum _ SimpleMIDIPort outputPortNumFromUser.
	portNum ifNil: [^ self].
	scorePlayer openMIDIPort: portNum.
	LastMIDIPort _ portNum.
