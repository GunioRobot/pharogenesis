invokeMenu
	"Invoke a menu of additonal functions for this WaveEditor."
	| aMenu |
	aMenu _ CustomMenu new.
	aMenu add: 'reload instruments' action: #updateInstrumentsFromLibrary.
	aMenu add: 'open a MIDI file' action: #openMIDIFile.
	scorePlayer midiPort
		ifNil: [
			aMenu add: 'play via MIDI' action: #openMIDIPort]
		ifNotNil: [
			aMenu add: 'play via built in synth' action: #closeMIDIPort.
			aMenu add: 'new MIDI controller' action: #makeMIDIController:].
	aMenu invokeOn: self defaultSelection: nil.
