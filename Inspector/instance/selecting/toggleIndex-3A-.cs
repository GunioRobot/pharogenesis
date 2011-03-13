toggleIndex: anInteger
	"The receiver has a list of variables of its inspected object. One of these 
	is selected. If anInteger is the index of this variable, then deselect it. 
	Otherwise, make the variable whose index is anInteger be the selected 
	item."

	selectionIndex = anInteger
		ifTrue: 
			["same index, turn off selection"
			selectionIndex _ 0.
			contents _ '']
		ifFalse:
			["different index, new selection"
			selectionIndex _ anInteger.
			(selectionIndex = 2) | (selectionIndex = 0)
				ifTrue: [contents _ self selection]
				ifFalse: [contents _ self selection printString]].
	self changed: #selection.
	self changed: #contents.
	self changed: #selectionIndex.