isExecutingBlock
	"Is this executing a block versus a method"

	| r |
	Smalltalk at: #BlockClosure ifPresent:[:aClass|
		^((r _ self receiver) isKindOf: aClass) and: [r method == self method]
	].
	^false