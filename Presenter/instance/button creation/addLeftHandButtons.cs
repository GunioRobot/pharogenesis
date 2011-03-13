addLeftHandButtons
	| aMorph anExtent aPosition |
	aMorph _ self newPaintingButton.
	anExtent _ aMorph extent.
	aPosition _ associatedMorph topLeft + (5 @ 3).
	aPosition _ associatedMorph positionNear: aPosition forExtent: anExtent adjustmentSuggestion: (0 @ (anExtent y)).
	associatedMorph addMorph: (aMorph beRepelling position: aPosition).

	associatedMorph addMorph:
		(self newPlayfieldButton position: (aPosition  + (5 @ 60))).
	associatedMorph addMorph:
		(self newPartsBinButton position: (aPosition + (9 @ 106))).
	associatedMorph addMorph:
		(self newControlsButton position: (aPosition + (6 @ 146)))