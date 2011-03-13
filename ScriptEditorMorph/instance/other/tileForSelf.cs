tileForSelf
	"Return a tile representing the player who is current the 'self' of this script"

	| aTileMorph |
	aTileMorph _ TileMorph new
		setObjectRef: nil "disused parm" actualObject: playerScripted;
		typeColor: (ScriptingSystem colorForType: #player); yourself.
	aTileMorph enforceTileColorPolicy.
	aTileMorph openInHand