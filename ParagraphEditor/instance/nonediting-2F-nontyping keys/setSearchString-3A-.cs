setSearchString: characterStream
	"Establish the current selection as the current search string."

	| aString |
	self closeTypeIn: characterStream.
	self lineSelectAndEmptyCheck: [^ true].
	aString :=  self selection string.
	aString size == 0
		ifTrue:
			[self flash]
		ifFalse:
			[self setSearch: aString].
	^ true