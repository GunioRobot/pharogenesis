makeTile: anOperator ofType: aType
	"Make a scripting tile to fetch an operator. Attach it to the hand, allowing the user to drop it directly into a tile script."

	| tile argTile |
	tile := PhraseTileMorph new setSlotRefOperator: anOperator type: aType.
	argTile := self tileToRefer.
	argTile bePossessive.
	tile firstSubmorph addMorph: argTile.
	tile enforceTileColorPolicy.
	ActiveHand attachMorph: tile
