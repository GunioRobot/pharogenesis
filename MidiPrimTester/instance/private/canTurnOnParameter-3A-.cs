canTurnOnParameter: whichParameter
	"Return true if the given MIDI parameter can be turned on. Leave the parameter in its orginal state."

	| old canSet |
	old _ self primMIDIParameterGet: whichParameter.
	self primMIDIParameterSet: whichParameter to: 1.
	canSet _ (self primMIDIParameterGet: whichParameter) = 1.
	self primMIDIParameterSet: whichParameter to: old.
	^ canSet
