fileIn
	| extension |
	extension := (FileDirectory extensionFor: fileName) asLowercase.
	extension = 'mcz'
		ifTrue: [self installMcz]
		ifFalse: [self error: 'Cannot install file of type .', extension]