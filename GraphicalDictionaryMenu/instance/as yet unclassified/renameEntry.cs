renameEntry
	| reply curr |
	reply _ FillInTheBlankMorph  request: 'New key? '
		initialAnswer: (curr _ entryNames at: currentIndex)
		centerAt: self center.
	(reply isEmptyOrNil or: [reply = curr]) ifTrue: [^ self beep].
	(baseDictionary includesKey: reply) ifTrue:
		[^ self inform: 'sorry that conflicts with
the name of another
entry in this dictionary'].
	baseDictionary at: reply put: (baseDictionary at: curr).
	baseDictionary removeKey: curr.
	self baseDictionary: baseDictionary.
	self updateThumbnail