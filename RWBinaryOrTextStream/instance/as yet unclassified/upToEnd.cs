upToEnd
	"Must override to get class right."
	| newArray |
	newArray _ (isBinary ifTrue: [ByteArray] ifFalse: [String]) new: self size - self position.
	^ self nextInto: newArray