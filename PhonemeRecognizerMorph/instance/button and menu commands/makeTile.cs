makeTile
	"Make a scripting tile to fetch the current phoneme's mouth position. Attach it to the hand, allowing the user to drop it directly into a tile script."

	| tile argTile |
	tile _ PhraseTileMorph new setSlotRefOperator: #mouthPosition type: #Number.
	argTile _ self tileToRefer.
	argTile bePossessive.
	tile firstSubmorph addMorph: argTile.
	tile enforceTileColorPolicy.
	ActiveHand attachMorph: tile
