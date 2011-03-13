getFileNameFromUser
	| newName |
	newName _ FillInTheBlank
		request: 'New File Name?'
		initialAnswer: (FileDirectory localNameFor: self imageName).
	newName = '' ifTrue: [^nil].
	((FileDirectory default includesKey: (self fullNameForImageNamed: newName)) or:
	 [FileDirectory default includesKey: (self fullNameForChangesNamed: newName)]) ifTrue: [
		(self confirm: newName, ' already exists. Overwrite?') ifFalse: [^nil]].
	^newName
