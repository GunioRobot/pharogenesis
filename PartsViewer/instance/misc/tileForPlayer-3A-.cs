tileForPlayer: aPlayer
	"Return a tile representing aPlayer"

	^ TileMorph new
		setObjectRef: nil "disused parm" actualObject: aPlayer;
		typeColor: (TilePadMorph colorForType: #player)
