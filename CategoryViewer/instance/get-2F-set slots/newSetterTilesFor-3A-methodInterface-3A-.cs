newSetterTilesFor: aPlayer methodInterface: aMethodInterface
	"Return universal tiles for a setter on this property.  Record who self is."

	| ms argValue makeSelfGlobal phrase |
	argValue _ aPlayer perform: aMethodInterface selector.
	ms _ MessageSend receiver: aPlayer 
		selector: aMethodInterface companionSetterSelector 
		arguments: (Array with: argValue).
	makeSelfGlobal _ aPlayer class officialClass ~~ CardPlayer.
	phrase _ ms asTilesIn: aPlayer class globalNames: makeSelfGlobal.
			"For CardPlayers, use 'self'.  For others, name it, and use its name."
	makeSelfGlobal ifFalse: [phrase setProperty: #scriptedPlayer toValue: aPlayer].
	^ phrase