doesNotUnderstand: aMessage
	"Look up the message selector as a flag."

	^ self valueOfFlag: aMessage selector
