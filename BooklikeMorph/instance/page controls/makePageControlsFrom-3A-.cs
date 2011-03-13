makePageControlsFrom: controlSpecs
	"From the controlSpecs, create a set of page control and return them -- this method does *not* add the controls to the receiver."

	| c aButton col row b lastGuy |
	c _ (color saturation > 0.1) ifTrue: [color slightlyLighter] ifFalse: [color slightlyDarker].
	aButton _ SimpleButtonMorph new target: self; borderWidth: 1; borderColor: Color veryLightGray; color: c.
	col _ AlignmentMorph newColumn.
	col color: c; borderWidth: 0; layoutInset: 0.
	col hResizing: #spaceFill; vResizing: #shrinkWrap; extent: 5@5.

	row _ AlignmentMorph newRow.
	row color: c; borderWidth: 0; layoutInset: 0.
	row hResizing: #spaceFill; vResizing: #shrinkWrap; extent: 5@5.
	controlSpecs do: [:spec |
		spec == #spacer
			ifTrue:
				[row addTransparentSpacerOfSize: (10 @ 0)]
			ifFalse:
				[spec == #variableSpacer
					ifTrue:
						[row addMorphBack: AlignmentMorph newVariableTransparentSpacer]
					ifFalse:
						[b _ aButton fullCopy
						label: spec first;
						actionSelector: spec second;
						borderWidth: 0;
	 					setBalloonText: spec third.
						row addMorphBack: b.
						(((lastGuy _ spec last asLowercase) includesSubString: 'menu') or:
								[lastGuy includesSubString: 'designations'])
							ifTrue: [b actWhen: #buttonDown]]]].  "pop up menu on mouseDown"
		col addMorphBack: row.
	^ col