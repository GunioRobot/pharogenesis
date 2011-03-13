scriptee
	| editor |
	playerScripted ifNotNil: [^ playerScripted].
	(editor _ self topEditor) == self ifTrue: [self error: 'unattached script editor'. ^ nil].
	^ editor scriptee