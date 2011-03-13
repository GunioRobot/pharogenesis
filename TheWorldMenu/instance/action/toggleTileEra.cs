toggleTileEra
	"old or new tiles in scriptors"

	myWorld setProperty: #universalTiles toValue: 
		(myWorld valueOfProperty: #universalTiles ifAbsent: [false]) not