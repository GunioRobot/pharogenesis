renameEntry
	| reply curr |
	reply _ FillInTheBlank
		request: 'New key? '
		initialAnswer: (curr _ entryNames at: currentIndex)
		centerAt: self center.
	(reply isEmptyOrNil or: [reply = curr]) ifTrue: [^ Beeper beep].
	(baseDictionary includesKey: reply) ifTrue:
		[^ self inform: 'sorry that conflicts with
the name of another
entry in this dictionary'].
	baseDictionary at: reply put: (baseDictionary at: curr).
	baseDictionary removeKey: curr.
	self baseDictionary: baseDictionary.
	self updateThumbnail