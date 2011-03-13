findSelection: aPoint 
	"Refer to the comment in ListView|findSelection:."

	singleItemMode
		ifTrue: 
			[self flash.
			^nil]
		ifFalse: [^super findSelection: aPoint]