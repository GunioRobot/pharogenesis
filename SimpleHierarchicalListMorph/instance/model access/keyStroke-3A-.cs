keyStroke: event 
	"Process potential command keys"
	| args aCharacter |
	(self scrollByKeyboard: event)
		ifTrue: [^ self].
	keystrokeActionSelector == nil ifTrue: [^ nil].
	aCharacter _ event keyCharacter.
	(args _ keystrokeActionSelector numArgs) = 1 ifTrue: [^ model perform: keystrokeActionSelector with: aCharacter].
	args = 2 ifTrue: [^ model
			perform: keystrokeActionSelector
			with: aCharacter
			with: self].
	^ self error: 'The keystrokeActionSelector must be a 1- or 2-keyword symbol'