deleteFilter

	| filterList filterName |
	CustomFilters isEmpty ifTrue: [^''].
	filterList _ CustomFilters keys asOrderedCollection.
	filterName _ (CustomMenu selections: filterList)
		startUpWithCaption: 'Filter to delete?'.
	filterName = nil ifTrue: [^''].
	CustomFilters removeKey: filterName ifAbsent: [].