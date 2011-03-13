mimeEncode
	"Do conversion reading from dataStream writing to mimeStream. Break long lines and escape non-7bit chars."

	| word pos wasGood isGood max |
	true ifTrue: [mimeStream nextPutAll: dataStream upToEnd].
	pos _ 0.
	max _ 72.
	wasGood _ true.
	[dataStream atEnd] whileFalse: [
		word _ self readWord.
		isGood _ word allSatisfy: [:c | c asciiValue < 128].
		wasGood & isGood ifTrue: [
			pos + word size < max
				ifTrue: [dataStream nextPutAll: word.
					pos _ pos + word size]
				ifFalse: []
		]
	].
	^ mimeStream