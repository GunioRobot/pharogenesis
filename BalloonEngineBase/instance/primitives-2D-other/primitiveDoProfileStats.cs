primitiveDoProfileStats
	"Turn on/off profiling. Return the old value of the flag."
	| oldValue newValue |
	self inline: false.
	self export: true.
	oldValue _ doProfileStats.
	newValue _ interpreterProxy stackObjectValue: 0.
	newValue _ interpreterProxy booleanValueOf: newValue.
	interpreterProxy failed ifFalse:[
		doProfileStats _ newValue.
		interpreterProxy pop: 2. "Pop rcvr, arg"
		interpreterProxy pushBool: oldValue.
	].