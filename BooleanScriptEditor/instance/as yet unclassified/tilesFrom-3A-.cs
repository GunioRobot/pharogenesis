tilesFrom: parseTree
	"Fill myself with tiles to corresponding to an existing boolean expression.  parseTree is the MessageNode that is the top of a parse tree."

	| lineOfTiles msgNode | 
	msgNode _ parseTree.
	lineOfTiles _ Array with: (PhraseTileMorph new tilesFrom: msgNode in: self).
	self insertTileRow: lineOfTiles after: 0.	"no row of control buttons"

