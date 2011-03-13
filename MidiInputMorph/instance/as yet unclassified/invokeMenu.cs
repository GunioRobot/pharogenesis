invokeMenu
	"Invoke a menu of additonal commands."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu add: 'add channel' action: #addChannel.
	aMenu add: 'reload instruments' target: AbstractSound selector: #updateScorePlayers.
	midiSynth isOn ifFalse: [
		aMenu add: 'set MIDI port' action: #setMIDIPort.
		midiSynth midiPort
			ifNotNil: [aMenu add: 'close MIDI port' action: #closeMIDIPort]].	
	aMenu invokeOn: self defaultSelection: nil.
