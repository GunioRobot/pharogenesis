addNamedFilter
	| name filter |
	mailDB ifNil: [^self].
	name := (SelectionMenu selections: NamedFilters keys asSortedArray) 
				startUpWithCaption: 'name of filter to add?'.
	name ifNil: [^self].
	filter := NamedFilters at: name.
	(self activeFilters includes: filter) 
		ifTrue: 
			[self inform: 'That filter is already included'.
			^self].
	self addFilter: filter