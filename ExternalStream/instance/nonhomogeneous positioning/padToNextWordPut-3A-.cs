padToNextWordPut: char
	"Make position even on word boundary, writing the padding character, 
	char, if necessary."

	self position even
		ifTrue: [^nil]
		ifFalse: [^self nextPut: char]