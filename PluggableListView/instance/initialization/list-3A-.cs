list: arrayOfStrings
	"Set the receivers items to be the given list of strings
	The instance variable 'items' holds the original list. The instance variable 'list' is a paragraph constructed from this list."

	((items == arrayOfStrings) "fastest" or: [items = arrayOfStrings]) ifTrue: [^ self].
	items _ arrayOfStrings.
	isEmpty _ arrayOfStrings isEmpty.

	"add top and bottom delimiters"
	list _ ListParagraph
		withArray:
			(Array streamContents: [:s |
				s nextPut: topDelimiter.
				arrayOfStrings do:
					[:item | item == nil ifFalse:
						[(item isMemberOf: MethodReference)  "A very specific fix for MVC"
							ifTrue: [s nextPut: item asStringOrText]
							ifFalse: [s nextPut: item]]].
				s nextPut: bottomDelimiter])
		 style: self assuredTextStyle.

	selection _ self getCurrentSelectionIndex.
	self positionList.