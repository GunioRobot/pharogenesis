preambleTemplate
	"Answer a string that will form the default contents for a change set's preamble.  Just a first stab at what the content should be.12/3/96 sw"

	| aStream |
	aStream _ ReadWriteStream on: ''.
	aStream nextPutAll: '"Change Set:'.
	aStream tab;tab; nextPutAll: self name.
	aStream cr; nextPutAll: 'Date:'; tab; tab; tab; nextPutAll: Date today printString.
	aStream cr; nextPutAll: 'Author:'; tab; tab; tab; nextPutAll: 'Your Name'.
	aStream cr; cr; nextPutAll: '<your descriptive text goes here>"'.
	^ aStream contents
"Smalltalk changes preambleTemplate"