addMemberFromClipboard
	| string newName |
	self canAddMember ifFalse: [ ^self ].
	string _ Clipboard clipboardText asString.
	newName _ FillInTheBlankMorph
		request: 'New name for member:'
		initialAnswer: 'clipboardText'.
	newName notEmpty ifTrue: [
		(archive addString: string as: newName) desiredCompressionMethod: ZipArchive compressionDeflated.
		self memberIndex: self members size.
		self changed: #memberList.
	]
