setSearchString: characterStream
	"Establish the current selection as the current search string."

	| aString |
	sensor keyboard.
	self lineSelectAndEmptyCheck: [^ true].
	aString _  self selection string.
	aString size == 0
		ifTrue:
			[self flash]
		ifFalse:
			[self setSearch: aString].
	^ true