compiledMethodFor: aString in: aContext to: aReceiver
	"evaluate aString in the given context, and return the result.  2/2/96 sw"
	| result |
	result _ self
				compiledMethodFor: aString 
				in: aContext 
				to: aReceiver 
				notifying: nil
				ifFail: [^#Failed] 
				logged: false.
	^ result