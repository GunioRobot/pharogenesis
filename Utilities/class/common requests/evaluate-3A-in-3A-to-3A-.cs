evaluate: aString in: aContext to: aReceiver
	"evaluate aString in the given context, and return the result.  2/2/96 sw"
	| result |
	result _ Compiler new
				evaluate: aString
				in: aContext
				to: aReceiver
				notifying: nil
				ifFail: [^ #failedDoit].
	^ result