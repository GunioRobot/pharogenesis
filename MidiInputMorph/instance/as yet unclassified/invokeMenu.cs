invokeMenu
	"Invoke a menu of additonal commands."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu add: 'add channel' translated action: #addChannel.
	aMenu add: 'reload instruments' translated target: AbstractSound selector: #updateScorePlayers.
	midiSynth isOn ifFalse: [
		aMenu add: 'set MIDI port' translated action: #setMIDIPort.
		midiSynth midiPort
			ifNotNil: [aMenu add: 'close MIDI port' translated action: #closeMIDIPort]].	
	aMenu invokeOn: self defaultSelection: nil.
