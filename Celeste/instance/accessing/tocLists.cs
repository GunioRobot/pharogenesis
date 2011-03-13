tocLists
	"Generated - Return the value of tocLists."

	tocLists == nil ifTrue: [self initializeTocLists].
	^tocLists