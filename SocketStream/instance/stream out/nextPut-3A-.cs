nextPut: char
	"Put a single Character or byte onto the stream."

	| toPut |
	toPut _ binary ifTrue: [char asInteger] ifFalse: [char asCharacter].
	self adjustOutBuffer: 1.
	outBuffer at: outNextToWrite put: toPut.
	outNextToWrite _ outNextToWrite + 1.
	self checkFlush.
	"return the argument - added by kwl"
	^ char