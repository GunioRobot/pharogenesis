editFilterNamed: filterName
	| expr |
	(CustomFilters includesKey: filterName)
		ifTrue: [expr _ CustomFilters at: filterName]
		ifFalse: [expr _ ''].
	^ self editFilterNamed: filterName filterExpr: expr