list: aCollection

	| wereExpanded morphList |
	wereExpanded _ self currentlyExpanded.
	scroller removeAllMorphs.
	(aCollection isNil or: [aCollection isEmpty]) ifTrue: [^ self selectedMorph: nil].
	morphList _ self 
			morphsFromCollection: aCollection 
			allowSorting: false
			withExpandedItems: wereExpanded.
	self insertNewMorphs: morphList.
	self installEventHandlerOn: morphList