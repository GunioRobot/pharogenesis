backupAChunk: aFile
	"We are positioned at the end of a chunk.  Read the size of this chunk from its end.  Back up one chunk.  Return the position of the space before the back number."

	| back pp |
	aFile skip: -2.
	[aFile next isDigit] whileFalse: [aFile skip: -2].
	aFile skip: -2.
	[pp _ aFile position + 1. aFile next isDigit] whileTrue: [
		aFile skip: -2].
	back  _ (aFile upTo: $!) asNumber.
	aFile position: pp; skip: 0-back.
	^ pp "now positioned at the end"