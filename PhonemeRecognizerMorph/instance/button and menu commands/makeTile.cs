makeTile
	"Make a scripting tile to fetch the current phoneme's mouth position. Attach it to the hand, allowing the user to drop it directly into a tile script."

	| tile argTile |
	tile _ PhraseTileMorph new setSlotRefOperator: #mouthPosition type: #number.
	argTile _ TileMorph new
		setObjectRef: nil actualObject: self;
		typeColor: (ScriptingSystem colorForType: #object).
	argTile bePossessive.
	tile firstSubmorph addMorph: argTile.
	tile enforceTileColorPolicy.
	self world firstHand attachMorph: tile.
