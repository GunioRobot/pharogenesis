list: arrayOfLists 
	| listOfStrings |
	lists _ arrayOfLists.
	scroller removeAllMorphs.
	listOfStrings _ arrayOfLists == nil
				ifTrue: [Array new]
				ifFalse: [
					arrayOfLists isEmpty ifFalse: [
					arrayOfLists at: 1]].
	list _ listOfStrings
				ifNil: [Array new].
	self listMorph listChanged..

	self setScrollDeltas.
	scrollBar setValue: 0.0