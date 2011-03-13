list: arrayOfLists 
	| listOfStrings arrayOfMorphs index |
	lists _ arrayOfLists.
	scroller removeAllMorphs.
	listOfStrings _ arrayOfLists == nil
				ifTrue: [Array new]
				ifFalse: [
					arrayOfLists isEmpty ifFalse: [
					arrayOfLists at: 1]].
	list _ listOfStrings
				ifNil: [Array new].
	list isEmpty
		ifTrue: [self setScrollDeltas.
			^ self selectedMorph: nil].
	arrayOfMorphs _ self createMorphicListsFrom: arrayOfLists.
	self layoutMorphicLists: arrayOfMorphs.
	arrayOfMorphs
		do: [:morphList | scroller addAllMorphs: morphList].
	self
		installEventHandlerOn: (arrayOfMorphs at: 1).
	index _ self getCurrentSelectionIndex.
	self
		selectedMorph: ((index = 0
					or: [index > (arrayOfMorphs at: 1) size])
				ifFalse: [(arrayOfMorphs at: 1)
						at: index]).
	self setScrollDeltas.
	scrollBar setValue: 0.0