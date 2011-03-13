removeFromTestList
	mainIndex = 0
		ifTrue: [^ self].
	(self confirm: 'Really delete row ' , mainIndex printString , '?')
		ifFalse: [^ self].
	1
		to: theList size
		do: [:index | (theList at: index)
				removeAt: mainIndex].
	self changed: #listArray.
	self mainListIndex: 0