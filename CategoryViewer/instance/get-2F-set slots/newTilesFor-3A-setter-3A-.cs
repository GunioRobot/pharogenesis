newTilesFor: aPlayer setter: aSpec
	| ms  argValue |
	"Return universal tiles for a getter on this property.  Record who self is."

	argValue := aPlayer perform: (Utilities getterSelectorFor: aSpec second asSymbol).
	ms := MessageSend receiver: aPlayer selector: aSpec ninth arguments: (Array with: argValue).
	^ ms asTilesIn: aPlayer class globalNames: (aPlayer class officialClass ~~ CardPlayer)
			"For CardPlayers, use 'self'.  For others, name it, and use its name."