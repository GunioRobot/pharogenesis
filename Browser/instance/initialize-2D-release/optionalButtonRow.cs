optionalButtonRow
	| aRow aButton |
	aRow _ AlignmentMorph newRow.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow centering: #center.
	aRow setProperty: #clipToOwnerWidth toValue: true.
	aRow addTransparentSpacerOfSize: (5@0).
	self optionalButtonPairs  do:
			[:pair |
				aButton _ PluggableButtonMorph
					on: self
					getState: nil
					action: pair second.
				aButton useRoundedCorners;
					label: pair first asString;
					onColor: Color transparent offColor: Color transparent.
				aRow addMorphBack: aButton.
				aRow addTransparentSpacerOfSize: (3 @ 0)].
	aRow addMorphBack: self diffButton.
	^ aRow