newSliderValue: newValue
	"Send a control command out the MIDI port."

	| val |
	midiPort ifNil: [^ self].
	val _ newValue asInteger.
	lastValue = val ifTrue: [^ self].
	lastValue _ val.
	midiPort midiCmd: 16rB0 channel: channel byte: controller byte: val.
