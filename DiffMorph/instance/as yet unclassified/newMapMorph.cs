newMapMorph
	"Answer a new map morph."

	^DiffMapMorph new
		hResizing: #shrinkWrap;
		vResizing: #spaceFill;
		extent: 20@4;
		minWidth: 20;
		borderStyle: (BorderStyle inset width: 1)