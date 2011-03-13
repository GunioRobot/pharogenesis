renameMe
	| newName |
	newName _ self chooseNameLike: self knownName.
	newName ifNil: [^ nil].
	self setNamePropertyTo: newName