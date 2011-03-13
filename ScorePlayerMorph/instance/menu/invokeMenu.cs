invokeMenu
	"Invoke a menu of additonal functions for this WaveEditor."
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu add: 'reload instruments' target: AbstractSound selector: #updateScorePlayers.
	aMenu add: 'open a MIDI file' action: #openMIDIFile.
	scorePlayer midiPort
		ifNil: [
			aMenu add: 'play via MIDI' action: #openMIDIPort]
		ifNotNil: [
			aMenu add: 'play via built in synth' action: #closeMIDIPort.
			aMenu add: 'new MIDI controller' action: #makeMIDIController:].
	aMenu addLine.
	aMenu add: 'make a pause marker' action: #makeAPauseEvent:.

	aMenu popUpInWorld: self world.