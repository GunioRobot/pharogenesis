editFilter

	| filterList filterName |
	CustomFilters isEmpty ifTrue: [^''].
	filterList _ CustomFilters keys asOrderedCollection.
	filterName _ (CustomMenu selections: filterList)
		startUpWithCaption: 'Filter to edit?'.
	filterName = nil ifTrue: [^''].
	^self editFilterNamed: filterName filterExpr: (CustomFilters at: filterName)