deleteFilter

	| filterName |
	mailDB ifNil: [ ^nil].
	self customFilterNames size = 0 ifTrue: [ "nothing available to delete" ^nil ].

	filterName _ (CustomMenu selections: self customFilterNames)
		startUpWithCaption: 'Filter to delete?'.
	filterName ifNil: [^nil].
	NamedFilters removeKey: filterName ifAbsent: [].

	^nil
