testArrowAction
	"self debug: #testArrowAction"
	| dummy tile |
	dummy _ Morph new.
	tile _ TileMorph new setOperator: '+'.
	dummy addMorph: tile.
	tile arrowAction: 1.
	self assert: tile codeString = '-'.

	tile _ TileMorph new setOperator: '<'.
	dummy addMorph: tile.
	tile arrowAction: 1.
	"Because receiver is not tile"
	self assert: tile codeString = '='.

	tile _ true newTileMorphRepresentative.
	dummy addMorph: tile.
	tile arrowAction: 1.
	self assert: tile codeString = '(false)'.
