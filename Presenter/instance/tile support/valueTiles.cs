valueTiles
	| tiles |
	tiles _ OrderedCollection new.
	tiles add: (5 newTileMorphRepresentative typeColor: (ScriptingSystem colorForType: #number)).
	tiles add: ((4 @ 9) newTileMorphRepresentative typeColor: (ScriptingSystem colorForType: #point)).
	tiles add: (ColorTileMorph new typeColor: (ScriptingSystem colorForType: #color)).
	tiles add: (TileMorph new typeColor: (ScriptingSystem colorForType: #number);
			setExpression: '(180 atRandom)'
			label: 'random').
	tiles add: RandomNumberTile new.
	^ tiles