handleKeystroke: aCharacter
	"Answer the menu for this list view."

	keystrokeActionSelector == nil ifTrue: [^ nil].
	model perform: keystrokeActionSelector with: aCharacter.