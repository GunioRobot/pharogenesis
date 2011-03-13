partsBinFor: morphList

	| bin |
	bin _ PartsBinMorph new
		color: Color white;
		borderWidth: 0;
		orientation: #vertical.
	bin addMorphBack:
		(Morph new color: self color; extent: 1@1).  "placeholder for parts bin label"
	bin addAllMorphs: (self presenter listPaddedWithSpacersFrom: morphList padExtent: 1@4).
	bin openToDragNDrop: false.
	^ bin