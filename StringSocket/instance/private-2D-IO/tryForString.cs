tryForString
	"try to grab an actual string"

	self inBufSize >= nextStringSize ifFalse: [^false].

	stringsForNextArray 
		at: (stringCounter _ stringCounter + 1)
		put: (self inBufNext: nextStringSize) asString.

	stringCounter = numStringsInNextArray ifTrue: [	"we have finished another array!"
		inObjects addLast: stringsForNextArray.
		stringCounter _ stringsForNextArray _ numStringsInNextArray _ nextStringSize _ nil.
	] ifFalse: [	"still need more strings for this array"
		nextStringSize _ nil.
	].

	^true
