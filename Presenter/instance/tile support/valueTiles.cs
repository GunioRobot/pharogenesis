valueTiles
	| tiles |
	tiles _ OrderedCollection new.
	tiles add: (5 newTileMorphRepresentative typeColor: (TilePadMorph colorForType: #number)).
	tiles add: ((4 @ 9) newTileMorphRepresentative typeColor: (TilePadMorph colorForType: #point)).
	tiles add: (ColorTileMorph new typeColor: (TilePadMorph colorForType: #color)).
	tiles add: (TileMorph new typeColor: (TilePadMorph colorForType: #number);
			setExpression: '(180 atRandom)'
			label: 'random').
	tiles add: ((TileMorph new typeColor: (TilePadMorph colorForType: #number))
				setExpression: '(self getMouseX)' label: 'mouseX').

	tiles add: ((TileMorph new typeColor: (TilePadMorph colorForType: #number))
		setExpression: '(self getMouseY)' label: 'mouseY').

	^ tiles