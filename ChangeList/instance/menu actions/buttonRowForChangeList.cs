buttonRowForChangeList
	| aRow aButton |
	aRow _ AlignmentMorph newRow.
	aRow setProperty: #clipToOwnerWidth toValue: true.
	aRow addTransparentSpacerOfSize: (5@0).
	aRow centering: #center.
	self changeListButtonSpecs do:
		[:triplet |
			aButton _ PluggableButtonMorph
				on: self
				getState: nil
				action: triplet second.
			aButton useRoundedCorners;
				label: triplet first asString;
				askBeforeChanging: true;
				onColor: Color transparent offColor: Color transparent.
			aRow addMorphBack: aButton.
			aRow addTransparentSpacerOfSize: (3 @ 0).
			aButton setBalloonText: triplet third.
			aRow addMorphBack: aButton.
			aRow addTransparentSpacerOfSize: (3 @ 0).
			aButton setBalloonText: triplet third.
			aRow addTransparentSpacerOfSize: (3 @ 0)].
	aRow addMorphBack: self diffButton.	
	^ aRow