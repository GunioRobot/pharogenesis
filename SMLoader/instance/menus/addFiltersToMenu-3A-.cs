addFiltersToMenu: aMenu
	| filterSymbol help |
	self filterSpecs do: [:filterArray | 
		filterSymbol := filterArray second.
		help := filterArray third.
		aMenu addUpdating: #showFilterString: target: self selector: #toggleFilterState: argumentList: (Array with: filterSymbol).
		aMenu balloonTextForLastItem: help].
	aMenu addLine;
		addList: #(('uncheck all filters' uncheckFilters 'unchecks all filters so that all packages are listed'))
	