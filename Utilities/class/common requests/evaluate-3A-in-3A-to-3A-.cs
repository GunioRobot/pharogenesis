evaluate: aString in: aContext to: aReceiver
	"evaluate aString in the given context, and return the result.  2/2/96 sw"
	
	self deprecated: 'Use Compiler>>evaluate: aString in: aContext to: aReceiver'.
	^ Compiler new evaluate: aString in: aContext to: aReceiver