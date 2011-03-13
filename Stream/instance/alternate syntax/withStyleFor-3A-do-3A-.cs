withStyleFor: elementType do: aBlock

	^aBlock value		"in case a regular stream is used to print parse nodes"
">>
(Compiler new compile: 'blah ^self' in: String notifying: nil ifFail: []) printString
<<"