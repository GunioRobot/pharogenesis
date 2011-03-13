viewMorph: aMorph
	| aPlayer aViewer aPalette |
	(aPalette _ aMorph standardPalette) ifNotNil:
		[^ aPalette viewMorph: aMorph].

	aPlayer _ aMorph assuredCostumee.
	associatedMorph addMorph: (aViewer _ self nascentPartsViewer).
	aViewer setPlayer: aPlayer.
	aViewer makeAllTilesGreen.
	aMorph primaryHand attachMorph: aViewer