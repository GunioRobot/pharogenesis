optionalButtonRow
	| aRow aButton |
	aRow _ AlignmentMorph newRow.
	aRow hResizing: #spaceFill.
	aRow clipSubmorphs: true.
	aRow addTransparentSpacerOfSize: (5@0).
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	self changeListButtonSpecs do:
		[:triplet |
			aButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: triplet second.
			aButton
				hResizing: #spaceFill;
				vResizing: #spaceFill;
				useRoundedCorners;
				label: triplet first asString;
				askBeforeChanging: true;
				onColor: Color transparent offColor: Color transparent.

			aRow addMorphBack: aButton.
			aRow addTransparentSpacerOfSize: (3 @ 0).
			aButton setBalloonText: triplet third.
		].
	aRow addMorphBack: self diffButton.	
	^ aRow