next: anInteger 
	"Answer the next anInteger elements of my collection. Must override to get class right."

	| newArray |
self flag: #ByteString.
	newArray _ (isBinary ifTrue: [ByteArray] ifFalse: [String]) new: anInteger.
	^ self nextInto: newArray