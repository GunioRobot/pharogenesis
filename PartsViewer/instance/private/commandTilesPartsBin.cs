commandTilesPartsBin

	| bin |
	bin _ PartsBinMorph new
		color: self color;
		borderWidth: 0;
		orientation: #vertical.
	bin addMorphBack:
		(Morph new color: self color; extent: 1@1).  "placeholder for parts bin label"
	bin addAllMorphs: self commandTiles.
	^ bin
