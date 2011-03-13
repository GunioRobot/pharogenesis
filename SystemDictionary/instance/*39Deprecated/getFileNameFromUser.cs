getFileNameFromUser

	| newName |
	self deprecated: 'Use SmalltalkImage current getFileNameFromUser'.
	newName := UIManager default
		request: 'New File Name?' translated
		initialAnswer: (FileDirectory localNameFor: SmalltalkImage current imageName).
	newName = '' ifTrue: [^nil].
	((FileDirectory default fileOrDirectoryExists: (SmalltalkImage current fullNameForImageNamed: newName)) or:
	 [FileDirectory default fileOrDirectoryExists: (SmalltalkImage current fullNameForChangesNamed: newName)]) ifTrue: [
		(self confirm: ('{1} already exists. Overwrite?' translated format: {newName})) ifFalse: [^nil]].
	^newName
