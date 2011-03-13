getListAndDisplayView
	"Display the list of items."

	| newList |
	newList _ self getList.
	isEmpty & newList isEmpty
		ifTrue: [^self]
		ifFalse: 
			[self list: newList.
			self displayView; emphasizeView]