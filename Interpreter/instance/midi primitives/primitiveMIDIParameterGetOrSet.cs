primitiveMIDIParameterGetOrSet
	"Behaviour depends on argument count:
		1 arg:	return the indicated MIDI parameter
		2 args:	set the indicated MIDI parameter to the given value"

	| whichParameter currentValue newValue |
	argumentCount = 1 ifTrue: [  "read parameter"
		whichParameter _ self stackIntegerValue: 0.
		successFlag ifFalse: [^ nil].
		currentValue _ self cCode: 'sqMIDIParameter(whichParameter, false, 0)'.
		successFlag ifTrue: [
			self pop: 2.  "pop rcvr, whichParameter"
			self pushInteger: currentValue].
		^ nil].

	argumentCount = 2 ifTrue: [  "write parameter"
		newValue			_ self stackIntegerValue: 0.
		whichParameter		_ self stackIntegerValue: 1.
		successFlag ifFalse: [^ nil].
		self cCode: 'sqMIDIParameter(whichParameter, true, newValue)'.
		successFlag ifTrue: [
			self pop: 2].  "pop whichParameter, newValue; leave rcvr on stack"
		^ nil].

	self primitiveFail.  "bad argument count"
