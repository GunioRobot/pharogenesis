primitiveMIDIGetClock
	"Return the value of the MIDI clock as a SmallInteger. The range is limited to SmallInteger maxVal / 2 to allow scheduling MIDI events into the future without overflowing a SmallInteger. The sqMIDIGetClock function is assumed to wrap at or before 16r20000000."

	| clockValue |
	clockValue _ self sqMIDIGetClock bitAnd: 16r1FFFFFFF.
	successFlag ifTrue: [
		self pop: 1.  "pop rcvr"
		self pushInteger: clockValue].
