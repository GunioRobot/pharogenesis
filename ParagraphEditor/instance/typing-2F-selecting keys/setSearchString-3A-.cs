setSearchString: characterStream
	"Establish the current selection as the current search string.  2/7/96 sw"

	| aString |
	sensor keyboard.		"flush character"
	aString _  self selection string.
	aString size == 0 ifTrue: [^ self flash].
	self setSearch: aString.
	^ true