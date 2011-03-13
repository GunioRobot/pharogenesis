handleKeystroke: aCharacter
	"Answer the menu for this list view."

	| args |
	keystrokeActionSelector == nil ifTrue: [^ nil].
	controller controlTerminate.
	(args _ keystrokeActionSelector numArgs) = 1
		ifTrue: [model perform: keystrokeActionSelector with: aCharacter.
				^ controller controlInitialize].
	args = 2
		ifTrue: [model perform: keystrokeActionSelector with: aCharacter with: self.
				^ controller controlInitialize].
	^ self error: 'The keystrokeActionSelector must be a 1- or 2-keyword symbol'