toggleOnOff

	midiSynth isOn
		ifTrue: [
			midiSynth stopMIDITracking]
		ifFalse: [
			midiPortNumber ifNil: [self setMIDIPort].
			midiPortNumber ifNil: [midiPortNumber _ 0].
			midiSynth midiPort: (SimpleMIDIPort openOnPortNumber: midiPortNumber).
			midiSynth startMIDITracking].
