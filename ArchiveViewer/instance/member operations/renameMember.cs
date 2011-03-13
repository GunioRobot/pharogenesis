renameMember
	| newName |
	self canRenameMember ifFalse: [ ^self ].
	newName := FillInTheBlankMorph
		request: 'New name for member:'
		initialAnswer: self selectedMember fileName.
	newName notEmpty ifTrue: [
		self selectedMember fileName: newName.
		self changed: #memberList
	]