list: arrayOfStrings
	"Set the receivers items to be the given list of strings."
	"Note: the instance variable 'items' holds the original list.
	 The instance variable 'list' is a paragraph constructed from
	 this list."

	isEmpty _ arrayOfStrings isEmpty.

	"add top and bottom delimiters"
	list _ ListParagraph withArray: (Array streamContents:
		[:s | s nextPut: topDelimiter.
		arrayOfStrings do: [:item | item == nil ifFalse: [s nextPut: item]].
		s nextPut: bottomDelimiter]).

	selection _ self getCurrentSelectionIndex.
	self positionList.