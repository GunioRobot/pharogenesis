addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	midiPort
		ifNil: [aCustomMenu add: 'play via MIDI' action: #openMIDIPort]
		ifNotNil: [
			aCustomMenu add: 'play via built in synth' action: #closeMIDIPort.
			aCustomMenu add: 'new MIDI controller' action: #makeMIDIController:].
