partsBinFor: morphList color: aColor

	| bin |
	bin _ PartsBinMorph new
		color: Color white;
		borderWidth: 0;
		orientation: #vertical.
	bin addMorphBack:
		(Morph new color: aColor; extent: 1@1).  "placeholder for parts bin label"
	bin addAllMorphs: (self listPaddedWithSpacersFrom: morphList padExtent: 1@4).
	bin openToDragNDrop: false.
	^ bin