next: anInteger 
	"Answer the next anInteger elements of my collection. Must override to get class right."

	| newArray |
	newArray _ (isBinary ifTrue: [ByteArray] ifFalse: [String]) new: anInteger.
	1 to: anInteger do: [:index | newArray at: index put: self next].
		"Could be done faster than this!"
	^newArray