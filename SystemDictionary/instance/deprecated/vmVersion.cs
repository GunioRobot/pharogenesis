vmVersion	"Smalltalk vmVersion nil"
	"Return a string identifying the interpreter version"
	self deprecated: 'Use SmalltalkImage current vmVersion'.
	^self getSystemAttribute: 1004