optionalButtonRow
	"Answer a row of buttons to occur in a tool pane"

	| aRow aButton |
	aRow _ AlignmentMorph newRow.
	aRow hResizing: #spaceFill.
	aRow clipSubmorphs: true.
	aRow layoutInset: 5@2; cellInset: 3.
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
			aButton setBalloonText: triplet third].
	aRow addMorphBack: self regularDiffButton.
	self wantsPrettyDiffOption ifTrue:
		[aRow addMorphBack: self prettyDiffButton].
	^ aRow