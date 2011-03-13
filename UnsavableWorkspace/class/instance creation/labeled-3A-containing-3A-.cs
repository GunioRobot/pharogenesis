labeled: aLabel containing: aString
	"Open an unsavable workspace with the given label and contents.  1/17/96 sw"

	StringHolderView open: (self new contents: aString copy) label: aLabel 