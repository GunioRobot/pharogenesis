partsDonorBinFor: morphList
	"Like partsBinFor: but marks things with partsDonor property"
	| bin listWithSpacers |
	bin _ PartsBinMorph newSticky
		color: Color white;
		borderWidth: 0;
		orientation: #vertical.
	bin addMorphBack:
		(Morph new color: self color; extent: 1@1).  "placeholder for parts bin label"
	morphList do: [:m | m markAsPartsDonor].
	listWithSpacers _ self presenter listPaddedWithSpacersFrom: morphList padExtent: 1@10.
	bin addAllMorphs: listWithSpacers.

	^ bin
