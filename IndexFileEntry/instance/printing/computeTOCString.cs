computeTOCString
	"Answer a string for the table of contents."
	"IndexFileEntry allInstancesDo: [: e | e flushTOCCache]"

	| fromFieldSize s |
	fromFieldSize _ 18.
	s _ WriteStream on: (String new: 200).
	s nextPutAll: self dateString.
	[s position < 9] whileTrue: [s space].
	s nextPutAll: (self fromStringLimit: fromFieldSize).
	[s position <= (9 + fromFieldSize + 2)] whileTrue: [s space].
	s nextPutAll: subject.
	^ s contents
