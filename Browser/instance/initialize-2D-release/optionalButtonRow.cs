optionalButtonRow
	"Answer a row of control buttons"

	| aRow aButton |
	aRow _ AlignmentMorph newRow.
	aRow setNameTo: 'buttonPane'.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow wrapCentering: #center; cellPositioning: #leftCenter.
	aRow clipSubmorphs: true.
	aRow addTransparentSpacerOfSize: (5@0).
	self optionalButtonPairs  do:
			[:tuple |
				aButton _ PluggableButtonMorph
					on: self
					getState: nil
					action: tuple second.
				aButton 
					useRoundedCorners;
					hResizing: #spaceFill;
					vResizing: #spaceFill;
					label: tuple first asString;
					onColor: Color transparent offColor: Color transparent.
				tuple size > 2 ifTrue: [aButton setBalloonText: tuple third].
				aRow addMorphBack: aButton.
				aRow addTransparentSpacerOfSize: (3 @ 0)].
	aRow addMorphBack: self diffButton.
	Preferences sourceCommentToggleInBrowsers ifTrue: [aRow addMorphBack: self sourceOrInfoButton].
	^ aRow