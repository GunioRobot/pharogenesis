padToNextWord
	"Make position even (on word boundary), answering the padding 
	character if any."

	self position even
		ifTrue: [^false]
		ifFalse: [^self next]