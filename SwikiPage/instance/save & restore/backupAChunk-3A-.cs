backupAChunk: aFile
	"We are positioned at the end of a chunk.  Read the size of this
chunk from its end.  Back up one chunk.  Return the position of the space
before the back number."

	| back pp aPiece isDigitFlag |
	aFile skip: -2.
	isDigitFlag _ false.
	[isDigitFlag] whileFalse:
	[aPiece := aFile next. aPiece isNil ifTrue: [^0].
	aPiece isDigit ifFalse: [aFile skip: -2] ifTrue: [isDigitFlag _
true].].
	"[aFile next isDigit] whileFalse: [aFile skip: -2]." "This was
Ted's elegant version.
									The
uglier one above is to be able to test backing up too far."
	aFile skip: -2.
	[pp _ aFile position + 1. aFile next isDigit] whileTrue: [
		aFile skip: -2].
	back  _ (aFile upTo: $!) asNumber.
	aFile position: pp; skip: 0-back.
	^ pp "now positioned at the end"