list: arrayOfStrings
	"Set the receivers items to be the given list of strings."
	"Note: the instance variable 'itemsList' holds the original list.
	 The instance variable 'items' is a paragraph constructed from
	 this list."

	| s |
	items _ arrayOfStrings.
	isEmpty _ arrayOfStrings isEmpty.

	s _ WriteStream on: Array new.
	"add top and bottom delimiters"
	s nextPut: topDelimiter.
	arrayOfStrings do: [:item |
		item == nil ifFalse: [s nextPut: item].
	].
	s nextPut: bottomDelimiter.
	list _ ListParagraph withArray: s contents.

	selection _ self getCurrentSelectionIndex.
	self positionList.