setMIDIPort

	| portNum |
	portNum _ SimpleMIDIPort outputPortNumFromUser.
	portNum ifNil: [^ self].
	midiPortNumber _ portNum.
