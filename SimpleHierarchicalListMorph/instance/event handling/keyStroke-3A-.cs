keyStroke: event 
	"Process potential command keys"

	| args aCharacter |
	(self scrollByKeyboard: event) ifTrue: [^self].
	aCharacter := event keyCharacter.
	(self arrowKey: aCharacter) ifTrue: [^true].
	keystrokeActionSelector isNil ifTrue: [^false].
	(args := keystrokeActionSelector numArgs) = 1 
		ifTrue: [^model perform: keystrokeActionSelector with: aCharacter].
	args = 2 
		ifTrue: 
			[^model 
				perform: keystrokeActionSelector
				with: aCharacter
				with: self].
	^self 
		error: 'The keystrokeActionSelector must be a 1- or 2-keyword symbol'