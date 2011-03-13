removeSpaces
	self submorphsDo:
		[:m | (m isMemberOf: Morph) ifTrue: [m delete]].
	self removeEmptyRows