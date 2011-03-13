optionalButtonRow
	| aRow aButton |
	aRow _ AlignmentMorph newRow beSticky.
	aRow clipSubmorphs: true.
	aRow addTransparentSpacerOfSize: (5@0).
	self optionalButtonSpecs do:
			[:spec |
				aButton _ PluggableButtonMorph
					on: self
					getState: nil
					action: spec second.
				aButton
					hResizing: #spaceFill;
					vResizing: #spaceFill;
					useRoundedCorners;
					label: spec first asString;
					askBeforeChanging: true;
					onColor: Color transparent offColor: Color transparent.
				aRow addMorphBack: aButton.
				aRow addTransparentSpacerOfSize: (3 @ 0).
				aButton setBalloonText: spec fourth.
				aRow addTransparentSpacerOfSize: (3 @ 0).

				(spec second == #sortBySize)
					ifTrue:
						[aRow addTransparentSpacerOfSize: (4@0)]].
	^ aRow