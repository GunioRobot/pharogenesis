preambleString
	"Answer the string representing the preamble"

	^ preamble == nil
		ifTrue:
			[preamble]
		ifFalse:
			[preamble contents asString]