editFilter

	| filterName |
	mailDB ifNil: [ ^self ].

	filterName _ (CustomMenu selections: self customFilterNames)
		startUpWithCaption: 'Filter to edit?'.
	filterName = nil ifTrue: [^''].
	^self editFilterNamed: filterName