saveCurrentFilter
	"save the current filter as a named filter"
	| currentNames name nameIndex |
	self selectedActiveFilter ifNil: [ ^self ].

	currentNames := NamedFilters keys asSortedArray.
	nameIndex := (PopUpMenu labelArray: (#('<new>') , currentNames))
				startUpWithCaption: 'Name to save this filter under?'.

	nameIndex = 0 ifTrue: [ ^self ].
	nameIndex = 1
		ifTrue: [ 
			name := FillInTheBlank request: 'Name to save this filter under?'.
			name isEmpty ifTrue: [ ^self ]. ]
		ifFalse: [ 
			name := currentNames at: nameIndex-1 ].

	NamedFilters at: name put: self selectedActiveFilter.

	self changed: #activeFilterDescriptions .
