back
	"Go back one element and return it.  Use indirect messages in case I am a StandardFileStream"

	self position = 0 ifTrue: [self errorCantGoBack].
	self position = 1 ifTrue: [self position: 0.  ^ nil].
	self skip: -2.
	^ self next
