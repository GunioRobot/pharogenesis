renameGraphicTo: newName
	| curr |
	curr _ entryNames at: currentIndex.
	(newName isEmptyOrNil or: [newName = curr]) ifTrue: [^ Beeper beep].
	(baseDictionary includesKey: newName) ifTrue:
		[^ self inform: 'sorry that conflicts with
the name of another
entry in this dictionary'].
	baseDictionary at: newName put: (baseDictionary at: curr).
	baseDictionary removeKey: curr.
	self baseDictionary: baseDictionary.
	currentIndex _ entryNames indexOf: newName.
	self updateThumbnail