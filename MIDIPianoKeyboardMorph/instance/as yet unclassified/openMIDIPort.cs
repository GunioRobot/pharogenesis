openMIDIPort

	| portNum |
	portNum _ SimpleMIDIPort outputPortNumFromUser.
	portNum ifNil: [^ self].
	midiPort _ SimpleMIDIPort openOnPortNumber: portNum.
